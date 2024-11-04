using FiguresCalculationLibrary.Base;
using FiguresCalculationLibrary.Exceptions;
using FiguresCalculationLibrary.Figures;

namespace FiguresCalculationLibrary.Factories;

/// <summary>
/// Generic and base version of all the shapes factories
/// </summary>
/// <typeparam name="T">The shape type</typeparam>
/// <typeparam name="ArgsType">The type to initialize the shape. E.g. circle - double, Rectangular - double array</typeparam>
public class ShapeFactory<T, ArgsType> where T : Shape, new()
{
    /// <summary>
    /// Create a new shape object (generic version). The ArgsType is any type
    /// </summary>
    /// <param name="args">Arguments to initalize a new shape object</param>
    /// <returns>A new shape object</returns>
    public virtual T CreateShape(ArgsType args)
    {
        try
        {
            var shape = Shape.Create<T>();
            shape.Initialize(args);
            return shape;
        }
        catch(Exception ex)
        {
            throw new FigureInitializeException("The figure cannot be initialized!", ex);
        }
    }
}

/// <summary>
/// Circle version of shape factories
/// </summary>
public sealed class CircleFactory : ShapeFactory<Circle, double> 
{
    /// <summary>
    /// Create a new shape object (circle)
    /// </summary>
    /// <param name="args">Radius of the circle</param>
    /// <returns>New Circle object</returns>
    public override Circle CreateShape(double radius)
    {
        return base.CreateShape(radius);
    }
}

/// <summary>
/// Triangle version of shape factories
/// </summary>
public sealed class TriangleFactory : ShapeFactory<Triangle, double[]>
{
    /// <summary>
    /// Create a new shape object (triangle)
    /// </summary>
    /// <param name="args">Array of 3 elements, lengths of its segments</param>
    /// <returns>New Triangle object</returns>
    public override Triangle CreateShape(double[] segments)
    {
        return base.CreateShape(segments);
    }
}

/// <summary>
/// Generic figure version of shape factories
/// </summary>
public sealed class GenericFigureFactory : ShapeFactory<GenericFigure, double[][]>
{
    /// <summary>
    /// Create a new shape object (generic figure)
    /// </summary>
    /// <param name="args">Array of coordinate points</param>
    /// <returns>New GenericFigure object</returns>
    public override GenericFigure CreateShape(double[][] coordinatePoints)
    {
        return base.CreateShape(coordinatePoints);
    }
}