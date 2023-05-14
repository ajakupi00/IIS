using Newtonsoft.Json;

namespace UI.Models
{
    public class Root
    {
        public string Force { get; set; }
        public string Name { get; set; }

        [JsonProperty("Primary Muscles")]
        public List<string> PrimaryMuscles { get; set; }
        public List<string> SecondaryMuscles { get; set; }
        public string Type { get; set; }

        [JsonProperty("Workout Type")]
        public List<string> WorkoutType { get; set; }

        [JsonProperty("Youtube link")]
        public string Youtubelink { get; set; }
    }
}
