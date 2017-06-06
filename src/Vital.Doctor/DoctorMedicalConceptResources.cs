using System;
using System.Collections.Generic;
using System.Text;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorMedicalConceptResources
    {
        public DoctorMedicalConceptResources()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }
    }
}
