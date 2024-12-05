using System.Text;

namespace Day01;


class Program
{
    private const string InputFilePath = "../../../input/input.txt";
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
        int currentFloor = 0;
       
        
        foreach (char c in input)
        {
            switch (c)
            {
                case '(':
                    currentFloor += 1;
                    break;
                case ')':
                    currentFloor -= 1;
                    break;
            }
        }

        return currentFloor;
    }

    static int PartTwo(string input)
    {
        int currentFloor = 0;
        int i = 0;
        
        foreach (char c in input)
        {
            i++;
            
            switch (c)
            {
                case '(':
                    currentFloor += 1;
                    break;
                case ')':
                    currentFloor -= 1;
                    break;
            }

            if (currentFloor == -1)
            {
                return i;
            }

            

        }

        return i;

    }
    
    
    
    static void Main(string[] args)
    {
        try
        {
            string fileContents = GetFileContents(InputFilePath);

            Console.WriteLine($"Part One: {PartOne(fileContents)}");
            Console.WriteLine($"Part Two: {PartTwo(fileContents)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}