using System;

namespace Cards
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] cardInfo = input[i].Split();
                string cardFace = cardInfo[0];
                char cardSuit = cardInfo[1].ToCharArray().First();
                try
                {
                    Card card = new Card(cardFace, cardSuit);
                    cards.Add(card);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(" ",cards));
        }
    }


    public class Card
    {
        private string face;
        private char suit;


        public Card(string face, char suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => this.face;
            set
            {
                if (!FaceValidator(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }
        public char Suit
        {
            get => this.suit;
            set
            {
                if (!SuitValidator(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.suit = value;
            }

        }

        private bool FaceValidator(string value)
        {
            return value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" ||
                   value == "8" || value == "9" || value == "10" || value == "J" || value == "Q"
                   || value == "K" || value == "A";
        }

        private bool SuitValidator(char value)
        {
            return value == 'S' || value == 'H' || value == 'D' || value == 'C';
        }

        public override string ToString()
        {
            string utfSuit = String.Empty;
            switch (this.Suit)
            {
                case 'S':
                    utfSuit = "\u2660";
                    break;
                case 'H':
                    utfSuit = "\u2665";
                    break;
                case 'D':
                    utfSuit = "\u2666";
                    break;
                case 'C':
                    utfSuit = "\u2663";
                    break;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append($"[{this.Face}{utfSuit}]");
            return sb.ToString().TrimEnd();
        }
    }
}
