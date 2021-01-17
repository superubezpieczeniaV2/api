using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
using Superubezpieczenia.Resources.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestClass]
    public class EnginePowerControllerTests
    {
        private IEnginePowerService _enginePowerService;
        private IMapper _mapper;
        private ILogService _log;

        private EnginePower _enginePower;

        [TestInitialize]
        public void Initialize()
        {
            _enginePowerService = Substitute.For<IEnginePowerService>();
            _mapper = Substitute.For<IMapper>();
            _log = Substitute.For<ILogService>();

            _enginePower = new EnginePower
            {
                IDEnginePower = 1,
                Power = 10
            };

            _enginePowerService.AllEnginePower()
                .Returns(Task.FromResult((IEnumerable<EnginePower>)new List<EnginePower>()
                {
                    _enginePower
                })
            );

            _enginePowerService.FindById(Arg.Is<int>(x => x == 1))
                .Returns(_enginePower);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void AllEnginePower_ExistingEnginePower_EnginePowerReturned()
        {
            //Arrange
            var controller = new EnginePowerController(_enginePowerService, _mapper, _log);

            //Act
            var result = controller.AllEnginePower().Result;

            //Asserts
            result.Should().ContainSingle(x => x.IDEnginePower == 1 && x.Power == 10);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void AddEnginePower_NewEnginePower_StatusOk()
        {
            //Arrange
            var controller = new EnginePowerController(_enginePowerService, _mapper, _log);
            var enginePower = new EnginePowerDTO { Power = 10 };

            //Act
            var result = controller.AddEnginePower(enginePower);

            //Asserts
            result.Result.Should().BeOfType<OkResult>();
            _enginePowerService.Received(1).AddEnginePower(Arg.Any<EnginePower>());
            _enginePowerService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Dodano rodzaj paliwa", nameof(EnginePowerController));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DeleteEnginePower_NonexistentEnginePower_StatusNotFound()
        {
            //Arrange
            var controller = new EnginePowerController(_enginePowerService, _mapper, _log);

            //Act
            var result = controller.DeleteEnginePower(2);

            //Asserts
            result.Should().BeOfType<NotFoundResult>();
            _enginePowerService.DidNotReceive().DeleteEnginePower(Arg.Any<EnginePower>());
            _enginePowerService.DidNotReceive().SaveChanges();
            _log.DidNotReceive().Save(Arg.Any<string>(), Arg.Any<string>(), nameof(EnginePowerController));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DeleteEnginePower_ExistingEnginePower_StatusOk()
        {
            //Arrange
            var controller = new EnginePowerController(_enginePowerService, _mapper, _log);

            //Act
            var result = controller.DeleteEnginePower(1);

            //Asserts
            result.Should().BeOfType<OkResult>();
            _enginePowerService.Received(1).DeleteEnginePower(Arg.Is<EnginePower>(x => x == _enginePower));
            _enginePowerService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Usunięto rodzaj paliwa", nameof(EnginePowerController));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void UpdateEnginePower_NonexistentEnginePower_StatusNotFound()
        {
            //Arrange
            var controller = new EnginePowerController(_enginePowerService, _mapper, _log);
            var enginePower = new EnginePowerDTO { Power = 10 };

            //Act
            var result = controller.UpdateEnginePower(enginePower, 2);

            //Asserts
            result.Should().BeOfType<NotFoundResult>();
            _mapper.DidNotReceive().Map(Arg.Any<EnginePowerDTO>(), Arg.Any<EnginePower>());
            _enginePowerService.DidNotReceive().UpdateEnginePower(Arg.Any<EnginePower>());
            _enginePowerService.DidNotReceive().SaveChanges();
            _log.DidNotReceive().Save(Arg.Any<string>(), Arg.Any<string>(), nameof(EnginePowerController));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void UpdateEnginePower_ExistingEnginePower_StatusOk()
        {
            //Arrange
            var controller = new EnginePowerController(_enginePowerService, _mapper, _log);
            var enginePower = new EnginePowerDTO { Power = 10 };

            //Act
            var result = controller.UpdateEnginePower(enginePower, 1);

            //Asserts
            result.Should().BeOfType<OkResult>();
            _mapper.Received().Map(enginePower, _enginePower);
            _enginePowerService.Received(1).UpdateEnginePower(Arg.Is<EnginePower>(x => x == _enginePower));
            _enginePowerService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Edytowano rodzaj paliwa", nameof(EnginePowerController));
        }
    }
}
