using FiguresCalculationLibrary.Base;
using FiguresCalculationLibrary.Exceptions;

namespace FiguresCalculationLibrary.Figures;

public class Circle : Shape
{
    public double Radius { get; private set; }

    public override double CalculateSquare()
    {
        return Radius * Radius * Math.PI;
    }

    public void SetRadius(double radius)
    {
        if(radius <= double.Epsilon)
        {
            throw new FigureSegmentLengthException();
        }

        Radius = radius;
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
        if (args is null)
        {
            throw new ArgumentException();
        }

        if(args is not double)
        {
            throw new ArgumentException();
        }

        var radius = args as double?;
        SetRadius(radius ?? 0);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
