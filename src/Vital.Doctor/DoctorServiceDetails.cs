using System;
using System.Collections.Generic;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorServiceDetails
    {
        public DoctorServiceDetails()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public int IdDoctor { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Name { get; set; }
        public string Cif { get; set; }
        public IList<Service> Services { get; set; }
    }

    public class Service
    {
        public string Reference { get; set; }
        public string InsuredKey { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Operation { get; set; }
        public string Expedient { get; set; }
        public string Esp { get; set; }
        public string Concept { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Cost { get; set; }
    }
}