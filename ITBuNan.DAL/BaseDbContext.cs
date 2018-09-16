using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBuNan.DAL
{
    public class BaseDbContext:DbContext
    {
        public BaseDbContext() : base("name=ITBuNanEntities")
        {
        }
        
    }
    
}
