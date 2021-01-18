using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using NUnit.Framework;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
using Superubezpieczenia.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace Superubezpieczenia.Tests.Controllers
{
    [TestFixture]
    public class TypeInsuranceControllerTests
    {
        private Mock<ITypeInsuranceService> _mockTypeInsuranceService;
        private Mock<IMapper> _mockMapper;
        private Mock<ILogService> _mockLog;

        [SetUp]
        public void SetUp()
        {

            this._mockTypeInsuranceService = new Mock<ITypeInsuranceService>();
            this._mockMapper = new Mock<IMapper>();
            this._mockLog = new Mock<ILogService>();
        }

        private TypeInsuranceController CreateTypeInsuranceController()
        {

            return new TypeInsuranceController(
                 this._mockTypeInsuranceService.Object,
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
            _mockTypeInsuranceService.VerifyAll();
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
            _mockTypeInsuranceService.VerifyAll();
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
        _mockTypeInsuranceService.VerifyAll();
    }
}
}


