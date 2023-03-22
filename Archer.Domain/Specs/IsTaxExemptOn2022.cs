using Archer.Domain.Entities;

namespace Archer.Domain.Specs
{
    public class IsTaxExemptOn2022 : ISpec<VehicleEntity>
    {
        public bool IsSatisfiedBy(VehicleEntity candidate)
        {
            return
                (candidate.ModelYear < (DateTime.Now.Year - 20) ? true : false);
        }
    }
}
