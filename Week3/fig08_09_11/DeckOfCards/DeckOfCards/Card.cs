public class Card
{

    public static string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six",
         "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
    public static string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };


    private int face;
    private int suit;

    public Card(int cardFace, int cardSuit)
    {
        face = cardFace;
        suit = cardSuit;
    }

    public int Face
    {
        get { return face; }
        set { face = value < faces.Length && value >= 0 ? value : 0; }
    }

    public int Suit
    {
        get { return suit; }
        set { suit = value < suits.Length && value >= 0 ? value : 0; }
    }

    public override string ToString()
    {
        return faces[face] + " of " + suits[suit];
    }
}


