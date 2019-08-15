using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Xml;

namespace AgeFunction
{
    public static class Function1
    {
        [FunctionName("AgeFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic data = JsonConvert.DeserializeObject(requestBody);



            return (ActionResult)new OkObjectResult(data);

            //2
            //XmlDocument doc = JsonConvert.DeserializeXmlNode(requestBody);

            //StringWriter sw = new StringWriter();
            //XmlTextWriter xw = new XmlTextWriter(sw);
            //doc.WriteTo(xw);
            //string XmlString = sw.ToString();

            //return (ActionResult)new OkObjectResult(XmlString);

            //1
            //string birthday = data.birthday;

            //string[] dateStr = birthday.Split('.');
            //DateTime date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));


            //return (ActionResult)new OkObjectResult($"Ви прожили {(DateTime.Now - date).TotalDays} днів");
        }
    }
}
