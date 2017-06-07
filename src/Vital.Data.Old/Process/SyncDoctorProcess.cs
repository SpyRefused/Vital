using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vital.Data.Old.Database;
using Vital.Doctor;

namespace Vital.Data.Old.Process
{
    public class SyncDoctorProcess
    {

        public bool Start()
        {
            try
            {
                using (var doctorVital = new DoctorVital())
                {
                    doctorVital.Database.Migrate();
                }

                //Medical Concepts
                SyncMedicalConcepts();
                //Certificates
                SyncDoctorCertificates();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            
        }

        private static void SyncDoctorCertificates()
        {
            using (var doctorVital = new DoctorVital())
            {
                using (var vitalDat = new VitalDat())
                {
                    var retens = vitalDat.Reten.Where(x => x.TipReten == 2).ToList();

                    foreach (var reten in retens)
                    {
                        var doctor = vitalDat.Medicos.FirstOrDefault(x => x.Medico == reten.CodReten);
                        if (doctor == null) continue;
                        var doctorTaxInformationCerficate =
                            new DoctorTaxInformationCerficate
                            {
                                Year = reten.AnyReten.ToString(),
                                Cif = doctor.NifMed,
                                Fee = (float) reten.IrpfReten,
                                Withholdings = (float) reten.ImportReten,
                                Name = string.IsNullOrEmpty(doctor.NomFiscMed)
                                    ? doctor.NomMed
                                    : doctor.NomFiscMed
                            };
                        doctorVital.Add(doctorTaxInformationCerficate);
                    }

                    doctorVital.SaveChanges();
                }
            }
        }

        private void SyncMedicalConcepts()
        {
            using (var doctorVital = new DoctorVital())
            {
                using (var vitalDat = new VitalDat())
                {
                    var medicalConcepts = vitalDat.CptMed.ToList();

                    foreach (var medicalConcept in medicalConcepts)
                    {
                        doctorVital.Add(new DoctorMedicalConcept
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
                    doctorVital.SaveChanges();
                }
            }
        }
    }
}
