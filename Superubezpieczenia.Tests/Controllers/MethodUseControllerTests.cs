
using AutoMapper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Superubezpieczenia.Tests.Controllers
    {
    [TestFixture]
    public class MethodControllerTests
    {
        private Mock<IMethodUseService> _mockMethodUseService;
        private Mock<AutoMapper.IMapper> _mockMapper;
        private Mock<Logger.IMapper> _mockLog;


        [SetUp]
        public void SetUp()
        {
            _mockMethodUseService = new Mock<IMethodUseService>();
            _mockMapper = new Mock<AutoMapper.IMapper>();
            _mockLog = new Mock<Logger.IMapper>();

        }
        private MethodUseController CreateMethodUseController()
        {
            return new MethodUseController(
                _mockMethodUseService.Object,
                _mockMapper.Object,
                _mockLog.Object);
        }

        [Test]
        public async Task AllMethodUseTests()
        {
            // Arrange
            var methoduseController = this.CreateMethodUseController();


            // Act
            var result = await methoduseController.AllMethodUse();

            // Assert
            Assert.IsInstanceOf<IEnumerable<MethodUse>>(result);
        }
[Test]
        public void AddMethodUseTests()
        {
            // Arrange
            var methoduseController = this.CreateMethodUseController();
            MethodUseDTO methodUseDTO = new MethodUseDTO();

            // Act
            var result = methoduseController.AddMethodUse(methodUseDTO);

            // Assert
            Assert.IsInstanceOf<ActionResult<MethodUseVM>>(result);
        }

        [Test]
        public void DeleteMethodUseTests()
        {
            // Arrange
            var methoduseController = this.CreateMethodUseController();
            int id = 0;

            // Act
            var result = methoduseController.DeleteMethodUse(
                id);

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
        [Test]
        public void UpdateMethodUseTests()
        {
            // Arrange
            var methoduseController = this.CreateMethodUseController();
            int id = 0;
            MethodUseDTO methodUseDTO = new MethodUseDTO();

            // Act
            var result = methoduseController.UpdateMethodUse(methodUseDTO,
                id);

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
    }
}
