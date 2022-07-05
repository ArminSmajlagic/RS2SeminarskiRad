using database.trading.DB_Models.User;
using servisi.trading.Repos.Base;
namespace servisi.trading.Repos.User;
public class UserReadServis : ReadServis<modeli.trading.User.User,user,object>
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    public UserReadServis(IMapper mapper,DatabaseContext context, IConfiguration _config, ILogger _logger):base(mapper,context,_config,_logger)
    {
        Context = context;
        config = _config;
        logger = _logger;
    }

    //public override async Task<modeli.trading.User.User> GetById(int id)
    //{
    //    if (id < 1)
    //        return null;

    //    var set = Context.korisnici;

    //    var lista = set.ToList();

    //    var entity = await set.FindAsync(id);

    //    if (entity == null)
    //        return null;

    //    var mappedEntity = mapper.Map<modeli.trading.User.User>(entity);

    //    return mappedEntity;
    //} include auth user while geting user


}
