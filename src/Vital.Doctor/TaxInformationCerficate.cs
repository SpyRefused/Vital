using System;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class TaxInformationCerficate
    {
        public TaxInformationCerficate()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cif { get; set; }
        public string Year { get; set; }
        public float Fee { get; set; }
        public float Withholdings { get; set; }
        }
    }
