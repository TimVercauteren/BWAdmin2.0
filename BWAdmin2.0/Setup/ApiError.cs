using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BWAdmin2._0.Setup
{
    public class ApiError
    {
        [JsonProperty("problemType")]
        [DataMember(Name = "problemType", Order = 100, EmitDefaultValue = false)]
        public string ProblemTypeUrl { get; set; }

        [JsonProperty("title")]
        [DataMember(Name = "title", Order = 200, EmitDefaultValue = false)]
        public string Title { get; set; }

        [JsonProperty("detail")]
        [DataMember(Name = "detail", Order = 300, EmitDefaultValue = false)]
        public string Detail { get; set; }

        [JsonProperty("httpStatus")]
        [DataMember(Name = "httpStatus", Order = 400, EmitDefaultValue = false)]
        public string HttpStatus { get; set; }

        [JsonProperty("details")]
        [DataMember(Name = "details", Order = 500, EmitDefaultValue = false)]
        public string Details { get; set; }

        [JsonProperty("problemInstance")]
        [DataMember(Name = "problemInstance", Order = 600, EmitDefaultValue = false)]
        public string ProblemInstance { get; set; }
    }
}
