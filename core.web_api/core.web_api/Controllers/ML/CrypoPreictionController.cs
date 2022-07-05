
using Microsoft.AspNetCore.Mvc;
using servisi.trading.Repos.ML;

namespace core.web_api.Controllers.ML
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrypoPreictionController : ControllerBase
    {
        private readonly CryptoPredictionServis predictionServis;

        public CrypoPreictionController(CryptoPredictionServis predictionServis)
        {
            this.predictionServis = predictionServis;
        }

        [HttpGet]
        public IActionResult GetPrediction(string interval, int currencyId)
        {
            if (string.IsNullOrEmpty(interval))
            {
                interval = "1D";
            }

            if(currencyId < 1)
            {
                return BadRequest("Id koji ste proslijedili nije validan!");
            }

            predictionServis.Predict(); //need a respons for predict method

            return Ok("Not implemented!");
        }
    }
}
