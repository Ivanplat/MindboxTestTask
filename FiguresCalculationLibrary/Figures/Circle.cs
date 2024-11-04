using FiguresCalculationLibrary.Base;
using FiguresCalculationLibrary.Exceptions;

namespace FiguresCalculationLibrary.Figures;

/// <summary>
/// Circle object class
/// </summary>
public sealed class Circle: Shape
{
    public double Radius { get; private set; }

    public override double CalculateSquare()
    {
        return ClassicSquare();
    }

    /// <summary>
    /// Classic square formula using radius
    /// </summary>
    /// <returns>Square of this circle</returns>
    private double ClassicSquare()
    {
        return Radius * Radius * Math.PI;
    }
    /// <summary>
    /// Sets the radius of the Circle
    /// </summary>
    /// <param name="radius">New radius</param>
    public void SetRadius(double radius)
    {
        CheckRadius(radius);

        Radius = radius;
    }

    /// <summary>
    /// Checks that radius is a positive number
    /// </summary>
    /// <param name="radius">The radius</param>
    /// <exception cref="FigureSegmentLengthException">Throws if radius is not a positive number</exception>
    private void CheckRadius(double radius)
    {
        if (radius <= double.Epsilon)
        {
            throw new FigureSegmentLengthException("Radius should be a positive number!");
        }
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Circle;

        if (other is null)
        {
            return false;
        }

        return double.Abs(Radius - other.Radius) < double.Epsilon;
    }

    public override void Initialize<T>(T args)
    {
        var radius = args as double?;

        CheckInitializingRadius(radius);
        
        SetRadius(radius ?? 0);
    }

    /// <summary>
    /// Checks that radius argument is in correct type
    /// </summary>
    /// <param name="radius">Raduis argument</param>
    /// <exception cref="ArgumentException">Throws if the radius argument is incorrect type</exception>
    private void CheckInitializingRadius(double? radius)
    {
        if (radius is null)
        {
            throw new ArgumentException("Radius should be double!");
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
