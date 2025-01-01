using System.Text;
using System.Security.Cryptography;
namespace Day04;

class Program
{
    private const string InputFilePath = "../../../input/input.txt";
    private static MD5 _md5H =MD5.Create();
    
    public static string GetFileContents(string filePath)
    {
        string readContents = "";
        using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
        {
            readContents = streamReader.ReadToEnd();
        }

        return readContents;
    }

    

    static int PartOne(string input)
    {
       int leadingZeros = 5;
       string matchingPrefix = String.Concat(Enumerable.Repeat("0", leadingZeros));
       bool found = false;
       int i = 0;
       string secretKey = string.Empty;

       while (!found)
       {
           secretKey = Convert.ToHexString(
               _md5H.ComputeHash(Encoding.UTF8.GetBytes(input + i))
           );

           if (secretKey.Substring(0, leadingZeros).Equals(matchingPrefix))
           {
               found = true;
               return i;
           }

           i++;
       }
       
       return -1;
    }

    static int PartTwo(string input)
    {
        int leadingZeros = 6;
        string matchingPrefix = new string('0', leadingZeros);
        int i = 0;
        string secretKey = string.Empty;

        while (true)
        {
            secretKey = Convert.ToHexString(
                _md5H.ComputeHash(Encoding.UTF8.GetBytes(input + i))
            );

            if (secretKey.StartsWith(matchingPrefix))
            {
                return i;
            }

            i++;
        }
    }
    
    static void Main(string[] args)
    {
        try
        {
            var fileContents = GetFileContents(InputFilePath);

            Console.WriteLine($"Part One: {PartOne(fileContents)}");
            Console.WriteLine($"Part Two: {PartTwo(fileContents)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}