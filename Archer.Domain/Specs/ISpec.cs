using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Domain.Specs
{
    public interface ISpec<in T> where T : class
    {
        bool IsSatisfiedBy(T candidate);
    }
}
