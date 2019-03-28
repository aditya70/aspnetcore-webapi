using System;
using System.Collections.Generic;

namespace DataAccess.EntityModels
{
    public partial class ExceptionLogs
    {
        public long Id { get; set; }
        public string ErrorId { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime? LoggedOn { get; set; }
        public string Url { get; set; }
        public string RequestIpaddress { get; set; }
        public string UserAgent { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
    }
}
