using System;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    [Serializable]
    public class Identity
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string Token { get; set; }
    }
}
