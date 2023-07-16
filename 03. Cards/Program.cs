



string[] dec = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToArray();
List<Card> cards = new List<Card>();

foreach (var item in dec)
{
    string[] currentCard = item.Split(" ");
    string face = currentCard[0];
    string suit = currentCard[1];
   cards.Add(CreateCard(face, suit));
}


Card CreateCard(string face, string suit)
{
    try
    {
        Card card = new Card(face, suit);
        return card;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
}
Console.WriteLine(string.Join(" ",cards));

public class Card
{
    private readonly string[] validFaces = new string[]
    {
            "2","3","4","5","6","7","8","9","10","J","Q","K","A"
    };
    private readonly Dictionary<string, string> validSuits = new Dictionary<string, string>()
        {

            {"S","♠"},
            {"H","♥"},
            {"D","♦"},
            {"C","♣"}
        };
    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get => face;
        set
        {
            if (!validFaces.Contains(value))
            {
                throw new InvalidOperationException("Invalid card!");
            }

            face = value;
        }
    }
    public string Suit
    {
        get => suit;
        set
        {
            if (!validSuits.ContainsKey(value))
            {
                throw new InvalidOperationException("Invalid card!");
            }
            string currentSuit = validSuits[value];
            suit = currentSuit;
        }
    }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}