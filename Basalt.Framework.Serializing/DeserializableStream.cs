
namespace Basalt.Framework.Serializing;

public class DeserializableStream
{
    private readonly byte[] _bytes;
    private int _pointer = 0;

    public DeserializableStream(byte[] bytes)
    {
        _bytes = bytes;
    }

    private void ValidateReadLength(int size)
    {
        if (_pointer + size > _bytes.Length)
            throw new SerializingException("Can not read past the length of the stream");
    }

    public byte Read_byte()
    {
        ValidateReadLength(1);

        byte value = _bytes[_pointer];
        _pointer += 1;
        return value;
    }

    public sbyte Read_sbyte()
    {
        ValidateReadLength(1);

        sbyte value = (sbyte)_bytes[_pointer];
        _pointer += 1;
        return value;
    }

    public ushort Read_ushort()
    {
        ValidateReadLength(2);

        ushort value = BitConverter.ToUInt16(_bytes, _pointer);
        _pointer += 2;
        return value;
    }

    public short Read_short()
    {
        ValidateReadLength(2);

        short value = BitConverter.ToInt16(_bytes, _pointer);
        _pointer += 2;
        return value;
    }

    public uint Read_uint()
    {
        ValidateReadLength(4);

        uint value = BitConverter.ToUInt32(_bytes, _pointer);
        _pointer += 4;
        return value;
    }

    public int Read_int()
    {
        ValidateReadLength(4);

        int value = BitConverter.ToInt32(_bytes, _pointer);
        _pointer += 4;
        return value;
    }

    public ulong Read_ulong()
    {
        ValidateReadLength(8);

        ulong value = BitConverter.ToUInt64(_bytes, _pointer);
        _pointer += 8;
        return value;
    }

    public long Read_long()
    {
        ValidateReadLength(8);

        long value = BitConverter.ToInt64(_bytes, _pointer);
        _pointer += 8;
        return value;
    }

    public float Read_float()
    {
        ValidateReadLength(4);

        float value = BitConverter.ToSingle(_bytes, _pointer);
        _pointer += 4;
        return value;
    }

    public double Read_double()
    {
        ValidateReadLength(8);

        double value = BitConverter.ToDouble(_bytes, _pointer);
        _pointer += 8;
        return value;
    }

    public char Read_char()
    {
        ValidateReadLength(1);

        char value = Convert.ToChar(_bytes[_pointer]);
        _pointer += 1;
        return value;
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
}
