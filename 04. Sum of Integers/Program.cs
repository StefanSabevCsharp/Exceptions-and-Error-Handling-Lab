string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

int sum = 0;
foreach (string item in input)
{
    try
    {
        if (!int.TryParse(item, out int currentNum))
        {
            throw new FormatException($"The element '{item}' is in wrong format!");
        }

        sum += currentNum;
        Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (OverflowException ex)
    {
        Console.WriteLine($"The element '{item}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"The total sum of all integers is: {sum}");

    }
}

