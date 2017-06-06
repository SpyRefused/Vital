using System;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorObservations
    {
        public DoctorObservations()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public int IdDoctor { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Name { get; set; }
        public string Cif { get; set; }
        public string Observation { get; set; }

    }
}
