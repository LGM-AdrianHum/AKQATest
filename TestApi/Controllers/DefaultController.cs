using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using TestApi.Models;

namespace TestApi.Controllers
{
    [EnableCors(origins: "http://localhost:2986", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public string Get(string name, string amnt)
        {
            return "hello world";
        }

        [HttpPost]

        public HttpResponseMessage Post([FromBody] ChequeDetails objChequeDetails)
        {


            try
            {
                var r = objChequeDetails;
                if (r == null) logger.Info("Null Value Passed Into Api");
                logger.Info($"Sending response to {r.FullName} for {r.Amount}");
                return Request.CreateResponse<ChequeDetails>(HttpStatusCode.OK, r);

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                throw;
            }
        }
    }
}
