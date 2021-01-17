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
    public class TypeOwnerConntrollerTests
    {

        private Mock<ITypeOwnerService> _mockOwnerService;
        private Mock<IMapper> _mockMapper;
        private Mock<ILogService> _mockLog;

        [SetUp]
        public void SetUp()
        {

            this._mockOwnerService = new Mock<ITypeOwnerService>();
            this._mockMapper = new Mock<IMapper>();
            this._mockLog = new Mock<ILogService>();

        }
        private TypeOwnerController CreateTypeOwnerController()
        {

            return new TypeOwnerController(
                 this._mockOwnerService.Object,
                 this._mockMapper.Object,
                 this._mockLog.Object);


        }

        [Test]
        public void AddTypeOwnerTests()
        {
            // Arrange
            var typeownerController = this.CreateTypeOwnerController();
            TypeOwnerDTO typeOwnerDTO = new TypeOwnerDTO();
            //// Act
            var result = typeownerController.AddTypeOwner(typeOwnerDTO);
            //Assert
            _mockOwnerService.VerifyAll();
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkResult>();
        }
        [Test]
        public void DeleteTypeOwnerTests()

        {
            // Arrange
            var typeownerController = this.CreateTypeOwnerController();
            int id = 0;
            //Act
            var result = typeownerController.DeleteTypeOwner(id);
            //Assert
            _mockOwnerService.VerifyAll();

        }

        [Test]
        public void UpdateTypeOwnerTests()
        {
            //Arrange
            var typeownerController = this.CreateTypeOwnerController();
            TypeOwnerDTO typeOwnerDTO = new TypeOwnerDTO();
            int id = 0;
            //Act 
            var result = typeownerController.UpdateTypeOwner(
                typeOwnerDTO, id);
            //Assert
            _mockOwnerService.VerifyAll();
        }
    }
}