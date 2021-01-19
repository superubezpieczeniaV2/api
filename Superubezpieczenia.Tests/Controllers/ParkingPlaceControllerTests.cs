using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestClass]
    public class ParkingPlaceControllerTests
    {
        private IParkingPlaceService _parkingPlaceService;
        private AutoMapper.IMapper _mapper;
        private Logger.IMapper _log;

        private ParkingPlace _parkingPlace;
            
 [TestInitialize]
        public void Initialize()
        {
            _parkingPlaceService = Substitute.For<IParkingPlaceService>();
            _mapper = Substitute.For<AutoMapper.IMapper>();
            _log = Substitute.For<Logger.IMapper>();

            _parkingPlace = new ParkingPlace
            {
                IDParkingPlace = 1,
                Place = "dom"
            };
            _parkingPlaceService.AllParkingPlace()
.Returns(Task.FromResult((IEnumerable<ParkingPlace>)new List<ParkingPlace>()
                {
                    _parkingPlace
                })
            );

            _parkingPlaceService.FindById(Arg.Is<int>(x => x == 1))
                .Returns(_parkingPlace);
        }


        [TestMethod, TestCategory("UnitTest")]
        public void AllParkingPlace_ExistingParkingPlace_ParkingPlaceReturned()
        {
            //Arrange
            var controller = new ParkingPlaceController(_parkingPlaceService, _mapper, _log);

            //Act
            var result = controller.AllParkingPlace().Result;

            //Asserts
            result.Should().ContainSingle(x => x.IDParkingPlace == 1 && x.Place == "dom");
        }


         [TestMethod, TestCategory("UnitTest")]
        public void AddParkingPlace_NewParkingPlace_StatusOk()
        {
            //Arrange
            var controller = new ParkingPlaceController(_parkingPlaceService, _mapper, _log);
            var parkingPlace = new ParkingPlaceDTO { Place ="dom" };

            //Act
            var result = controller.AddParkingPlace(parkingPlace);

            //Asserts
            result.Result.Should().BeOfType<OkResult>();
            _parkingPlaceService.Received(1).AddParkingPlace(Arg.Any<ParkingPlace>());
            _parkingPlaceService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Dodano rodzaj miejsca parkingowego", nameof(ParkingPlaceController));
        }
        [TestMethod, TestCategory("UnitTest")]
        public void DeleteParkingPlace_NonexistentParkingPlace_StatusNotFound()
        {
            //Arrange
            var controller = new ParkingPlaceController(_parkingPlaceService, _mapper, _log);

            //Act
            var result = controller.DeleteParkingPlace(2);

            //Asserts
            result.Should().BeOfType<NotFoundResult>();
            _parkingPlaceService.DidNotReceive().DeleteParkingPlace(Arg.Any<ParkingPlace>());
            _parkingPlaceService.DidNotReceive().SaveChanges();
            _log.DidNotReceive().Save(Arg.Any<string>(), Arg.Any<string>(), nameof(ParkingPlaceController));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DeleteParkingPlace_ExistingParkingPlace_StatusOk()
        {
            //Arrange
            var controller = new ParkingPlaceController(_parkingPlaceService, _mapper, _log);

            //Act
            var result = controller.DeleteParkingPlace(1);

            //Asserts
            result.Should().BeOfType<OkResult>();
            _parkingPlaceService.Received(1).DeleteParkingPlace(Arg.Is<ParkingPlace>(x => x == _parkingPlace));
            _parkingPlaceService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Usunięto rodzaj miejsca parkingowego", nameof(ParkingPlaceController));
        }



        [TestMethod, TestCategory("UnitTest")]
        public void UpdateParkingPlace_NonexistentParkingPlace_StatusNotFound()
        {
            //Arrange
            var controller = new ParkingPlaceController(_parkingPlaceService,  _mapper, _log);
            var parkingPlace = new ParkingPlaceDTO { Place = "dom" };

            //Act
            var result = controller.UpdateParkingPlace(parkingPlace, 2);

            //Asserts
            result.Should().BeOfType<NotFoundResult>();
            _mapper.DidNotReceive().Map(Arg.Any<EnginePowerDTO>(), Arg.Any<ParkingPlace>());
            _parkingPlaceService.DidNotReceive().UpdateParkingPlace(Arg.Any<ParkingPlace>());
            _parkingPlaceService.DidNotReceive().SaveChanges();
            _log.DidNotReceive().Save(Arg.Any<string>(), Arg.Any<string>(), nameof(ParkingPlaceController));
        }


        [TestMethod, TestCategory("UnitTest")]
        public void UpdateParkingPlace_ExistingParkingPlace_StatusOk()
        {
            //Arrange
            var controller = new ParkingPlaceController(_parkingPlaceService, _mapper, _log);
            var parkingPlace = new ParkingPlaceDTO { Place = "dom" };

            //Act
            var result = controller.UpdateParkingPlace(parkingPlace, 1);

            //Asserts
            result.Should().BeOfType<OkResult>();
            _mapper.Received().Map(parkingPlace, _parkingPlace);
            _parkingPlaceService.Received(1).UpdateParkingPlace(Arg.Is<ParkingPlace>(x => x ==_parkingPlace));
            _parkingPlaceService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Edytowano rodzaj miejsca parkingowego", nameof(ParkingPlaceController));
        }
    }
}

