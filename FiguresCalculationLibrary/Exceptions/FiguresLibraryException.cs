namespace FiguresCalculationLibrary.Exceptions;

public class FiguresLibraryException : Exception
{
    public FiguresLibraryException() : base() { }
    public FiguresLibraryException(string? message) : base(message) { }
    public FiguresLibraryException(string? message, Exception? innerException) : base(message, innerException) { }
}
