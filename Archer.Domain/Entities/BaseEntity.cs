using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreateOn => DateTime.Now;
    }
}
