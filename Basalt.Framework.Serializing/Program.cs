
namespace Basalt.Framework.Serializing;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string path = Environment.CurrentDirectory + "/test.txt";

        byte type = 5;
        uint bitfield = 0x12;
        double dec = 5.56;
        string? str = null;

        var stream = new SerializableStream();
        stream.Write(type);
        stream.Write(bitfield);
        stream.Write(dec);
        stream.Write(str);
        stream.Write("Test");

        File.WriteAllBytes(path, stream);

        DeserializableStream dStream = File.ReadAllBytes(path);
        Console.WriteLine(dStream.Read_byte());
        Console.WriteLine(dStream.Read_uint());
        Console.WriteLine(dStream.Read_double());
        Console.WriteLine(dStream.Read_string());
        Console.WriteLine(dStream.Read_string());

        Console.ReadKey();
    }
}
