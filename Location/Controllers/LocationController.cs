using System.Web.Http;

namespace Location.Controllers
{
    public class LocationController : ApiController
    {
        [HttpGet]        
        public Models.Location GetLocation(string teste)
        {
            return new Models.Location() { Latitude = 10, Longitude = 20 };
        }
    }
}
