using System;

namespace Basalt.Framework.Serializing;

/// <summary>
/// An error thrown by the serializing framework
/// </summary>
public class SerializingException : Exception
{
    internal SerializingException(string message) : base(message) { }
}
