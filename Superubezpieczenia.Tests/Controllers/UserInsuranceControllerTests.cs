using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Superubezpieczenia.Controllers;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Superubezpieczenia.Tests.Controllers
{
    [TestClass]
    public class UserInsuranceControllerTests
    {
        public IUserInsuranceService _userInsuranceService;

        [TestInitialize]
        public void Initialize()
        {
            _userInsuranceService = Substitute.For<IUserInsuranceService>();
            _userInsuranceService.FindUserInsurance(Arg.Is<string>(x => x == "User1"))
                .Returns(Task.FromResult((IEnumerable<Insurance>)new List<Insurance>()
                {
                    new Insurance { Id = "1" }
                })
            );
        }

        [TestMethod, TestCategory("UnitTest")]
        public void FindUserInsurance_ExistingUserInsurance_InsuranceReturned()
        {
            //Arrange  
            var user = "User1";
            var controller = new UserInsuranceController(_userInsuranceService, null);

            //Act
            var userInsurance = controller.FindUserInsurance(user).Result;

            //Asserts
            userInsurance.Should().ContainSingle(x => x.Id == "1");
        }

        [TestMethod, TestCategory("UnitTest")]
        public void FindUserInsurance_NonexistentUserInsurance_NothingReturned()
        {
            //Arrange  
            var user = "User2";
            var controller = new UserInsuranceController(_userInsuranceService, null);

            //Act
            var userInsurance = controller.FindUserInsurance(user).Result;

            //Asserts
            userInsurance.Should().BeEmpty();
        }
    }
}
