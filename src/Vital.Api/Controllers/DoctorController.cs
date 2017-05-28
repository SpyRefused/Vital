using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vital.Doctor;

namespace Vital.Api.Controllers
{
    public class DoctorController : Controller
    {
        public IEnumerable<DoctorResume> GetDoctorResume(int idDoctor)
        {
            var doctorResume = new List<DoctorResume>();

            for (var i = 0; i < 15; i++)
            {
                doctorResume.Add(
                    new DoctorResume
                    {
                        Id = new Guid(),
                        IdDoctor = idDoctor,
                        Year = 2017,
                        Month = 4
                    });
            }
            return doctorResume;

        }
    }
}