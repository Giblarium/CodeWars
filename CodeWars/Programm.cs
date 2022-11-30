using CodeWars;

while (Int32.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine(Kata.formatDuration(num));
}