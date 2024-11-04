using FiguresCalculationLibrary.Factories;

GenericFigureFactory factory = new();

var figure = factory.CreateShape(new double[][] 
{
    [5, 11],
    [12, 8],
    [9, 5],
    [5, 6],
    [3, 4]
});

Console.WriteLine(figure.CalculateSquare());
Console.WriteLine(figure.ToString());