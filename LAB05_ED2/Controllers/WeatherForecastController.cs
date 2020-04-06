using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LAB05_ED2.Class;
using LAB05_ED2.Repository;

namespace LAB05_ED2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly IMethod methodData = new Method();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // -http://localhost:4689/weatherforecast/cipher/?m=zigzag
        [HttpGet("cipher", Name = "GetMetodo")]
        public IEnumerable<MethodClass> Get(string m, [FromBody]MethodClass newMethod)
        {
            switch (m)
            {
                case "zigzag":
                    methodData.CipherZigZag(newMethod.rPath, newMethod.wPath, newMethod.key);
                    break;
                case "cesar":
                    methodData.CipherCesar(newMethod.rPath, newMethod.wPath, newMethod.word);
                    break;
                case "ruta":
                    if (newMethod.TypeRuta == "vertical")
                    {
                        methodData.CipherRutaV(newMethod.rPath, newMethod.wPath, newMethod.key);
                    }
                    else if (newMethod.TypeRuta == "spiral")
                    {
                        methodData.CipherRutaS(newMethod.rPath, newMethod.wPath, newMethod.key);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
    


        // -http://localhost:4689/weatherforecast/decipher/?m=zigzag
        [HttpGet("decipher", Name = "GetMetodo2")]
        public IEnumerable<MethodClass> Get(string m, [FromBody]MethodClass newMethod,int a)
        {
            switch (m) 
            {
                case "zigzag":
                    methodData.DecipherZigZag(newMethod.rPath, newMethod.wPath, newMethod.key);
                    break;
                case "cesar":
                    methodData.DecipherCesar(newMethod.rPath, newMethod.wPath, newMethod.word);
                    break;
                case "ruta":
                    if (newMethod.TypeRuta == "vertical")
                    {
                        methodData.DecipherRutaV(newMethod.rPath, newMethod.wPath, newMethod.key);
                    }
                    else if (newMethod.TypeRuta == "spiral")
                    {
                        methodData.DecipherRutaS(newMethod.rPath, newMethod.wPath, newMethod.key);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }


        /*
         CODE FOR POSTMAN IN BODY -> RAW -> JSON
         {
	        "rpath" : "file.txt" ,
	        "wpath" : "file2.txt",
	        "key" : 5,
	        "word" : "cesar",
	        "TypeRuta" : "null"
        }
       
         */

    } //end class
}
