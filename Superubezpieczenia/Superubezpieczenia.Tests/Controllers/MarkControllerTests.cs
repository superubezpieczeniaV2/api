using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Persistence.Context;
using Superubezpieczenia.Persistence.Repositories;
using Superubezpieczenia.Services;

namespace Superubezpieczenia.Tests
{
    [TestClass]
    public class MarkControllerTests
    {
        private const string ConnectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=Superubezpieczenia;Trusted_Connection=True;MultipleActiveResultSets=true";

        private IMarkService _markService;
        private IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            _markService = Substitute.For<IMarkService>();
            _mapper = Substitute.For<IMapper>();
        }

        #region Unit tests

        [TestMethod, TestCategory("UnitTest")]
        public void AllMarks_GetData_DataReturned()
        {
            //Arrange
            var controller = MockController();

            //Act
            var result = controller.AllMarks();

            //Assert
            result.Should().NotBeNull();
        }

        //AddMark

        [TestMethod, TestCategory("UnitTest")]
        public void DeleteMark_IdInvalid_StatusNotFound()
        {
            //Arrange
            const int id = 0;

            var controller = MockController();

            //Act
            var result = controller.DeleteMark(id);

            //Assert
            _markService.DidNotReceive().DeleteMark(Arg.Any<Mark>());
            _markService.DidNotReceive().SaveChanges();
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DeleteMark_IdValid_StatusOk()
        {
            //Arrange
            const int id = 1;

            var mark = new Mark
            {
                IDMark = id,
                Name = "Volkswagen"
            };

            var controller = MockController();
            _markService.FindById(id).Returns(mark);

            //Act
            var result = controller.DeleteMark(id);

            //Assert
            _markService.Received(1).DeleteMark(Arg.Is<Mark>(x => x == mark));
            _markService.Received(1).SaveChanges();
            result.Should().BeOfType<OkResult>();
        }

        #endregion

        #region Integration tests

        [TestMethod, TestCategory("IntegrationTest")]
        public void AllMarks_ConnectionStringInvalid_ErrorReturned()
        {

        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void AllMarks_ConnectionStringValid_DataReturned()
        {
            //Arrange
            var context = new ApplicationDbContext(ConnectionString);
            var repository = new MarkRepository(context);
            var service = new MarkService(repository);
            var controller = new MarkController(service, null, null);

            //Act
            var result = controller.AllMarks();
            result.Wait();

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().ContainSingle(x => x.IDMark == 1 && x.Name == "Daewoo" && x.Value == 3);
        }

        #endregion

        private MarkController MockController()
        {
            return new MarkController(_markService, _mapper, null);
        }
    }
}
