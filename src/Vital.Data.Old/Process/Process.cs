using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vital.Data.Old.Database;
using Vital.Data.Old.Entities;
using Vital.Doctor;

namespace Vital.Data.Old.Process
{
    public class Process
    {
        private VitalDat _vitalDat;
        private DoctorVital _doctorVital;

        public bool Start()
        {
            _vitalDat = new VitalDat();
            _doctorVital = new DoctorVital();

            _doctorVital.Database.Migrate();

            var medicalConcepts = _vitalDat.CptMed.ToList();

            foreach (var medicalConcept in medicalConcepts)
            {
                _doctorVital.Add(new DoctorMedicalConcept
                {
                    Resources = new List<DoctorMedicalConceptResources>
                    {
                        new DoctorMedicalConceptResources
                        {
                            Key = "NomCpt1",
                            Language = "es",
                            Value = medicalConcept.NomCpt1
                        },
                        new DoctorMedicalConceptResources
                        {
                            Key = "NomCpt1",
                            Language = "ca",
                            Value = medicalConcept.NomCpt2
                        },
                        new DoctorMedicalConceptResources
                        {
                            Key = "NomCptExt1",
                            Language = "es",
                            Value = medicalConcept.NomCptExt1
                        },
                        new DoctorMedicalConceptResources
                        {
                            Key = "NomCptExt2",
                            Language = "ca",
                            Value = medicalConcept.NomCptExt2
                        }
                    }
                });
            }

            _doctorVital.SaveChanges();
            return true;
        }
    }
}
