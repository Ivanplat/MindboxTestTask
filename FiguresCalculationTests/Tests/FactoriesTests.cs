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
    public void Incorrect_Arguments_For_Circle(double radius)
    {
        Assert.Throws<FigureInitializeException>(() =>
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
    public void Correct_Arguments_For_Circle(double radius)
    {
        try
        {
            CircleFactory factory = new();
            factory.CreateShape(radius);
        }
        catch(FigureSegmentLengthException ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Theory]
    [InlineData(new double[] { })]
    [InlineData(new double[] {1})]
    [InlineData(new double[] {2, 3})]
    [InlineData(new double[] {4, 54, 3, 42})]
    public void Incorrect_Amount_Of_Arguments_For_Triangle(double[] segments)
    {
        Assert.Throws<FigureInitializeException>(() => 
        {
            TriangleFactory factory = new();
            factory.CreateShape(segments);
        });
    }

    [Theory]
    [InlineData(new double[] {3, 4, 5})]
    [InlineData(new double[] { 10, 15, 20})]
    public void Correct_Amount_Of_Arguments_For_Triangle(double[] segments)
    {
        try
        {
            TriangleFactory factory = new();
            factory.CreateShape(segments);
        }
        catch(Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Theory]
    [InlineData(new double[] { 1, 5, 100 })]
    [InlineData(new double[] { 20, 50, 90 })]
    [InlineData(new double[] { 31, 24, 5 })]
    [InlineData(new double[] { 100, 1000, 100 })]
    public void Unexisted_Triangles(double[] segments)
    {
        Assert.Throws<FigureInitializeException>(() =>
        {
            TriangleFactory factory = new();
            factory.CreateShape(segments);
        });
    }

    [Theory]
    [InlineData(new double[] { 3, 4, 5 })]
    [InlineData(new double[] { 10, 15, 20 })]
    [InlineData(new double[] { 5, 12, 13 })]
    [InlineData(new double[] { 6, 8, 10 })]
    public void Existed_Triangles(double[] segments)
    {
        try
        {
            TriangleFactory factory = new();
            factory.CreateShape(segments);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Theory]
    [InlineData(new double[] {-1, 0, 10 })]
    [InlineData(new double[] { double.Epsilon, 10, 20 })]
    [InlineData(new double[] { double.Epsilon, double.Epsilon, double.Epsilon })]
    [InlineData(new double[] { 0, 0, 0})]
    [InlineData(new double[] { -10, 20, -200 })]
    public void Incorrect_Triangles_Segments_Length(double[] segments)
    {
        Assert.Throws<FigureInitializeException>(() =>
        {
            TriangleFactory factory = new();
            factory.CreateShape(segments);
        });
    }
}