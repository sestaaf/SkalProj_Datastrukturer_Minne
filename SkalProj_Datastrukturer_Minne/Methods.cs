using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
	class Methods
	{
		public static void TestQueue(Queue<string> queueICA)
		{
            bool backToMainMenu = false;
            char nav = ' ';

            do
            {
                Console.WriteLine("\nMenyalternativ 1 = Ställer Kalle och Greta i kö."
                    + "\nMenyalternativ 2 = Ställer Stina och Olle i kö."
                    + "\nMenyalternativ 3 = En person lämnar kön"
                    + "\n\nEnter Q to be returned to the Main Menu.");
                Console.Write("Input > ");

                string input = Console.ReadLine();

                try
                {
                    nav = input[0];
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease enter some input!");
                }

                switch (nav)
                {
                    case '1': // Ställer Kalle och Greta i kö.
                        queueICA.Enqueue("Kalle");
                        queueICA.Enqueue("Greta");
                        break;
                    case '2': // Ställer Stina och Olle i kö.
                        queueICA.Enqueue("Stina");
                        queueICA.Enqueue("Olle");
                        break;
                    case '3': // Tar bort en person ur kön.
                        if (queueICA.Count != 0) queueICA.Dequeue();
                        break;
                    case 'Q': // Avslutar meny.
                    case 'q':
                        backToMainMenu = true;
                        break;
                    default:
                        break;
                }

                ShowQueue(queueICA);

            } while (!backToMainMenu);
        }

        private static void ShowQueue(Queue<string> showQueueICA)
        {
            Console.Write($"\nPeople in Queue: {showQueueICA.Count}");
            Console.Write($"\nWho in Queue: ");
            PrintValues(showQueueICA);
        }
        private static void PrintValues(IEnumerable<string> printQueueICA)
        {
            foreach (string customer in printQueueICA)
                Console.Write($"{customer} ");
            Console.WriteLine();
        }


    }

}

