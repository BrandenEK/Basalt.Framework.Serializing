# Serializing Framework

Provides easy methods of reading data from and writing data to a stream of bytes

```cs
internal class Program
{
    static void Main(string[] args)
    {
        // Create stream, write to it, and save
        OutStream output = new();
        output.Write_float(10.5f);
        output.Write_string("hello");
        File.WriteAllBytes(PATH, output);

        // Open file, create stream, read from it
        InStream input = File.ReadAllBytes(PATH);
        float number = input.Read_float();
        string text = input.Read_string();
    }

    static readonly string PATH = Path.Combine(Environment.CurrentDirectory, "test.bin");
}
```
