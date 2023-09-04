
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
            string result = mockUI.Input();

            //Assert
            Assert.AreEqual(expexted, result);
        }

		[TestMethod]
		public void Display_should_display_string()
		{
			//Arrange
			string expexted = "message sent";
			var mock = new Mock<IUI>();
			mock.Setup(m => m.Display(It.IsAny<string>()));
			IUI mockUI = mock.Object;

			//Act
			string result = mockUI.Input();

			//Assert
			Assert.AreEqual(expexted, result);
		}
	}
}