using FiguresCalculationLibrary.Factories;

namespace FiguresCalculationTests.Tests;

public class CircleTests
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void Are_Circles_Equal(double radius1, double radius2)
    {
        CircleFactory factory = new();
        var circle1 = factory.CreateShape(radius1);
        var circle2 = factory.CreateShape(radius2);

        Assert.True(circle1.Equals(circle2));
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 17)]
    public void Are_Not_Circles_Equal(double radius1, double radius2)
    {
        CircleFactory factory = new();
        var circle1 = factory.CreateShape(radius1);
        var circle2 = factory.CreateShape(radius2);

        Assert.False(circle1.Equals(circle2));
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(2, 4*Math.PI)]
    [InlineData(Math.PI, Math.PI* Math.PI* Math.PI)]
    public void Test_Square(double radius, double expected)
    {
        CircleFactory factory = new();
        var circle = factory.CreateShape(radius);

        Assert.Equal(circle.CalculateSquare(), expected, double.Epsilon);
    }
}
