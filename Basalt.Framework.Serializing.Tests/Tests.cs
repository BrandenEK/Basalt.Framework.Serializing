namespace Basalt.Framework.Serializing.Tests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void Serialize()
    {
        OutStream stream = new();
        stream.Write_byte(TEST_1);
        stream.Write_uint(TEST_2);
        stream.Write_float(TEST_3);
        stream.Write_string(TEST_4);
        byte[] bytes = stream;

        if (bytes.Length != TEST_DATA.Length)
            throw new Exception("OutStream is invalid");

        for (int i = 0; i < bytes.Length; i++)
        {
            if (bytes[i] != TEST_DATA[i])
                throw new Exception("OutStream is invalid");
        }
    }

    [TestMethod]
    public void Deserialize()
    {
        InStream stream = TEST_DATA;

        if (stream.Read_byte() != TEST_1)
            throw new Exception("InStream is invalid");
        if (stream.Read_uint() != TEST_2)
            throw new Exception("InStream is invalid");
        if (stream.Read_float() != TEST_3)
            throw new Exception("InStream is invalid");
        if (stream.Read_string() != TEST_4)
            throw new Exception("InStream is invalid");
    }

    private const byte TEST_1 = 1;
    private const uint TEST_2 = 0xFF01FF01;
    private const float TEST_3 = 99.99f;
    private const string TEST_4 = "hello";

    private static readonly byte[] TEST_DATA =
    {
        1, 1, 255, 1, 255, 225, 250, 199, 66, 5, 104, 101, 108, 108, 111
    };
}