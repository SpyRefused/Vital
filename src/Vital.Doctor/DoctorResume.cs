﻿using System;
using System.Collections;
using System.Collections.Generic;
using Vital.Infrastructure.Utils;

namespace Vital.Doctor
{
    public class DoctorResume
    {
        public DoctorResume()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Guid Id { get; set; }
        public int IdDoctor { get; set; }
        public int Year { get; set; }
        public int  Month { get; set; }
        public string Observations { get; set; }
        public IList<Resume> Resume {get; set;}
        public IList<DoctorTaxInformation> DoctorTaxInformation { get; set; }
        
    }

    public class Resume
    {
        public string SettlementCode { get; set; }
        public string Receipt { get; set; }
        public string ServiceDetails { get; set; }
        public string Insureds { get; set; }
        public string RegistersUnregisters { get; set; }
    }
}
