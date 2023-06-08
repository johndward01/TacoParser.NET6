namespace TacoParser.NET6.Tests;

public class TacoParserTests
{
    [Fact]
    public void ShouldDoSomething()
    {
        // TODO: Complete Something, if anything
        // Arrange
        // Act
        var actual = Parser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

        // Assert
        Assert.NotNull(actual);
    }

    [Theory]
    [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638, -84.677017, " Taco Bell Acwort...")]
    public void ShouldParse(string fullString, double expectedLatitude, double expectedLongitude, string expectedTacoBellName)
    {
        // TODO: Complete Should Parse

        // Arrange
        //Act
        var actual = Parser.Parse(fullString);

        //Assert
        Assert.Equal(expectedLatitude, actual.Location.Latitude);
        Assert.Equal(expectedLongitude, actual.Location.Longitude);
        Assert.Equal(expectedTacoBellName, actual.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ShouldFailParse(string str)
    {
        // TODO: Complete Should Fail Parse

        //Arrange

        //Act
        var actual = Parser.Parse(str);

        //Assert
        Assert.Null(actual);
    }
}
