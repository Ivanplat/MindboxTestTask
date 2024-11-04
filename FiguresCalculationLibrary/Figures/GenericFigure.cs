using FiguresCalculationLibrary.Base;

namespace FiguresCalculationLibrary.Figures;

/// <summary>
/// Generic figure object class. This class uses coordinates instead of segments length
/// </summary>
public sealed class GenericFigure : Shape
{
    /// <summary>
    /// The array of coordinate points
    /// </summary>
    private double[][] points_ = null!;

    /// <summary>
    /// Getter by copy points property
    /// </summary>
    public double[] Points
    {
        get
        {
            double[] result = new double[points_.Length];
            points_.CopyTo(result, 0);
            return result;
        }
    }

    public override double CalculateSquare()
    {
        return GaussianSquare();
    }

    public override void Initialize<T>(T args)
    {
        var points = args as double[][];

        CheckInitializingPoints(points);

#pragma warning disable CS8601  //it can't be null and has incorrect length here if fact that it's checked in CheckInitializingPoints
        points_ = points;
#pragma warning restore CS8601
    }

    private void CheckInitializingPoints(double[][]? points)
    {
        if (points is null)
        {
            throw new ArgumentException($"Arguments cannot be null");
        }

        if (points.Length == 0)
        {
            throw new ArgumentException($"Should be at least one point");
        }

        if (points[0].Length != 2)
        {
            throw new ArgumentException($"Coordinates should be given in format of 2 coordinates (X, Y)");
        }
    }

    /// <summary>
    /// Calculates the square of generic figure using Gaussian square formula by its coordinates.
    /// <see cref="https://en.wikipedia.org/wiki/Shoelace_formula"/>
    /// </summary>
    /// <returns>The square of a generic figure</returns>
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
            if (points_[i][0] != other.points_[i][0] &&
                points_[i][1] != other.points_[i][1])

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
