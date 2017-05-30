using System;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorTaxInformation
    {
        public DoctorTaxInformation()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Certificate { get; set; }               
    }
}
