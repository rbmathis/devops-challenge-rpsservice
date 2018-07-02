using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RpsService.UnitTest.Controllers
{
    [TestClass]
    public class VersionTests
    {
        [TestMethod]
        public void GetReturnsValidVersionResult()
        {
            var version = new RPSService.Controllers.VersionController();

            var result = version.Get() as OkObjectResult;
            Assert.IsFalse(string.IsNullOrEmpty((string)result.Value), "Received empty version for RpsService");
        }
    }
}
