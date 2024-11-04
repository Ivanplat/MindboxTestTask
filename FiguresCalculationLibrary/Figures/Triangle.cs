using FiguresCalculationLibrary.Base;
using FiguresCalculationLibrary.Exceptions;

namespace FiguresCalculationLibrary.Figures;

public class Triangle : Shape
{
    private double[] segments_ = null!;
    public override double CalculateSquare()
    {
        double[] temp = MakeTempSortedSegments();

        if (
            temp[2] * temp[2] -
            (
                temp[0] * temp[0] +
                temp[1] * temp[1]
            ) < double.Epsilon
            )
        {
            return RectangularTriangleSquare(temp[0], temp[1]);
        }

        return HeronSquare();
    }

    public override void Initialize<T>(T args)
    {
        var segments = args as double[];

        if (segments is null)
        {
            throw new ArgumentException();
        }

        if(segments.Length != 3)
        {
            throw new ArgumentException();
        }

        if (segments.Any(x => x <= 0.0))
        {
            throw new FigureSegmentLengthException();
        }

        segments_ = segments;
    }

    public bool IsTriangleRectangular()
    {
        double[] temp = MakeTempSortedSegments();

        return
            temp[2] * temp[2] -
            (
                temp[0] * temp[0] +
                temp[1] * temp[1]
            ) < double.Epsilon;
    }

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

    private double[] MakeTempSortedSegments()
    {
        double[] temp = new double[3];

        segments_.CopyTo(temp, 0);
        Array.Sort(temp);

        return temp;
    }

    private double RectangularTriangleSquare(double a, double b)
    {
        return 0.5 * a * b;
    }

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
