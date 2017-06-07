using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vital.Data.Old.Process;
using Vital.Doctor;

namespace Vital.Api.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private static readonly Random Random = new Random();

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IEnumerable<DoctorResume> GetDoctorResume(int idDoctor)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var doctorResume = new List<DoctorResume>();

            for (var i = 0; i < 15; i++)
            {
                var observations = new string(Enumerable.Repeat(chars, 10)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());

                doctorResume.Add(
                    new DoctorResume
                    {
                        Id = new Guid(),
                        IdDoctor = idDoctor,
                        Year = 2017,
                        Month = 4,
                        Observations = observations,
                        Resume = new List<Resume>
                        {
                            new Resume
                            {
                                SettlementCode = "sklajdkjasd1",
                                Insureds = "hola1",
                                Receipt = "holas1",
                                RegistersUnregisters = "ajkdasjd",
                                ServiceDetails = "ksajdkasjd"
                            },
                            new Resume
                            {
                                SettlementCode = "sklajdkjasd2",
                                Insureds = "22222",
                                Receipt = "2222222",
                                RegistersUnregisters = "ajkdasjd",
                                ServiceDetails = "ksajdkasjd"
                            }
                        },
                        DoctorTaxInformation = new List<DoctorTaxInformation>()
                    });
            }
            doctorResume[3].DoctorTaxInformation = new List<DoctorTaxInformation>
            {
                new DoctorTaxInformation {Year = 2017, Certificate = "kdjfdskjf", Id = Guid.NewGuid()}
            };
            return doctorResume;

        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public bool StartProcess()
        {
            var doctorVitalProcess = new SyncDoctorProcess();

            return doctorVitalProcess.Start();
        }
    }
}