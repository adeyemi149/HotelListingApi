using HotelCountry_Redo.Core.IRepository;
using HotelCountry_Redo.Core.Services;
using HotelCountry_Redo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelCountry_Redo.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/country")]
    [ApiController]
    public class CountryV2Controller : ControllerBase
    {
        private DatabaseContext _context;

        public CountryV2Controller(DatabaseContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = _context.Countries;
            return Ok(countries);
        }
    }
}
