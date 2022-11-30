using System.Numerics;
using System.Text;
using Windows.Devices.I2c.Provider;

namespace CodeWars
{
    internal class Kata
    {
        public static int TraningZero(int number)
        {
            /*
            int[] pows = new int[10];
            for (int i = 0; i < pows.Length; i++)
            {
                pows[i] = (int)Math.Pow(5, i);
            }
            int sum = 0;
            for (int i = 1; i < pows.Length; i++)
            {
                sum += number / pows[i];
            }
            return sum;
            */

            int i = 1;
            int sum = 0;
            int pow;
            do
            {
                pow = (int)Math.Pow(5, i);
                sum += number / pow;
                i++;
            }
            while (pow < number);
            return sum;

        }
        public static int zeroes(int radix, int number)
        {
            int factorial, trailingzeroes = 0;
            for (factorial = 1; number > 1; factorial *= number--) ;
            while (factorial % radix == 0) { factorial /= radix; ++trailingzeroes; };
            return trailingzeroes;
        }
        public static void Factorial(int radix, int number)
        {
            File.Delete("nums.txt");
            BigInteger factorial = 1;
            Console.WriteLine(@"{0,6}:{1, 50}", 0, factorial);
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;

                Console.WriteLine(@"{0,6}:{1, 50}", i, CountZeros(factorial.ToString("X")));
                File.AppendAllText("nums.txt", $"{i};{CountZeros(factorial.ToString("X"))}\n");
            }
        }
        static string Convert(BigInteger integer, int radix)
        {

            return "";
        }
        static int CountZeros(string integer)
        {
            int countZeros = 0;
            for (int i = integer.Length - 1; i >= 0; i--)
            {
                if (integer[i] == '0')
                {
                    countZeros++;
                }
                else
                {
                    break;
                }
            }
            return countZeros;
        }
        /*
        public static int[,] Spiralize(int size)
        {
            int[,] spirale = new int[size,size];
            Direction direction = Direction.Right;
            int k = 0, n = 0;
            for (int i = 0; i < spirale.Length; i++)
            {
                switch (direction)
                {
                    case Direction.Right:
                        if (k >= size - 1 || )
                        {
                            direction = Direction.Down;
                        }
                        spirale[k++, n] = 1;
                        if (k >= size)
                        {
                            k = size - 1;
                        }
                        break;
                    case Direction.Down:
                        if (n >= size - 1)
                        {
                            direction = Direction.Left;
                        }
                        spirale[k, n++] = 1;
                        if (n >= size)
                        {
                            n = size - 1;
                        }
                        break;
                    case Direction.Left:
                        if (k <= 0)
                        {
                            direction = Direction.Up;
                        }
                        spirale[k--, n] = 1;
                        if (k <= 0)
                        {
                            k = 0;
                        }
                        break;
                    case Direction.Up:
                        if (n <= 0)
                        {
                            direction = Direction.Right;
                        }
                        spirale[k, n--] = 1;
                        if (n <= 0)
                        {
                            n = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            return spirale;
            /*
            bool Exist(int k, int n, int[,] array, Direction direction)
            {
                int o = 0;
                try
                {
                    switch (direction)
                    {
                        case Direction.Right:
                            o = array[k + 2, n];
                            break;
                        case Direction.Down:
                            o = array[k, n + 2];
                            break;
                        case Direction.Left:
                            o = array[k - 2, n];
                            break;
                        case Direction.Up:
                            o = array[k, n - 2];
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                if (o == 1)
                {

                }
            }
        }
        */
        
        enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }

        public static string formatDuration(int seconds)
        {
            DateFormat date = new DateFormat();
            if (seconds == 0) { return "Now"; }
            else
            {
                seconds = Calculate(seconds, ref date.Years, date.SecondInYears);
                seconds = Calculate(seconds, ref date.Months, date.SecondInMonths);
                seconds = Calculate(seconds, ref date.Days, date.SecondInDays);
                seconds = Calculate(seconds, ref date.Hours, date.SecondInHours);
                seconds = Calculate(seconds, ref date.Minutes, date.SecondInMinutes);
                seconds = Calculate(seconds, ref date.Seconds, date.SecondInSeconds);
            }
            return date.ToString();

            static int Calculate(int seconds, ref int partDate, int countSeconds)
            {
                while (seconds >= countSeconds)
                {
                    partDate++;
                    seconds -= countSeconds;
                }
                return seconds;
            }
        }
        public class DateFormat 
        {
            public int Years;
            public int Months;
            public int Days;
            public int Hours;
            public int Minutes;
            public int Seconds;

            public readonly int SecondInYears = 31_536_000;
            public readonly int SecondInMonths = 2_592_000;
            public readonly int SecondInDays = 86_400;
            public readonly int SecondInHours = 3_600;
            public readonly int SecondInMinutes = 60;
            public readonly int SecondInSeconds = 1;
            public override string ToString()
            {
                List<string> strings = new List<string>();
                if (Years > 0)
                {
                    if (Years == 1) strings.Add(Years + " year");
                    else strings.Add(Years + " years");
                }
                if (Days > 0)
                {
                    if (Days == 1) strings.Add(Days + " day");
                    else strings.Add(Days + " days");
                }
                if (Hours > 0)
                {
                    if (Hours == 1) strings.Add(Hours + " hour");
                    else strings.Add(Hours + " hours");
                }
                if (Minutes > 0)
                {
                    if (Minutes == 1) strings.Add(Minutes + " minute");
                    else strings.Add(Minutes + " minutes");
                }
                if (Seconds > 0)
                {
                    if (Seconds == 1) strings.Add(Seconds + " second");
                    else strings.Add(Seconds + " seconds");
                }

                if (strings.Count > 1)
                {
                    for (int i = 1; i < strings.Count - 1; i = i + 2)
                    {
                        strings.Insert(i, ", ");
                    }
                    strings.Insert(strings.Count - 1, " and ");

                }
                string result = "";
                foreach (var item in strings)
                {
                    result += item;
                }


                return result;
            }
        }
    }
}
