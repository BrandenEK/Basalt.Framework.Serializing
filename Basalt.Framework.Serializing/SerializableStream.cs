
namespace Basalt.Framework.Serializing;

public class SerializableStream
{
    private readonly List<byte> _bytes = new();

    public void Write(byte data)
    {
        _bytes.Add(data);
    }

    public void Write(sbyte data)
    {
        _bytes.Add((byte)data);
    }

    public void Write(ushort data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(short data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(uint data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(int data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(ulong data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(long data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(float data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public void Write(double data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    public static implicit operator byte[](SerializableStream stream) => stream._bytes.ToArray();
}
