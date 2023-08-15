using System.Text.Json.Serialization;

namespace Insttantt.Steps.Models
{
    public class CompaundOperationModel
    {
        [JsonPropertyName("F-0003")]
        public int W { get; set; }
        [JsonPropertyName("F-0004")]
        public int X { get; set; }
        [JsonPropertyName("F-0005")]
        public int Y { get; set; }
        [JsonPropertyName("F-0006")]
        public int Z { get; set; }
        
    }
}
