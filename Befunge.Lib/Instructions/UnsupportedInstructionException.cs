using System;

/// <summary>
/// UnsupportedInstructionException: Throw when an unknown instruction is supplied
/// </summary>
public class UnsupportedInstructionException : Exception
{
    /// <summary>
    /// UnsupportedInstructionException
    /// </summary>
    public UnsupportedInstructionException()
    {        
    }

    /// <summary>
    /// UnsupportedInstructionException
    /// </summary>
    /// <param name="message">message to return when exception is thrown.</param>
    public UnsupportedInstructionException(string message)
        :base(message)
    {        
    }

    /// <summary>
    /// UnsupportedInstructionException
    /// </summary>
    /// <param name="message">message to return when exception is thrown.</param>
    /// <param name="inner">inner exception details.</param>
    public UnsupportedInstructionException(string message, Exception inner)
        : base(message, inner)
    {
    }
}