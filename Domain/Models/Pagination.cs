using System;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    [Serializable]
    public class Pagination : Identity
    {
        [JsonIgnore]
        public int Page { get; set; } = 1;

        [JsonIgnore]
        public int PageSize { get; set; } = 10;

        [JsonIgnore]
        public int PageTotal { get; set; } = 0;
    }
}
