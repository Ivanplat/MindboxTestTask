using FiguresCalculationLibrary.Factories;

namespace FiguresCalculationTests.Tests;

public class GenericFigureTests
{
    [Theory]
    [MemberData(nameof(GenericFigureTestsData.SamePoints), MemberType = typeof(GenericFigureTestsData))]
    public void Are_Generic_Figures_Equal(double[][] points1, double[][] points2)
    {
        GenericFigureFactory factory = new();
        var figure1 = factory.CreateShape(points1);
        var figure2 = factory.CreateShape(points2);

        Assert.True(figure1.Equals(figure2));
    }

    [Theory]
    [MemberData(nameof(GenericFigureTestsData.DifferentPoints), MemberType = typeof(GenericFigureTestsData))]
    public void Are_Generic_Figures_Not_Equal(double[][] points1, double[][] points2)
    {
        GenericFigureFactory factory = new();
        var figure1 = factory.CreateShape(points1);
        var figure2 = factory.CreateShape(points2);

        Assert.False(figure1.Equals(figure2));
    }

    [Theory]
    [MemberData(nameof(GenericFigureTestsData.PoinstForTestingSquareAndExpected), MemberType = typeof(GenericFigureTestsData))]
    public void Test_Square(double[][] points, double expected)
    {
        GenericFigureFactory factory = new();
        var figure = factory.CreateShape(points);

        Assert.Equal(figure.CalculateSquare(), expected, 0.01);
    }
}

public class GenericFigureTestsData
{
    public static IEnumerable<object[]> DifferentPoints =>
        [
            [new double[][] { [1, 2], [3, 4] }, new double[][] { [1, 2], [5, 6] }],
            [new double[][] { [-2, 43], [5, 17] }, new double[][] { [-10, -20], [40, 17] }]
        ];

    public static IEnumerable<object[]> SamePoints =>
    [
        [new double[][] { [1, 2], [3, 4] }, new double[][] { [1, 2], [3, 4] }],
        [new double[][] { [-10, 2], [3, 4] }, new double[][] { [-10, 2], [3, 4] }],
        [new double[][] { [9, 1], [43, 5] }, new double[][] { [9, 1], [43, 5] }]
    ];

    public static IEnumerable<object[]> PoinstForTestingSquareAndExpected =>
        [
            [new double[][] { [5, 11], [12, 8], [9, 5], [5, 6], [3, 4] }, 30],
            [new double[][] { [2, 4], [3, -8], [1, 2] }, 7],
            [new double[][] { [1, 1], [2, 4], [5, 3] }, 5],
            [new double[][] { [21.544, 16.832], [13.190, 18.154], [9.144, -16.443], [20.913, -17.548], [21,544, 16.832] }, 174.17]
        ];
}
