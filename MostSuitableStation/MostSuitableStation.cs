using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MostSuitableStation.Model;


namespace MostSuitableStation
{
    public static class MostSuitableStation
    {
        [FunctionName("MostSuitableStation")]
        public static async Task<HttpResponseMessage> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "most-suitable-station")]Input req, 
            ILogger logger)
        {
            try
            {
                var result = new SuitableStationHelper(req.Stations)
                    .MostSuitableStationFor(req.Point);

                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(result)
                });
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured";
                logger.LogError(errorMessage, e);
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(errorMessage)
                });

            }

        }
    }
}
