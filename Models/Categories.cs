using System.Text.Json.Serialization;

namespace Momus.Models
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum Categories
  {
    Fiction,
    Nonfiction,
    Poetry,
    Comics
  }
}