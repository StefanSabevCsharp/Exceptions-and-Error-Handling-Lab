


int number = int.Parse(Console.ReadLine());
try
{
    if (number < 0)
    {
        throw new InvalidOperationException("Invalid number.");
    }
    Console.WriteLine(Math.Sqrt(number));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}
