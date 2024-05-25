
namespace Basalt.Framework.Serializing;

public class DeserializableStream
{
    private readonly byte[] _bytes;
    private int _pointer = 0;

    private DeserializableStream(byte[] bytes)
    {
        _bytes = bytes;
    }

    private void ValidateReadLength(int size)
    {
        if (_pointer + size > _bytes.Length)
            throw new SerializingException("Can not read past the length of the stream");
    }

    private T Read_generic<T>(int size, Func<byte[], int, T> func)
    {
        ValidateReadLength(size);

        T value = func(_bytes, _pointer);
        _pointer += size;
        return value;
    }

    public byte Read_byte()
    {
        ValidateReadLength(1);
        return _bytes[_pointer++];
    }

    public sbyte Read_sbyte()
    {
        ValidateReadLength(1);
        return (sbyte)_bytes[_pointer++];
    }

    public ushort Read_ushort()
    {
        return Read_generic(2, BitConverter.ToUInt16);
    }

    public short Read_short()
    {
        return Read_generic(2, BitConverter.ToInt16);
    }

    public uint Read_uint()
    {
        return Read_generic(4, BitConverter.ToUInt32);
    }

    public int Read_int()
    {
        return Read_generic(4, BitConverter.ToInt32);
    }

    public ulong Read_ulong()
    {
        return Read_generic(8, BitConverter.ToUInt64);
    }

    public long Read_long()
    {
        return Read_generic(8, BitConverter.ToInt64);
    }

    public float Read_float()
    {
        return Read_generic(4, BitConverter.ToSingle);
    }

    public double Read_double()
    {
        return Read_generic(8, BitConverter.ToDouble);
    }

    public char Read_char()
    {
        ValidateReadLength(1);
        return Convert.ToChar(_bytes[_pointer++]);
    }

    public string Read_string()
    {
        byte length = Read_byte();

        if (length == 0)
            return string.Empty;

        ValidateReadLength(length);

        string value = SerializingProperties.TextEncoding.GetString(_bytes, _pointer, length);
        _pointer += length;
        return value;
    }

    public static implicit operator DeserializableStream(byte[] bytes) => new DeserializableStream(bytes);
}
