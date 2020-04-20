using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demoecomerce
{
    public class DbConfig
    {
        public string MongoDbConnectionString { get; set; }
        public string MongoDbName { get; set; }
        public string Product { get; set; }
        public string User { get; set; }
    }
}
