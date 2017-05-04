using LearningSystem.Data;
using LearningSystem.Services.Infrastructure.Contracts;
using LearningSystem.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LearningSystem.UnitTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexShouldReturnDefaultView()
        {
            var fakeRepository = new Mock<ILearningSystemData>();
            var fakeHomeService = new Mock<IHomeService>();

            var certification = new HomeController(fakeRepository.Object, fakeHomeService.Object);

            certification.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void ContactsShouldReturnDefaultView()
        {
            var fakeRepository = new Mock<ILearningSystemData>();
            var fakeHomeService = new Mock<IHomeService>();

            var certification = new HomeController(fakeRepository.Object, fakeHomeService.Object);

            certification.WithCallTo(x => x.Contact()).ShouldRenderDefaultView();
        }

        [Test]
        public void ErrorShouldReturnDefaultView()
        {
            var fakeRepository = new Mock<ILearningSystemData>();
            var fakeHomeService = new Mock<IHomeService>();

            var certification = new HomeController(fakeRepository.Object, fakeHomeService.Object);

            certification.WithCallTo(x => x.Error()).ShouldRenderDefaultView();
        }
    }
}
