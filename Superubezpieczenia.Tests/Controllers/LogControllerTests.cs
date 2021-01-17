using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Logger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestClass]
    public class LogControllerTests
    {
        private ILogService _logService;

        [TestInitialize]
        public void Initialize()
        {
            _logService = Substitute.For<ILogService>();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void All_NothingLogged_EmptyLogsReturned()
        {
            //Arrange
            var controller = new LogController(_logService);

            //Act
            var result = controller.All().Result;

            //Asserts
            result.Should().BeEmpty();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void All_SomethingLogged_FullLogsReturned()
        {
            //Arrange
            var controller = new LogController(_logService);
            _logService.All().Returns(Task.FromResult<IEnumerable<Log>>(new List<Log>
            {
                new Log
                {
                    IDLogger = 1,
                    ActionName = "Save"
                }
            }));

            //Act
            var result = controller.All().Result;

            //Asserts
            result.Should().ContainSingle(x => x.IDLogger == 1 && x.ActionName == "Save");
        }
    }
}
