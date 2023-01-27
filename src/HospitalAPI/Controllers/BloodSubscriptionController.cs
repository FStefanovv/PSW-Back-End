using HospitalLibrary.Core.BloodSubscription;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSubscriptionController : ControllerBase
    {
        static readonly private HttpClient client;
        readonly private IBloodSubscriptionService _bloodSubscriptionService;

        static BloodSubscriptionController()
        {
            client = new HttpClient();
           
        }

       
        public BloodSubscriptionController(IBloodSubscriptionService bloodSubsciptionService)
        {
            _bloodSubscriptionService = bloodSubsciptionService;
        }

        [HttpGet]
        public ActionResult GetActive()
        {
            var active = _bloodSubscriptionService.GetActive();
            if(active == null)  return NoContent(); 
            return Ok(active);
        }

        [HttpGet("Supplies")]
        public ActionResult GetBloodSupplies() {
            var supplies = _bloodSubscriptionService.GetSupplies();
            if(supplies == null) return NoContent();
            return Ok(supplies);
        }


        [HttpPost("Activate")]
        public async Task<IActionResult> SubmitSubscription(BloodSubscription subscription)
        {
            
          //  var response = await client.PutAsync("https://localhost:44336/api/BloodSubscription", subscription);
          //  List<string> deserializedAds = JsonConvert.DeserializeObject<List<string>>(ads);
            return Ok();
        }




        [HttpGet("Cancel")]
        public async Task<IActionResult> CancelSubscription(BloodSubscription subscription)
        {

            var response = await client.GetAsync("https://localhost:44336/api/BloodSubscription/Cancel");
            if (response.IsSuccessStatusCode) return Ok();
            else return NoContent();
        }


        [HttpGet("Recieve")]
        public async Task<IActionResult> RecieveBlood()
        {
            return Ok();
        }
    }
}
