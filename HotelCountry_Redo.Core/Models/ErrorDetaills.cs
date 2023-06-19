
using System.Text.Json;

namespace HotelCountry_Redo.Core.Models
{
    public class ErrorDetaills
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
