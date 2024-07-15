using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IsolationController : ControllerBase
    {
        [HttpPost("Test")]
        public ActionResult<string> Test([FromBody] TestConfigurationModel model)
        {
            // Print the received data to the console
            Console.WriteLine("Received Test Configuration:");
            Console.WriteLine($"Output To Chassis: {model.OutputToChassis} V");
            Console.WriteLine($"Input To Chassis: {model.InputToChassis} V");
            Console.WriteLine($"Input To Output: {model.InputToOutput} V");
            Console.WriteLine($"Output To Output: {model.OutputToOutput} V");
            Console.WriteLine($"Number Of Outputs: {model.NumberOfOutput}");

            // You can add your processing logic here
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            // Return a response
            return Ok("Test configuration received and processed successfully.");
        }
    }

    public class TestConfigurationModel
    {
        public int OutputToChassis { get; set; }
        public int InputToChassis { get; set; }
        public int InputToOutput { get; set; }
        public int OutputToOutput { get; set; }
        public int NumberOfOutput { get; set; }
    }
}