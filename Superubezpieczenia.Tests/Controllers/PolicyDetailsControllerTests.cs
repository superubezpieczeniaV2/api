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
    public class PolicyDetailsControllerTests
    {
        private IPolicyDetailsService _policyDetailsService;
        private AutoMapper.IMapper _mapper;
        private Logger.IMapper _log;

        private PolicyDetails _policyDetails;

        [TestInitialize]
        public void Initialize()
        {
            _policyDetailsService = Substitute.For<IPolicyDetailsService>();
            _mapper = Substitute.For<AutoMapper.IMapper>();
            _log = Substitute.For<Logger.IMapper>();

            _policyDetails = new PolicyDetails

            {
                IDPolicyDetails = 1,
                IDTypeFuel = 4
            };


            _policyDetailsService.AllPolicys()
                           .Returns(Task.FromResult((IEnumerable<PolicyDetails>)new List<PolicyDetails>()
                           {
                    _policyDetails
                           })
                       );

            _policyDetailsService.FindById(Arg.Is<int>(x => x == 1))
                .Returns(_policyDetails);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void AllPolicys_ExistingPolicyDetails_PolicyDetailsReturned()
        {
            //Arrange
            var controller = new PolicyDetailsController(_policyDetailsService, _mapper, _log);

            //Act
            var result = controller.AllPolicys().Result;

            //Asserts
            result.Should().ContainSingle(x => x.IDPolicyDetails == 1 && x.IDTypeFuel == 4);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void AddPolicyDetails_NewPolicyDetails_StatusOk()
        {
            //Arrange
            var controller = new PolicyDetailsController(_policyDetailsService, _mapper, _log);
            var policyDetails = new PolicyDetailsDTO { IDTypeFuel = 4 };

            //Act
            var result = controller.AddPolicyDetails(policyDetails);

            //Asserts
            result.Result.Should().BeOfType<OkResult>();
            _policyDetailsService.Received(1).AddPolicyDetails(Arg.Any<PolicyDetails>());
            _policyDetailsService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Dodano szczegóły polisy", nameof(PolicyDetailsController));
        }


        [TestMethod, TestCategory("UnitTest")]
        public void DeletePolicyDetails_NonexistentPolicyDetails_StatusNotFound()
        {
            //Arrange
            var controller = new PolicyDetailsController(_policyDetailsService, _mapper, _log);

            //Act
            var result = controller.DeletePolicyDetails(2);

            //Asserts
            result.Should().BeOfType<NotFoundResult>();
            _policyDetailsService.DidNotReceive().DeletePolicyDetails(Arg.Any<PolicyDetails>());
            _policyDetailsService.DidNotReceive().SaveChanges();
            _log.DidNotReceive().Save(Arg.Any<string>(), Arg.Any<string>(), nameof(PolicyDetailsController));
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DeletePolicyDetails_ExistingPolicyDetails_StatusOk()
        {
            //Arrange
            var controller = new PolicyDetailsController(_policyDetailsService, _mapper, _log);

            //Act
            var result = controller.DeletePolicyDetails(1);

            //Asserts
            result.Should().BeOfType<OkResult>();
            _policyDetailsService.Received(1).DeletePolicyDetails(Arg.Is<PolicyDetails>(x => x == _policyDetails));
            _policyDetailsService.Received(1).SaveChanges();
            _log.Received(1).Save(Arg.Any<string>(), "Usunięto szczegóły polisy", nameof(PolicyDetailsController));
        }
    }
}