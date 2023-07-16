

string[] input = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries).ToArray();

Dictionary<decimal,decimal> result = new Dictionary<decimal,decimal>();

foreach (var item in input)
{
    string[] currentAccount = item.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
    
    decimal account = decimal.Parse(currentAccount[0]);
    decimal balance = decimal.Parse(currentAccount[1]);
    result.Add(account, balance);
    
}

string command = Console.ReadLine();

while(command != "End")
{

    string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
    string action = tokens[0];
    decimal account = decimal.Parse(tokens[1]);
    decimal amount = decimal.Parse(tokens[2]);

    try
    {
        if(action != "Deposit" && action != "Withdraw")
        {
            throw new InvalidOperationException("Invalid command!");
        }
        if (action == "Deposit")
        {
            if (!result.ContainsKey(account))
            {
                throw new InvalidOperationException("Invalid account!");
            }
            result[account] += amount;
            PrintBallance(result, account, amount);
        }
        else if (action == "Withdraw")
        {
            if (!result.ContainsKey(account))
            {
                throw new InvalidOperationException("Invalid account!");
            }
            if (result[account] < amount)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }
            result[account] -= amount;
            PrintBallance(result, account, amount);

        }
    }
    catch(InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
    command = Console.ReadLine();
}

void PrintBallance(Dictionary<decimal,decimal> accounts,decimal account, decimal amount)
{
    Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
}