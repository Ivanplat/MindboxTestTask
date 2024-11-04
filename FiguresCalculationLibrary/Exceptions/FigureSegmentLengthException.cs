using System.Runtime.Serialization;

namespace FiguresCalculationLibrary.Exceptions;

public class FigureSegmentLengthException : FiguresLibraryException
{
    public FigureSegmentLengthException() : base() {}
    public FigureSegmentLengthException(string? message) : base(message) {}
    public FigureSegmentLengthException(string? message, Exception? innerException) : base(message, innerException) {}
}
