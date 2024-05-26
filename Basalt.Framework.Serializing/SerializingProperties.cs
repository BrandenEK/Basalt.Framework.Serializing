using System.Text;

namespace Basalt.Framework.Serializing;

/// <summary>
/// Properties used by the serializing framework
/// </summary>
public static class SerializingProperties
{
    /// <summary>
    /// The encoding used when serializing/deserializing strings
    /// </summary>
    public static Encoding TextEncoding { get; set; } = Encoding.UTF8;
}
