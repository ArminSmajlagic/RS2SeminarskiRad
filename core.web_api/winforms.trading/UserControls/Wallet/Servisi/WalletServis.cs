using modeli.trading.User.Wallet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using winforms.trading.LocalStorage;

namespace winforms.trading.UserControls.Wallet.Servisi
{

    public class WalletServis
    {
        private readonly HttpClient _httpClient;
        const string serverUrl = "https://localhost:7291/api/Wallet/";

        public List<WalletTransakcija> walletTransactions { get; set; }
        public modeli.trading.User.Wallet.Wallet wallet { get; set; }
        public List<WalletImovina> assets { get; set; }

        public WalletServis()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> getTransactionData()
        {
            var url = serverUrl + wallet.id + "/getTransactionData";

            var response = await url.WithHeader("Authorization", "Bearer " + DataStorage.token).GetJsonAsync<List<WalletTransakcija>>();

            walletTransactions = response;

            return true;

        }

        public async Task<bool> getWalletData(int user_id)
        {
            var url = serverUrl + user_id + "/getWalletData";

            if (user_id < 1)
            {
                Console.WriteLine("Request is null!");

                return false;
            }
            

            var response = await url.WithHeader("Authorization", "Bearer " + DataStorage.token).GetJsonAsync<modeli.trading.User.Wallet.Wallet>();


            wallet = response;

            var assets_result = await GetCryptoAssets(wallet.id);

            return assets_result;

        }

        public async Task<bool> GetCryptoAssets(int wallet_id)
        {
            var url = serverUrl + wallet_id + "/GetCryptoAssets";

            if (wallet_id < 1)
            {
                Console.WriteLine("Request is null!");

                return false;
            }


            assets = await url.WithHeader("Authorization", "Bearer " + DataStorage.token).GetJsonAsync<List<WalletImovina>>();

            return true;
        }

        public async Task<bool> Depozit(WalletTransakcija transakcija)
        {

            transakcija.walletId = wallet.id;

            var endpoint = serverUrl+ "DodajWalletTransakciju";


            var json = JsonConvert.SerializeObject(transakcija);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();
                return true;
            }
            else
            {
                Console.WriteLine("The wallet_id might not be valid.");

                return false;
            }
        }

        public async Task<bool> Withdraw(WalletTransakcija transakcija)
        {
            transakcija.walletId = wallet.id;

            var endpoint = serverUrl + "DodajWalletTransakciju";


            var json = JsonConvert.SerializeObject(transakcija);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();
                return true;

            }
            else
            {
                Console.WriteLine("The wallet_id might not be valid.");
                return false;

            }
        }
    }
}
