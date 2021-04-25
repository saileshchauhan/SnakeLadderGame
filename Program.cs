using System;

namespace SnakeLadderGame
{
    class Program
    {
        
        public static void Main(string[] args)

        {   int chance = 0, diceCount1 = 0,  diceCount = 0, Player2Score = 0, Player1Score=0;
            int dice1; int dice2;

            Random random = new Random();
            Program program = new Program();

            //Caling Function Player Selection
            int gameAllotment = random.Next(0, 2);
            chance = program.PlayerSelection(chance, gameAllotment);
            
            do
            {
                if (chance % 2 == 0)
                {
                    Console.WriteLine("Dice Rolls for Player 2 ");
                    
                    dice2 = random.Next(1, 7);
                    diceCount++;
                    switch (random.Next(0,3))
                    {
                        case 0:
                            Console.WriteLine("No play");
                            Console.WriteLine("Player2Score   " + Player2Score);
                            chance++;
                            break;
                        case 1:
                            Console.WriteLine("Snake Step back");
                            Player2Score -= dice2;
                            Console.WriteLine("Player2Score   " + Player2Score);
                            chance++;
                            break;
                        case 2:
                            Console.WriteLine("Ladder StepUP you will get one more chance");
                            Player2Score += dice2;
                            Console.WriteLine("Player2Score after climbing up    " + Player2Score);
                            break;
                    }
                    //Function for checking score
                    Player2Score = program.CheckNegative(Player2Score);
                    Player2Score = program.CheckOver20(Player2Score, dice2);
                }
                else if (chance % 2 != 0)
                {
                    Console.WriteLine("Dice Rolls for Player 1 ");
                    dice1 = random.Next(1, 7);
                    diceCount1++;
                    switch (random.Next(0, 3))
                    {
                        case 0:
                            Console.WriteLine("No play");
                            Console.WriteLine("Player1Score   " + Player1Score);
                            chance++;
                            break;
                        case 1:
                            Console.WriteLine("Snake Step back");
                            Player1Score -= dice1;
                            Console.WriteLine("Player1Score   " + Player1Score);
                            chance++;
                            break;
                        case 2:
                            Console.WriteLine("Ladder StepUP you will get one more chance");
                            Player1Score += dice1;
                            Console.WriteLine("Player1Score after climbing up    " + Player1Score);
                            break;
                    }

                    //using DRY Principle//
                    Player1Score = program.CheckNegative(Player2Score);
                    Player1Score = program.CheckOver20(Player1Score,dice1);
                }
            } while (Player2Score < 20 && Player1Score < 20);
            
            Console.WriteLine("**************************************************************************");
            int totalDiceCount = diceCount + diceCount1;
            Console.WriteLine("Player1  "+Player1Score+"\nPlayer2  "+Player2Score);

            //usind DRY Principle to check win//
            program.Checkwin(Player1Score,Player2Score,diceCount,diceCount1,totalDiceCount);
        }
        //Main Method End-----------------------------Main Method End//



        public void Checkwin(int Player1Score,int Player2Score, int diceCount,int diceCount1, int totalDiceCount)
        {
            if (Player1Score == 20)
            {
                Console.WriteLine("Player1 Won  " + Player1Score);
                Console.WriteLine("DiceCountRolled by Player1  " + diceCount);
                Console.WriteLine("TotalDiceCount    " + totalDiceCount);
            }
            else if (Player2Score == 20)
            {
                Console.WriteLine("Player2 Won  " + Player2Score);
                Console.WriteLine("DiceCountRolled by Player2  " + diceCount1);
                Console.WriteLine("TotalDiceCount    " + totalDiceCount);
            }
        }
        public int CheckNegative(int player)
        {
            if (player < 0)
            {
                player = 0;
            }
            return player;
        }
        public int CheckOver20(int player,int dice)
        {
            if (player > 20)
            {
                player -= dice;
            }
            return player;
        }
        public int PlayerSelection(int chance,int gameAllotment)
        {
            switch (gameAllotment)
            {
                case 0:
                    Console.WriteLine("Player 1 will Start the game");
                    chance = 1;
                    break;
                case 1:
                    Console.WriteLine("Player 2 will Start the game");
                    chance = 2;
                    break;
            }
            return chance;

        }
    }
}
