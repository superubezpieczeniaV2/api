using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using NUnit.Framework;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestClass]
    class InsuranceControllerTests
    {
        public class InsurancePowerControllerTests
        {
            private Mock<IInsuranceService> _mockInsuranceService;
            private Mock<IMapper> _mockMapper;


            [SetUp]
            public void SetUp()
            {
                this._mockInsuranceService = new Mock<IInsuranceService>();
                this._mockMapper = new Mock<IMapper>();
            }
            private InsuranceController CreateInsuranceController()
            {

                return new InsuranceController(

                    this._mockInsuranceService.Object,
                    this._mockMapper.Object);
            }

            [Test]
            public void AddInsuranceTests()
            {
                // Arrange
                var insuranceController = this.CreateInsuranceController();
                InsuranceDTO insuranceDTO = new InsuranceDTO();
                //// Act
                var result = insuranceController.AddInsurance(insuranceDTO);
                //Assert
                _mockInsuranceService.VerifyAll();
                result.Should().NotBeNull();
                result.Result.Should().BeOfType<OkResult>();
            }
            [Test]
            public void DeleteInsuranceTests()

            {
                // Arrange
                var insuranceController = this.CreateInsuranceController();
                int id = 0;

                //Act
                var result = insuranceController.DeleteInsurance(id);
                //Assert 
                _mockInsuranceService.VerifyAll();
            }

            [Test]
            public void UpdateInsuranceTests()
            {
                // Arrange
                var insuranceController = this.CreateInsuranceController();
                InsuranceDTO insuranceDTO = new InsuranceDTO();
                int id = 1;
                //Act
                var result = insuranceController.UpdateInsurance(insuranceDTO, id);
                //Assert 
                _mockInsuranceService.VerifyAll();


            }
        }
    }
}




