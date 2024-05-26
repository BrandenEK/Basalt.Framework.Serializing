﻿using System;
using System.Collections.Generic;

namespace Basalt.Framework.Serializing;

/// <summary>
/// A writable data stream
/// </summary>
public class OutStream
{
    private readonly List<byte> _bytes = new();

    /// <summary>
    /// Writes a byte to the stream
    /// </summary>
    public void Write_byte(byte data)
    {
        _bytes.Add(data);
    }

    /// <summary>
    /// Writes an sbyte to the stream
    /// </summary>
    public void Write_sbyte(sbyte data)
    {
        _bytes.Add((byte)data);
    }

    /// <summary>
    /// Writes a ushort to the stream
    /// </summary>
    public void Write_ushort(ushort data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a short to the stream
    /// </summary>
    public void Write_short(short data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a uint to the stream
    /// </summary>
    public void Write_uint(uint data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes an int to the stream
    /// </summary>
    public void Write_int(int data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a ulong to the stream
    /// </summary>
    public void Write_ulong(ulong data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a long to the stream
    /// </summary>
    public void Write_long(long data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a float to the stream
    /// </summary>
    public void Write_float(float data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a double to the stream
    /// </summary>
    public void Write_double(double data)
    {
        _bytes.AddRange(BitConverter.GetBytes(data));
    }

    /// <summary>
    /// Writes a char to the stream
    /// </summary>
    public void Write_char(char data)
    {
        _bytes.Add(Convert.ToByte(data));
    }

    /// <summary>
    /// Writes a string to the stream
    /// </summary>
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

    /// <summary>
    /// Creates a new byte[] from an OutStream
    /// </summary>
    public static implicit operator byte[](OutStream stream) => stream._bytes.ToArray();
}
