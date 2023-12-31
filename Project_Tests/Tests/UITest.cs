
using Moq;
using Project_Library.UIs;

namespace Project_Tests.Tests
{
    [TestClass]
    public class UITest
	{
        [TestMethod]
        public void Input_should_return_a_string()
        {
            //Arrange
            string expexted = "Input from user";
            var mock = new Mock<IUI>();
            mock.Setup(m => m.Input()).Returns(expexted);
            IUI mockUI = mock.Object;

            //Act
            string actual = mockUI.Input();

            //Assert
            Assert.AreEqual(expexted, actual);
        }
	}
}