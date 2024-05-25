
namespace Basalt.Framework.Serializing;

public class SerializableStream
{
    private readonly List<byte> _bytes = new();

    public void Write_byte(byte data)
    {
        _bytes.Add(data);
    }

    public void Write_sbyte(sbyte data)
    {
        _bytes.Add((byte)data);
    }

    public void Write_ushort(ushort data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_short(short data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_uint(uint data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_int(int data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_ulong(ulong data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_long(long data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_float(float data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_double(double data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write_char(char data)
    {
        _bytes.Add(Convert.ToByte(data));
    }

    public void Write_string(string? data)
    {
        if (string.IsNullOrEmpty(data))
        {
            _bytes.Add(0);
            return;
        }

        var bytes = SerializingProperties.TextEncoding.GetBytes(data);

        if (bytes.Length > 255)
            throw new SerializingException("Can not serialize a string with more than 255 bytes");

        _bytes.Add((byte)bytes.Length);
        _bytes.AddRange(bytes);
    }

    public static implicit operator byte[](SerializableStream stream) => stream._bytes.ToArray();
}
