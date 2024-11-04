using FiguresCalculationLibrary.Base;
using FiguresCalculationLibrary.Exceptions;

namespace FiguresCalculationLibrary.Figures;

/// <summary>
/// Triangle object class
/// </summary>
public sealed class Triangle : Shape
{
    private double[] segments_ = null!;
    public override double CalculateSquare()
    {
        if (IsTriangleRectangular(out double[] temp))
        {
            return RectangularTriangleSquare(temp[0], temp[1]);
        }

        return HeronSquare();
    }

    public override void Initialize<T>(T args)
    {
        var segments = args as double[];

        CheckInitializingSegments(segments);

#pragma warning disable CS8601, CS8602 //it can't be null and has incorrect length here if fact that it's checked in CheckInitializingSegments
        segments_ = segments;

        if (!IsTriangleExisted())
        {
            throw new SuchTriangleDoesntExist($"There is not such triangle with segments: {segments_[0]:N3}; {segments_[1]:N3}; {segments_[2]:N3};");
        }
#pragma warning restore CS8601
    }

    /// <summary>
    /// Checks that argument is in correct type and count
    /// </summary>
    /// <param name="segments">The triangle segments</param>
    /// <exception cref="ArgumentException">Throws if segments are null or not in count of 3</exception>
    /// <exception cref="FigureSegmentLengthException">Throws if any segment is not a positive number</exception>
    private void CheckInitializingSegments(double[]? segments)
    {
        if (segments is null)
        {
            throw new ArgumentException("Segments cannot be null!");
        }

        if (segments.Length != 3)
        {
            throw new ArgumentException("Segments count should be 3!");
        }

        if (segments.Any(x => x <= double.Epsilon))
        {
            throw new FigureSegmentLengthException("Each segments length should be a positive number!");
        }
    }

    /// <summary>
    /// Checks that triangle is rectangular
    /// </summary>
    /// <returns>true if rectangular, false otherwise</returns>
    public bool IsTriangleRectangular()
    {
        double[] tempSorted = MakeTempSortedSegments();

        double pythagoris = tempSorted[2] * tempSorted[2] -
            (
                tempSorted[0] * tempSorted[0] +
                tempSorted[1] * tempSorted[1]
            );

        return pythagoris >= 0 && pythagoris < double.Epsilon;
    }

    /// <summary>
    /// Private version of IsTriangleRectangular method to be called in square calculation when there is needed sorted segments
    /// </summary>
    /// <param name="tempSorted">Out sorted segments</param>
    /// <returns>true if rectangular, false otherwise</returns>
    private bool IsTriangleRectangular(out double[] tempSorted)
    {
        tempSorted = MakeTempSortedSegments();

        double pythagoris = tempSorted[2] * tempSorted[2] -
            (
                tempSorted[0] * tempSorted[0] +
                tempSorted[1] * tempSorted[1]
            );

        return pythagoris >= 0 && pythagoris < double.Epsilon;

    }

    /// <summary>
    /// Checks that the triangle is existed
    /// </summary>
    /// <returns>true if existed, false otherwise</returns>
    private bool IsTriangleExisted()
    {
        double[] temp = MakeTempSortedSegments();

        return temp[0] + temp[1] > temp[2];
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Triangle;

        if(other is null)
        {
            return false;
        }

        var temp1 = other.MakeTempSortedSegments();
        var temp2 = MakeTempSortedSegments();

        return 
            temp1[0] == temp2[0] &&
            temp1[1] == temp2[1] &&
            temp1[2] == temp2[2];
    }

    /// <summary>
    /// Creates a new sorted segments array
    /// </summary>
    /// <returns>New sorted segments array</returns>
    private double[] MakeTempSortedSegments()
    {
        double[] temp = new double[3];

        segments_.CopyTo(temp, 0);
        Array.Sort(temp);

        return temp;
    }

    /// <summary>
    /// Calculates the square for a rectangular triangle
    /// </summary>
    /// <param name="a">First cathetus</param>
    /// <param name="b">Second cathetus</param>
    /// <returns>The square of a rectangular triangle</returns>
    private double RectangularTriangleSquare(double a, double b)
    {
        return 0.5 * a * b;
    }

    /// <summary>
    /// Calculates the squre for any rectangular by three given segments
    /// </summary>
    /// <returns>The square of any triangle</returns>
    private double HeronSquare()
    {
        double semiPerimetr = 0.5 * (segments_[0] + segments_[1] + segments_[2]);
        return Math.Sqrt
            (
            semiPerimetr * 
            (semiPerimetr - segments_[0]) *
            (semiPerimetr - segments_[1]) *
            (semiPerimetr - segments_[2])
            );
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
