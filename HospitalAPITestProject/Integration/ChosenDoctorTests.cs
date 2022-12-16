using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Patient;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using HospitalLibrary.Core.User;
using HospitalLibrary.Core.EmailSender;

namespace HospitalTests.Integration
{
    public class ChosenDoctorTests : BaseIntegrationTest
    {

        public ChosenDoctorTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailSendService>());

        }


        [Fact]
        public void Retrieves_doctors_with_minimal_number_of_patients()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            List<string> resultIds = new List<string>();

            var result = ((OkObjectResult)controller.GetDoctorsWithLeastPatients()).Value as List<Doctor>;

            foreach (Doctor doctor in result)
            {
                resultIds.Add(doctor.Id);
            }

            Assert.Equal(new List<string>(){"2","3","4" }, resultIds);
        }





    }
}
