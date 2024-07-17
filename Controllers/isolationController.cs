using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IsolationController : ControllerBase
    {
        [HttpPost("Test")]
        public ActionResult<TestResultResponse> Test([FromBody] TestConfigurationModel model)
        {
            try
            {
                // Print the received data to the console (for debugging purposes)
                Console.WriteLine("Received Test Configuration:");
                Console.WriteLine($"Output To Chassis: {model.OutputToChassis} V");
                Console.WriteLine($"Input To Chassis: {model.InputToChassis} V");
                Console.WriteLine($"Input To Output: {model.InputToOutput} V");
                Console.WriteLine($"Output To Output: {model.OutputToOutput} V");
                Console.WriteLine($"Number Of Outputs: {model.NumberOfOutput}");

                // Perform your test logic her e




                // For demonstration, let's mock the test results
                var testResults = new Dictionary<string, string>
                {
                    { "Chassis", "Fail" },
                    { "Input", "Pass" },
                    { "Output 1", "Pass" },
                    { "Output 2", "Pass" },
                    { "Output 3", "Fail" },
                     { "Output 4", "Pass" },
                    { "Output 5", "Fail" },
                     { "Output 6", "Fail" }
                };

                var detailsResult = "You have 3 fails....";

                // Determine passOrFail based on test results (example logic)
                var passOrFail = "Fail";

                // Create a response object
                var response = new TestResultResponse
                {
                    TestResults = testResults,
                    DetailsResult = detailsResult,
                    PassOrFail = passOrFail
                };
                Thread.Sleep(1000);
                // Return the response as JSON
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log any exceptions or errors
                Console.Error.WriteLine($"Error processing test: {ex.Message}");
                return StatusCode(500, "Error processing test");
            }
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

    public class TestResultResponse
    {
        public Dictionary<string, string> TestResults { get; set; }
        public string DetailsResult { get; set; }
        public string PassOrFail { get; set; }
    }
}
