using System;
using System.Collections.Generic;
using System.Linq;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.Report;
using IntegrationTests.Integration;
using IntegrationTests.Setup;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Nest;
using Xunit;
using Xunit.Sdk;

namespace IntegrationTests
{
    public class ConfigurationTests : BaseIntegrationTest
    {
        public ConfigurationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private Mock<IReportGeneratorService> _reportGeneratorService = new Mock<IReportGeneratorService>();
        private static ReportController SetupController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IReportService>());
        }
        [Fact]
        public void Create_report()
        {
            
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            ReportDTO result = new ReportDTO(Period.Daily, new Guid());
            controller.Create(result);
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Update_report()
        {
            
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            ReportDTO resultDto = new ReportDTO(Period.EveryTwoMonths, new Guid("6799e115-a7b0-4d37-be5e-ecbb1929b3a2"));
            Assert.NotNull(controller.Update(resultDto));

        }
        
        [Fact]
        public void Read_report()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            ActionResult result = controller.GetAll();
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Get_information_for_report()
        {

        }
        
        [Fact]
        public void Generating_pdf()
        {

            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var report = controller.GetById(new Guid("204932d0-7956-4199-9e0d-cf2903c9903b"));
            _reportGeneratorService.Verify(result => result.GeneratePdf(report));
            //Assert
        }  
        
    }
}
