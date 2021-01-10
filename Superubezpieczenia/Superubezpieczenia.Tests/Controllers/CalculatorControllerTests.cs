using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Persistence.Repositories;
using System;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        public ICalculatorService _calculatorService;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorService = Substitute.For<ICalculatorService>();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void InsurancePrice_ProperData_StatusOK()
        {
            //Arrange
            var controller = new CalculatorController(_calculatorService);
            CalculatorDTO calculatorDTO = new CalculatorDTO();

            //Act
            var result = controller.InsurancePrice(calculatorDTO);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void InsurancePrice_ImproperData_ExceptionThrown()
        {
            //Arrange
            _calculatorService.InsurancePrice(Arg.Any<CalculatorDTO>())
                .Returns(x => throw new Exception());

            var controller = new CalculatorController(_calculatorService);
            CalculatorDTO calculatorDTO = new CalculatorDTO();

            //Act
            Action act = () => controller.InsurancePrice(calculatorDTO);

            //Assert
            act.Should().Throw<Exception>();
        }
    }
}
