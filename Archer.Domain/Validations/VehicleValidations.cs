
using Archer.Domain.Entities;
using Archer.Domain.Notifications;
using Archer.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Domain.Validations
{
    public class VehicleValidations : IValidate
    {
        private readonly VehicleEntity _vehicle;
        public VehicleValidations(VehicleEntity vehicle)
        {
            this._vehicle = vehicle;
        }

        public VehicleValidations MinNameLength()
        {
            if (_vehicle.Name.Length < 3)
                _vehicle.PullNotification(
                    new Notification(
                        "Name", "O nome deve conter um mínimo de 3 caracteres"));

            return this;
        }

        public VehicleValidations MaxNameLength()
        {
            if (_vehicle.Name.Length > 12)
                _vehicle.PullNotification(
                    new Notification(
                        "Name", "Quantidade máxima de caracteres ultrapassada"));

            return this;
        }

        public bool IsValid()
        {
            return (_vehicle.Notifications.Count == 0 ? true : false);
        }


    }
}
