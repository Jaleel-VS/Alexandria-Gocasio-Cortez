namespace Day02
{
    class Program
    {
        private const string InputFilePath = "../../../input/input.txt";

        public static IEnumerable<string> GetFileContents(string filePath)
        {
            return File.ReadLines(filePath);
        }

        private static int[] ParseDimensions(string detail)
        {
            var dimension = detail.Split('x').Select(int.Parse).ToArray();
            if (dimension.Length != 3 || dimension.Any(d => d <= 0))
            {
                throw new ArgumentException($"Invalid dimensions: {detail}");
            }
            return dimension;
        }

        private static int GetSmallestSide(int side1, int side2, int side3)
        {
            return Math.Min(side1, Math.Min(side2, side3));
        }

        private static int GetRequiredWrappingPaper(int l, int w, int h)
        {
            const int multiplier = 2; // To replace magic number
            int smallestArea = GetSmallestSide(l * w, w * h, h * l);
            return smallestArea + (multiplier * l * w + multiplier * w * h + multiplier * h * l);
        }

        private static int CalculateRibbonLength(int[] dimension)
        {
            const int multiplier = 2; // To replace magic number
            int smallestPerimeter = dimension.OrderBy(x => x).Take(2).Sum(x => multiplier * x);
            int bowLength = dimension.Aggregate((x, y) => x * y); // Volume
            return smallestPerimeter + bowLength;
        }

        static int PartOne(IEnumerable<string> input)
        {
            return input.Sum(detail =>
            {
                var dimension = ParseDimensions(detail);
                return GetRequiredWrappingPaper(dimension[0], dimension[1], dimension[2]);
            });
        }

        static int PartTwo(IEnumerable<string> input)
        {
            return input.Sum(detail =>
            {
                var dimension = ParseDimensions(detail);
                return CalculateRibbonLength(dimension);
            });
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
}
