namespace FiguresCalculationLibrary.Exceptions;

public class FigureInitializeException : FiguresLibraryException
{
    public FigureInitializeException() : base() { }
    public FigureInitializeException(string? message) : base(message) { }
    public FigureInitializeException(string? message, Exception? innerException) : base(message, innerException) { }
}
