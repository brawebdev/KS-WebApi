using AutoMapper;
using KS.API;
using KS.API.Controllers.Authorization;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.MockManagers.Authorization;
using KS.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KS.UnitTests
{
    [TestClass]
    public class RegisterControllerTests
    {
        private RegisterController _controller;
        private MockRegisterUserManager _manager;

        [TestInitialize]
        public void Arrange()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _manager = new MockRegisterUserManager{ReturnValue = Task.FromResult(true)};
            _controller = new RegisterController(_manager, mapper);
        }

        [TestMethod]
        public void RegisterController_Register_ShouldHitManager()
        {
            var userRequest = new NewUserCreateRequest {UserName = "Ben", Password = "Stuff"};

            var result = _controller.Register(userRequest);

            Assert.AreEqual(1, _manager.CallCount);
        }

        [TestMethod]
        public void RegisterController_Register_ShouldReturnStatusCode()
        {
            var userRequest = new NewUserCreateRequest { UserName = "Ben", Password = "Stuff" };

            var actual = (StatusCodeResult)_controller.Register(userRequest).Result;
            var expected = (int)HttpStatusCode.Created;

            Assert.AreEqual(expected, actual.StatusCode);
        }
    }
}
