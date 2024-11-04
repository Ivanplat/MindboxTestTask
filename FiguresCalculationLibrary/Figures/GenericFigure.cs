using FiguresCalculationLibrary.Base;
using System.Drawing;

namespace FiguresCalculationLibrary.Figures;

public class GenericFigure : Shape
{
    private double[][] points_ = null!;

    public override double CalculateSquare()
    {
        return GaussianSquare();
    }

    public override void Initialize<T>(T args)
    {
        var points = args as double[][];

        if (points is null)
        {
            throw new ArgumentException();
        }

        if (points.Length == 0)
        {
            throw new ArgumentException();
        }

        if(points[0].Length != 2)
        {
            throw new ArgumentException();
        }

        points_ = points;
    }

    private double GaussianSquare()
    {
        double result = 0;

        for(int i = 0; i < points_.Length - 1; ++i)
        {
            result += points_[i][0] * points_[i + 1][1];
        }

        result += points_[points_.Length - 1][0] * points_[0][1];

        for(int i = 0; i < points_.Length - 1; ++i)
        {
            result -= points_[i+1][0] * points_[i][1];
        }

        result -= points_[0][0] * points_[points_.Length - 1][1];

        return 0.5 * double.Abs(result);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as GenericFigure;

        if(other is null)
        {
            return false; 
        }

        if (other.points_.Length != points_.Length)
        {
            return false;
        }

        for(int i = 0; i < points_.Length; ++i)
        {
            if (points_[i] != other.points_[i])
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
