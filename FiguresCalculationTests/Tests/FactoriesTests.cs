using FiguresCalculationLibrary.Exceptions;
using FiguresCalculationLibrary.Factories;
using FiguresCalculationLibrary.Figures;

namespace FiguresCalculationTests.Tests;

public class FactoriesTests
{
    [Theory]
    [InlineData(-1.0)]
    [InlineData(0)]
    [InlineData(double.Epsilon)]
    [InlineData(-double.Epsilon)]
    [InlineData(-312.43)]
    [InlineData(-512.323)]
    public void IncorrectArgumentsForCircle(double radius)
    {
        Assert.Throws<FigureSegmentLengthException>(() => 
        {
            CircleFactory factory = new();
            factory.CreateShape(radius);
        });
    }

    [Theory]
    [InlineData(1.0)]
    [InlineData(243.23)]
    [InlineData(343.54)]
    [InlineData(0.00000001)]
    [InlineData(2*double.Epsilon)]
    public void CorrectArgumentsForCircle(double radius)
    {
        try
        {
            CircleFactory factory = new();
            factory.CreateShape(radius);
        }
        catch(FigureSegmentLengthException ex)
        {
            Assert.True(false);
        }

        Assert.True(true);
    }
}