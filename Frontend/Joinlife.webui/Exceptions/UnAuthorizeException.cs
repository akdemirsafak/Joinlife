﻿using System.Runtime.Serialization;

namespace Joinlife.webui.Exceptions;

public class UnAuthorizeException : Exception
{
    public UnAuthorizeException()
    {
    }

    public UnAuthorizeException(string? message) : base(message)
    {
    }

    public UnAuthorizeException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnAuthorizeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
