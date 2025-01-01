using System.Text;
namespace Day03;

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

    static (int, int) DeliverPresent(char direction, (int x, int y) currentPosition)
    {

        return direction switch
        {
            '^' => (currentPosition.x, currentPosition.y + 1),
            'v' => (currentPosition.x, currentPosition.y - 1),
            '<' => (currentPosition.x - 1, currentPosition.y),
            '>' => (currentPosition.x + 1, currentPosition.y),
            _ => currentPosition
        };
    }

    static int PartOne(string input)
    {
        HashSet<(int x, int y)> coordinates = [];
        coordinates.Add((0, 0));
        (int, int) currentPosition = (0, 0);

        foreach (char c in input)
        {
            currentPosition = DeliverPresent(c, currentPosition);
            coordinates.Add(currentPosition);
        }

        return coordinates.Count;

    }

    static int PartTwo(string input)
    {
        HashSet<(int x, int y)> coordinates = new HashSet<(int x, int y)>{(0, 0)};
        (int, int) santaPosition = (0, 0);
        (int, int) roboSantaPosition = (0, 0);

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                roboSantaPosition = DeliverPresent(input[i], roboSantaPosition);
                coordinates.Add(roboSantaPosition);
                
            }
            
            else
            {
                santaPosition = DeliverPresent(input[i], santaPosition);
                coordinates.Add(santaPosition);
            }
        }
        
        return coordinates.Count;

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