namespace FiguresCalculationLibrary.Base;

/// <summary>
/// Abstract class for all figures
/// </summary>
public abstract class Shape
{
    protected Shape()
    {
        ShapeId = Guid.NewGuid();
    }

    /// <summary>
    /// The id of a shape
    /// </summary>
    public Guid ShapeId { get; init; }

    /// <summary>
    /// Abstract method for calculation of its square to be implemented in children classes
    /// </summary>
    /// <returns>The square of this shape</returns>
    public abstract double CalculateSquare();

    /// <summary>
    /// Initializing the shape
    /// </summary>
    /// <typeparam name="T">Initializing argument type</typeparam>
    /// <param name="args">Initializing arguments</param>
    public abstract void Initialize<T>(T args);

    /// <summary>
    /// Creates a new Shape object. Should be used in factories only!
    /// </summary>
    /// <typeparam name="T">Shape class</typeparam>
    /// <returns>A new Shape object by given type</returns>
    internal static T Create<T>() where T : Shape, new() => new();

    public override string ToString()
    {
        return $"{GetType().Name} with id: {ShapeId}";
    }

    public override int GetHashCode()
    {
        return ShapeId.GetHashCode();
    }
}