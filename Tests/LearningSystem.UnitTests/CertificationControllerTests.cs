using LearningSystem.Data;
using LearningSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LearningSystem.UnitTests
{
    [TestFixture]
    public class CertificationControllerTests
    {
        [Test]
        public void ShouldReturnDefaultView()
        {
            var fakeRepository = new Mock<ILearningSystemData>();

            var certification = new CertificationController(fakeRepository.Object);

            certification.WithCallTo(x => x.Info()).ShouldRenderDefaultView();
        }
    }
}
