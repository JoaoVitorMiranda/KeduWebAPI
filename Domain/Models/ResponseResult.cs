using System;

namespace Domain.Models
{
    public class ResponseResult
    {
        public int EntityId { get; set; }
        public string ResultValue { get; set; }
        public bool IsError { get; set; }
        public bool NoData { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
