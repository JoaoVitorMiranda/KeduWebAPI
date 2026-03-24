using System;

namespace Domain.Models
{
    [Serializable]
    public class Pagination : Identity
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageTotal { get; set; } = 0;
    }
}
