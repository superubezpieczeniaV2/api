using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
using Superubezpieczenia.Resources.DTO;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestFixture]
    public class TypeInsuranceConntrollerTests
    {

        private Mock<ITypeInsuranceService> _mocktypeInsuranceService;
        private Mock<IMapper> _mockMapper;
        private Mock<ILogService> _mockLog;

        [SetUp]
        public void SetUp()
        {

            this._mocktypeInsuranceService = new Mock<ITypeInsuranceService>();
            this._mockMapper = new Mock<IMapper>();
            this._mockLog = new Mock<ILogService>();

        }
        private TypeInsuranceController CreateTypeInsuranceController()
        {

            return new TypeInsuranceController(
                 this._mocktypeInsuranceService.Object,
                 this._mockMapper.Object,
                 this._mockLog.Object);


        }

        [Test]
        public void AddTypeInsuranceTests()
        {
            // Arrange
            var typeinsuranceController = this.CreateTypeInsuranceController();
            TypeInsuranceDTO typeInsuranceDTO = new TypeInsuranceDTO();
            //// Act
            var result = typeinsuranceController.AddTypeInsurance(typeInsuranceDTO);
            //Assert
            _mocktypeInsuranceService.VerifyAll();
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkResult>();
        }
        [Test]
        public void DeleteTypeInsuranceTests()

        {
            // Arrange
            var typeinsuranceController = this.CreateTypeInsuranceController();
            int id = 0;
            //Act
            var result = typeinsuranceController.DeleteTypeInsurance(id);
            //Assert
            _mocktypeInsuranceService.VerifyAll();

        }

        [Test]
        public void UpdateTypeInsuranceTests()
        {
            //Arrange
            var typeinsuranceController = this.CreateTypeInsuranceController();
            TypeInsuranceDTO typeInsuranceDTO = new TypeInsuranceDTO();
            int id = 0;
            //Act 
            var result = typeinsuranceController.UpdateTypeInsurance(
                typeInsuranceDTO, id);
            //Assert
            _mocktypeInsuranceService.VerifyAll();
        }
    }
}