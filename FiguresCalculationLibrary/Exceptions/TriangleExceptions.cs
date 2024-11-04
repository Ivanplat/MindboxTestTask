namespace FiguresCalculationLibrary.Exceptions;

public class SuchTriangleDoesntExist : FiguresLibraryException
{
    public SuchTriangleDoesntExist() : base() { }
    public SuchTriangleDoesntExist(string? message) : base(message) { }
    public SuchTriangleDoesntExist(string? message, Exception? innerException) : base(message, innerException) { }
}
