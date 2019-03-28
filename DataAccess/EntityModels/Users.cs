using System;
using System.Collections.Generic;

namespace DataAccess.EntityModels
{
    public partial class Users
    {
        public int Id { get; set; }
        public string AdAccountDomain { get; set; }
        public string AdAccountName { get; set; }
    }
}
