using database.trading.DB_Models.SearchObjects;
using database.trading.DB_Models.Trading;
using database.trading.DB_Models.User.Wallet;
using modeli.trading.Trading;
using modeli.trading.Trading.Requests;
using servisi.trading.IRepos.Trading;
using servisi.trading.Repos.Base;
using servisi.trading.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.Repos.Trading
{
    public class NarudzbaServis : ReadWriteBaseServis<Narudzba, narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest>, INarudzbaServis
    {
        private readonly DatabaseContext context;

        public BaseState baseState { get; set; }
        public NarudzbaServis(IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger, BaseState baseState) : base(_mapper, context, _config, _logger)
        {
            this.context = context;
            this.baseState = baseState;
        }


        public override async Task<narudzba> Insert(NarudzbaUpsertRequest requestBody)
        {
            BaseState? state = null;

            requestBody.kreirana = DateTime.Now;

            var walletNarucioca = context.walleti.FirstOrDefault(x => x.userId == requestBody.userId);

            var setImovinaNarucioca = context.wallet_imovine.Where(x => x.walletId == walletNarucioca.id).ToList();

            wallet_imovina wcashNarucioc = setImovinaNarucioca.FirstOrDefault(x => x.valuta_id == 15);

            wallet_imovina valutaInteresaNarucioca = setImovinaNarucioca.FirstOrDefault(x => x.valuta_id == requestBody.valutaId);

            List<narudzba> narudzbe = context.narudzbe.ToList();

            if (requestBody.tip == 0) // ako je nova narudzba prodaja
            {
                if (valutaInteresaNarucioca == null) //dali korisnik uopšte ima valutu koju žei prodati
                    return null;

                if (valutaInteresaNarucioca.kolicina_valute < requestBody.kolicina) //dali korisnik ima dovoljno da proda valutu
                    return null;
            }
            else // ako je nova narudzba kupovina
            {
                if (wcashNarucioc.kolicina_valute < requestBody.cijena) //dali korisnik ima dovoljno da plati transakciju
                    return null;

                if (valutaInteresaNarucioca == null) //spremanje valute koju korisnik želi da kupi
                {
                    var valuta = context.valute.FirstOrDefault(x => x.valuta_id == requestBody.valutaId);

                    var wallet_imovina = new wallet_imovina()
                    {
                        walletId = walletNarucioca.id,
                        kolicina_valute = 0,
                        naziv_valute = valuta.naziv,
                        valuta_id = requestBody.valutaId,
                    };
                    await context.wallet_imovine.AddAsync(wallet_imovina);
                }
            }

            foreach (var narudzba in narudzbe)
            {
                if(narudzba.state != "izvrsena" && narudzba.state != "odbijena")
                {
                    if (narudzba.valutaId == requestBody.valutaId && narudzba.kolicina == requestBody.kolicina)
                    {
                        if(narudzba.tip == 0) // iterirana narudzba je prodaja
                        {
                                //smanjit kolicinu imovine starog vlasnika (prodavca)

                                var prodavacWallet = context.walleti.FirstOrDefault(x => x.userId == narudzba.userId);

                            if (prodavacWallet.id != walletNarucioca.id)
                            {

                                var prodavacImovina = context.wallet_imovine.First(x => x.valuta_id == requestBody.valutaId && x.walletId == prodavacWallet.id);

                                prodavacImovina.kolicina_valute -= requestBody.kolicina;

                                //povecat kolicinu imovine novog vlasnika (kupca)

                                valutaInteresaNarucioca.kolicina_valute += requestBody.kolicina;


                                //povecat wcash prdavcu

                                var prodavacWcash = context.wallet_imovine.First(x => x.valuta_id == 15 && x.walletId == prodavacWallet.id);

                                prodavacWcash.kolicina_valute += requestBody.cijena;

                                //smanjit wcash kupcu

                                wcashNarucioc.kolicina_valute -= requestBody.cijena;


                                //terminiraj narudžbu prodaje

                                terminiraj(narudzba.id);

                                //terminiraj narudžbu kupovine

                                state = baseState.CreateState("izvrsena");

                                //spremi promjene

                                await context.SaveChangesAsync();

                                break;
                            }

                        }
                        else // iterirana narudzba je kupovina
                        {
                            //smanjit kolicinu imovine starog vlasnika (prodavca)
                            valutaInteresaNarucioca.kolicina_valute -= requestBody.kolicina;

                            //povecat kolicinu imovine novog vlasnika (kupca)
                            var prodavacWallet = context.walleti.FirstOrDefault(x => x.userId == narudzba.userId);

                            var prodavacImovina = context.wallet_imovine.First(x => x.valuta_id == requestBody.valutaId && x.walletId == prodavacWallet.id);

                            prodavacImovina.kolicina_valute += requestBody.kolicina;

                            //povecat wcash prdavcu

                            wcashNarucioc.kolicina_valute += requestBody.cijena;

                            //smanjit wcash kupcu

                            var prodavacWcash = context.wallet_imovine.First(x => x.valuta_id == 15 && x.walletId == prodavacWallet.id);

                            prodavacWcash.kolicina_valute -= requestBody.cijena;

                            //terminiraj narudžbu prodaje

                            terminiraj(narudzba.id);

                            //terminiraj narudžbu kupovine

                            state = baseState.CreateState("izvrsena");

                            //spremi promjene

                            await context.SaveChangesAsync();

                            break;
                        }
                    }
                }
            }
            if(state==null)
                state = baseState.CreateState("kreirana");

            return await state.insert(requestBody);
        }

        public async Task<bool> aktiviraj(int id)
        {
            var state = baseState.CreateState("aktivna");

            if(state != null)
            {
                var narudzba = context.narudzbe.FirstOrDefault(x => x.id == id);

                narudzba.state = "aktivna";

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> odbij(int id)
        {
            var state = baseState.CreateState("odbijena");

            if (state != null)
            {
                var narudzba = context.narudzbe.FirstOrDefault(x => x.id == id);

                narudzba.state = "odbijena";

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> terminiraj(int id)
        {
            var state = baseState.CreateState("izvrsena");

            //skinut WCash sa racuna i dodajem novu imovinu

            if (state != null)
            {
                var narudzba = context.narudzbe.FirstOrDefault(x => x.id == id);

                narudzba.state = "izvrsena";

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Narudzba>> GetAllForms(int id = 0)
        {
            var setNarudzbi = context.narudzbe;
            var setKorisnika = context.korisnici;
            var setValuta = context.valute;

            var result = new List<Narudzba>();

            foreach (var narudzba in setNarudzbi)
            {
                    var korisnik = await setKorisnika.FindAsync(narudzba.userId);
                    var valuta = await setValuta.FindAsync(narudzba.valutaId);

                if (id != 0 && narudzba.userId == id) { 
                    result.Add(new Narudzba() {
                        cijena = narudzba.cijena,
                        id = narudzba.id,
                        kolicina = narudzba.kolicina,
                        kreirana = narudzba.kreirana,
                        state = narudzba.state,
                        userId = narudzba.userId,
                        userIme = korisnik.ime_prezime,
                        valutaId = narudzba.valutaId,
                        valutaNaziv = valuta.naziv,
                        tip = narudzba.tip

                    });
                }else if(id == 0)
                {
                    result.Add(new Narudzba()
                    {
                        cijena = narudzba.cijena,
                        id = narudzba.id,
                        kolicina = narudzba.kolicina,
                        kreirana = narudzba.kreirana,
                        state = narudzba.state,
                        userId = narudzba.userId,
                        userIme = korisnik.ime_prezime,
                        valutaId = narudzba.valutaId,
                        valutaNaziv = valuta.naziv,
                        tip = narudzba.tip

                    });
                }
            }

            return result;
        }
    }
}
