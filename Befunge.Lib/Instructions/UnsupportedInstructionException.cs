using System;

public class UnsupportedInstructionException : Exception
{
    public UnsupportedInstructionException()
    {        
    }

    public UnsupportedInstructionException(string message)
        :base(message)
    {        
    }

    public UnsupportedInstructionException(string message, Exception inner)
        : base(message, inner)
    {
    }
}