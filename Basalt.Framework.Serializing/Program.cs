namespace Basalt.Framework.Serializing;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        byte type = 5;
        uint bitfield = 0x12;
        double dec = 5.56;

        var stream = new SerializableStream();
        stream.Write(type);
        stream.Write(bitfield);
        stream.Write(dec);

        File.WriteAllBytes(Environment.CurrentDirectory + "/test.txt", stream);
        byte[] bytes = stream;

        foreach (var value in bytes)
        {
            Console.WriteLine(value);
        }
    }
}
