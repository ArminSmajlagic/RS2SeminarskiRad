using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace servisi.trading.Repos.ML
{
    public class CryptoPredictionServis
    {
        private readonly DatabaseContext Context;
        private static MLContext mlContext = null;
        private static ITransformer model = null;
        public CryptoPredictionServis(DatabaseContext context)
        {
            Context = context;
        }


        public void Predict()
        {
            mlContext = new MLContext();

            //var data = Context.Set<valute_data>();

            //IEnumerable<valute_data> enumreableData = new List<valute_data>();

            //var trainingData = mlContext.Data.LoadFromEnumerable(enumreableData);

            //var est = mlContext.Regression //choose model for prediction

            //model = est.Fit(trainingData);

            //...
        }
    }
}
