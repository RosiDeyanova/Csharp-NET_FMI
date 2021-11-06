// Fig. 8.10: DeckOfCards.cs
// DeckOfCards class represents a deck of playing cards.
using System;

public class DeckOfCards
{
   private Card[] deck; // array of Card objects
   private int currentCard; // index of next Card to be dealt
   private const int NUMBER_OF_CARDS = 52; // constant number of Cards
   private Random randomNumbers; // random number generator


    private int[] faceCounters;
    private int[] suitCounters;
    private Card[] hand;


    public DeckOfCards()
   {
        hand = new Card[5];
        faceCounters = new int[Card.faces.Length];
        suitCounters = new int[Card.suits.Length];

      deck = new Card[ NUMBER_OF_CARDS ]; // create array of Card objects
      currentCard = 0; // set currentCard so deck[ 0 ] is dealt first  
      randomNumbers = new Random(); // create random number generator

      // populate deck with Card objects
      for ( int count = 0; count < deck.Length; count++ )
         deck[ count ] =
            new Card(count % 13, count / 13);
   } // end DeckOfCards constructor

   // shuffle deck of Cards with one-pass algorithm
   public void Shuffle()
   {
      // after shuffling, dealing should start at deck[ 0 ] again
      currentCard = 0; // reinitialize currentCard

      // for each Card, pick another random Card and swap them
      for ( int first = 0; first < deck.Length; first++ )
      {
         // select a random number between 0 and 51 
         int second = randomNumbers.Next( NUMBER_OF_CARDS );

         // swap current Card with randomly selected Card
         Card temp = deck[ first ];
         deck[ first ] = deck[ second ];
         deck[ second ] = temp;
      } // end for
   } // end method Shuffle

    public void DealHand() 
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i] = DealCard();
        }
        MakeStatistics();
    }

    public bool has2Faces(int faceNumbers) 
    {
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == faceNumbers) 
            {
                return true;
            }
        }
        return false;
    }

    public bool HasSuits(int suitNumber) 
    {
        for (int i = 0; i < suitCounters.Length; i++)
        {
            if (faceCounters[i] == suitNumber)
            {
                return true;
            }
        }
        return false;
    }

    public void PrintHand() 
    {
        for (int i = 0; i < hand.Length; i++)
        {
            if (hand[i] != null)
            {
                Console.WriteLine(hand[i]);
            }
        }
    
    }

    private void MakeStatistics()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            if (hand[i]!=null)
            {
                ++faceCounters[hand[i].Face];
                ++suitCounters[hand[i].Suit];
            }
        }
    }

   // deal one Card
   public Card DealCard()
   {
      // determine whether Cards remain to be dealt
      if ( currentCard < deck.Length )
         return deck[ currentCard++ ]; // return current Card in array
      else
         return null; // indicate that all Cards were dealt
   } // end method DealCard
} // end class DeckOfCards


