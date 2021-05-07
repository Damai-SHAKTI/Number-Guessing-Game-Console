using System;

namespace Gussing_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GuessingGame game = new GuessingGame(50, 0, 100, 4);
            game.Start();
        }
    }

    public class GuessingGame
    {
        private byte Answer = 0, Minumum = 0, Maximum = 100, MaxPlayers = 2, PlayerId = 0, PlayerGuess = 0;

        public GuessingGame(byte _answer, byte _minimum, byte _maximum, byte _maxPlayers)
        {
            this.Answer = _answer;
            this.Minumum = _minimum;
            this.Maximum = _maximum;
            this.MaxPlayers = _maxPlayers;
        }
        public void Start()
        {
            while (this.PlayerGuess != this.Answer)
            {
                this.AssignPlayerId();
                try
                {
                    Console.Write(@"Guess A Number Between {0} to {1} (Player {2}): ", this.Minumum, this.Maximum, this.PlayerId);
                    this.PlayerGuess = Convert.ToByte(Console.ReadLine());
                    if (this.PlayerGuess > this.Maximum || this.PlayerGuess < this.Minumum)
                    {
                        this.CustomColorConsole(ConsoleColor.Red, "Out Of Range!");
                    }
                    else if (this.PlayerGuess > this.Answer)
                    {
                        this.Maximum = (byte)(this.PlayerGuess - 1);
                    }
                    else if (this.PlayerGuess < this.Answer)
                    {
                        this.Minumum = (byte)(this.PlayerGuess + 1);
                    }
                    else if (this.PlayerGuess == this.Answer)
                    {
                        this.CustomColorConsole(ConsoleColor.Green, String.Format("Player {0} Win!", this.PlayerId));
                    }
                }
                catch(Exception e)
                {
                    this.CustomColorConsole(ConsoleColor.Red, "Invalid Input!");
                }
            }
        }
        private byte AssignPlayerId()
        {
            if (this.PlayerId == 0 || this.PlayerId == this.MaxPlayers)
            {
                this.PlayerId = 1;
            }
            else
            {
                this.PlayerId++;
            }

            return this.PlayerId;
        }

        private void CustomColorConsole(ConsoleColor _foreGroundColour, string _message, ConsoleColor _backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = _backgroundColor;
            Console.ForegroundColor = _foreGroundColour;
            Console.WriteLine(_message);
            Console.ResetColor();
        }

    }
}
