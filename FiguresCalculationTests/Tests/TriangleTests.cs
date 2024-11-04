using FiguresCalculationLibrary.Factories;

namespace FiguresCalculationTests.Tests;

public class TriangleTests
{
    [Theory]
    [InlineData(new double[] { 3, 4, 5 })]
    [InlineData(new double[] { 5, 12, 13 })]
    [InlineData(new double[] { 6, 8, 10 })]
    public void Is_Triangle_Rectangular(double[] segments)
    {
        TriangleFactory factory = new();
        var triangular = factory.CreateShape(segments);

        Assert.True(triangular.IsTriangleRectangular());
    }

    [Theory]
    [InlineData(new double[] { 3, 4, 5 }, new double[] { 3, 4, 5 })]
    [InlineData(new double[] { 5, 12, 13 }, new double[] { 5, 12, 13 })]
    [InlineData(new double[] { 6, 8, 10 }, new double[] { 6, 8, 10 })]
    public void Are_Triangles_Equal(double[] segments1, double[] segments2)
    {
        TriangleFactory factory = new();
        var triangular1 = factory.CreateShape(segments1);
        var triangular2 = factory.CreateShape(segments2);

        Assert.True(triangular1.Equals(triangular2));
    }

    [Theory]
    [InlineData(new double[] { 3, 4, 5 }, new double[] { 8, 4, 5 })]
    [InlineData(new double[] { 5, 12, 13 }, new double[] { 10, 15, 20 })]
    [InlineData(new double[] { 6, 8, 10 }, new double[] { 5, 12, 16 })]
    public void Are_Triangles_Not_Equal(double[] segments1, double[] segments2)
    {
        TriangleFactory factory = new();
        var triangular1 = factory.CreateShape(segments1);
        var triangular2 = factory.CreateShape(segments2);

        Assert.False(triangular1.Equals(triangular2));
    }

    [Theory]
    [InlineData(new double[]{ 3, 4, 5}, 6)]
    [InlineData(new double[] { 17, 17, 30 }, 120)]
    [InlineData(new double[] { 13, 14, 15 }, 84)]

    public void Test_Square(double[] segments, double expected)
    {
        TriangleFactory factory = new();
        var triangle = factory.CreateShape(segments);

        Assert.Equal(triangle.CalculateSquare(), expected, double.Epsilon);
    }
}
