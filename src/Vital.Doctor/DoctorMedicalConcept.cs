using System;
using System.Collections.Generic;
using System.Text;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorMedicalConcept
    {
        public DoctorMedicalConcept()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }

        public List<DoctorMedicalConceptResources> Resources { get; set; }
    }
}
