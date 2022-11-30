namespace CodeWars
{
    internal class ToHex
    {
        public static string DoSomething(int r, int g, int b)
        {
            return IntToHex(r) + IntToHex(g) + IntToHex(b); ;

            string IntToHex(int color)
            {
                if (color < 0)
                {
                    return "00";
                }
                if (color > 255)
                {
                    return "FF";
                }
                int division = color / 16;
                int remainder = color % 16;
                return GetHex(division) + GetHex(remainder); ;

                string GetHex(int value)
                {
                    switch (value)
                    {
                        case >= 0 and <= 9:
                            return value.ToString();
                        case 10:
                            return "A";
                        case 11:
                            return "B";
                        case 12:
                            return "C";
                        case 13:
                            return "D";
                        case 14:
                            return "E";
                        case 15:
                            return "F";
                        default:
                            return "";
                    }
                }
            }
        }
    }
}
