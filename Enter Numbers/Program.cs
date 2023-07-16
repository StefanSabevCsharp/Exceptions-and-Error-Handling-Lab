int start = 1;
int end = 100;
List<int> numbers = new List<int>();

ReadNumbers(start, end);


void ReadNumbers(int start, int end)
{
    try
    {
        while (numbers.Count < 10)
        {

            int currentNumber = int.TryParse(Console.ReadLine(), out currentNumber) ? currentNumber : throw new InvalidOperationException("Invalid Number!");

            if (currentNumber <= start || currentNumber >= end)
            {
                throw new InvalidOperationException($"Your number is not in range {start} - {end}!");
            }
            if (numbers.Count == 0)
            {
                numbers.Add(currentNumber);
                continue;
            }
           
            numbers.Add(currentNumber);
            int lastAddedNumber = numbers[numbers.Count - 1];
            start = lastAddedNumber;

        }
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
        if(numbers.Count != 10)
        {

        ReadNumbers(start, end);
        }
    }


}

Console.WriteLine(string.Join(", ", numbers));
