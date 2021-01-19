using AutoMapper;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestFixture]
    public class ModelControllerTests
    {
        private Mock<IMethodService> _mockModelService;
        private Mock<AutoMapper.IMapper> _mockMapper;
        private Mock<Logger.IMapper> _mockLog;


        [SetUp]
        public void SetUp()
        {
            _mockModelService = new Mock<IMethodService>();
            _mockMapper = new Mock<AutoMapper.IMapper>();
            _mockLog = new Mock<Logger.IMapper>();

        }
        private ModelController CreateModelController()
        {
            return new ModelController(

                _mockModelService.Object,
                _mockMapper.Object,
                _mockLog.Object);
        }
      
        [Test]
        public async Task AllModelsTests()
        {
            // Arrange
            var modelController = this.CreateModelController();
            

            // Act
            var result = await modelController.AllModels();

            // Assert
            Assert.IsInstanceOf<IEnumerable<Model>>(result);
        }


        [Test]
        public async Task FindByMarkTests()
        {
            // Arrange
            var modelController = this.CreateModelController();
            int id = 0;

            // Act
            var result = await modelController.FindByMark(id);

            // Assert
            Assert.IsInstanceOf<IEnumerable<Model>>(result);
        }

        [Test]
        public void AddModelTests()
        {
            // Arrange
            var modelController = this.CreateModelController();
            ModelDTO modelDTO = new ModelDTO();

            // Act
            var result = modelController.AddModel(modelDTO);

            // Assert
            Assert.IsInstanceOf<ActionResult<ModelVM>>(result);
        }

        [Test]
        public void DeleteModelTests()
        {
            // Arrange
            var modelController = this.CreateModelController();
            int id = 0;

            // Act
            var result = modelController.DeleteModel(
                id);

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
        [Test]
        public void UpdateModelTests()
        {
            // Arrange
            var modelController = this.CreateModelController();
            int id = 0;
            ModelDTO modelDTO = new ModelDTO();

            // Act
            var result = modelController.UpdateModel(modelDTO,
                id);

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
    }
}

