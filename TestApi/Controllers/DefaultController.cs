// File: TestApi/TestApi/DefaultController.cs
// User: Adrian Hum/
// 
// Created:  2018-02-12 2:23 PM
// Modified: 2018-02-13 8:49 AM

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using TestApi.Models;

namespace TestApi.Controllers
{
    [EnableCors("http://localhost:2986", "*", "*")]
    public class DefaultController : ApiController
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get Method Place holder for testing CORS
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amnt"></param>
        /// <returns></returns>
        [HttpGet]
        public string Get(string name = "", string amnt = "")
        {
            return "You cannot use this function this way, this function is intentionally left blank.";
        }

        /// <summary>
        ///     Handles submission of details about bearer and currency amount.
        /// </summary>
        /// <param name="objChequeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] ChequeDetails objChequeDetails)
        {
            var q = new ValidationContext(objChequeDetails);
            try
            {
                if (objChequeDetails.Validate(validationContext: q).Any()) throw new Exception("Data Is In An Invalid State");
                logger.Info($"Sending response to {objChequeDetails.FullName} for {objChequeDetails.Amount}");
                return Request.CreateResponse(HttpStatusCode.OK, objChequeDetails);
            }

            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                throw;
            }
        }
    }
}