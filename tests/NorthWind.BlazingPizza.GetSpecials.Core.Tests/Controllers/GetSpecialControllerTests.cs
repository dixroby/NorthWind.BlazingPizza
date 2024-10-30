namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Controllers;


public class GetSpecialControllerTests
{
    [Fact]
    public async Task GetSpecialsAsync_ShouldInvokeInputPortAndReturnPizzaSpecial()
    {
        //Arrange
        var inputPort = Substitute.For<IGetSpecialInputPort>();
        var outPutPort = Substitute.For<IGetSpecialsOutputPort>();

        var ExpectedSpeacials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(1, "s1", 30, "d1", "i1"),
            new PizzaSpecialDto(2, "s2", 30, "d2", "i2"),
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
        };

        outPutPort.PizzaSpecials.Returns(ExpectedSpeacials);
        inputPort.GetSpecialAsync().Returns(Task.CompletedTask);

        var controller = new GetSpecialsController(inputPort, outPutPort);

        // Act
        var returnedSpecials = await controller.GetSpecialsAsync();

        // Assert
        await inputPort.Received(1).GetSpecialAsync();
        Assert.Equal(ExpectedSpeacials, returnedSpecials);

    }
}