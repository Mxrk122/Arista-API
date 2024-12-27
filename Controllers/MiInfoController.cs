using Microsoft.AspNetCore.Mvc;
using myapi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace myapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiInfoController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MiInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("mi-info")]
        public async Task<IActionResult> GetInfo([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Datos inválidos.");
            }

            // Obtener los últimos 5 dígitos del código postal
            string postalCode = cliente.PostalCode.Substring(cliente.PostalCode.Length - 5);

            // Realizar la llamada al servicio de Zippopotam para obtener latitud y longitud
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"http://api.zippopotam.us/us/{postalCode}");
            var data = JsonConvert.DeserializeObject<dynamic>(response);

            // Obtener la latitud y longitud de la respuesta del servicio
            if (data.places != null && data.places.Count > 0)
            {
                cliente.Latitud = data.places[0].latitude;
                cliente.Longitud = data.places[0].longitude;
            }
            else
            {
                return BadRequest("No se pudieron obtener las coordenadas.");
            }

            // Retornar los datos con latitud y longitud añadidos
            return Ok(cliente);
        }
    }
}
