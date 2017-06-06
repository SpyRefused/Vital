using System;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorReceipt
    {
        public DoctorReceipt()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public int IdDoctor { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Name { get; set; }
        public string Cif { get; set; }
        public float CostsOfServices { get; set; }
        public float Irpf { get; set; }
        public float Net { get; set; }
    }
}