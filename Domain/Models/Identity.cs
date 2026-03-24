using System;

namespace Domain.Models
{
    [Serializable]
    public class Identity
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
