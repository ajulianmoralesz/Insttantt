using System.Text.Json.Serialization;

namespace Insttantt.Steps.Models
{
    public class OperationModel
    {
        [JsonPropertyName("F-0001")]
        public int X { get; set; }
        [JsonPropertyName("F-0002")]
        public int Y { get; set; }
    }
}
