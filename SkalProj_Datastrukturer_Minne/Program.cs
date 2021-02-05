using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
		private static object input;

		/// <summary>
		/// The main method, vill handle the menues for the program
		/// </summary>
		/// <param name="args"></param>
		static void Main()
        {
            // 4.0.1: Stacken fungerar så att "sist in - först ut" och ser till att rensa i minnet
            //        då den är självunderhållande. Stacken hanterar anrop och metoder med Value Types.
            //        Heapen hanterar många saker samtidigt utan nån egentlig koll på var allt finns
            //        och om exekveringen är klar eller ej. Garbage Collector tar hand om det som sen
            //        ligger och skräpar. Heapen hanterar alltid Reference Types och de Value Types 
            //        som har deklarerats i en Reference Type.
            // 4.0.2: Reference Types är exempelvis klasser, objekt, interface, delegater och strängar.
            //        Value Types finns i System.ValueType, som bool, enum, char, struct och alla
            //        varianter som håller siffervärden, som exempelvis int och double m fl.
            //        Reference Types.
            // 4.0.3: I första exemplet är x och y Value Types och y skriver därför inte över x.
            //        I det andra exemplet refererar x och y till samma Reference Type och därför
            //        skriver tilldelningen av MyValue i y över MyValue-värdet i x.


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application\n");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            /*  Svar på frågor uppgift 1:
             *  =========================
                2) Listans kapacitet ökar när naästa tillägg kommer efter att den slagit i taket.
                3) Med det dubbla mot vad den hade som kapacitet innan.
                4) Skulle väl bli för segt då.
                5) Nej, men det går att med "theList.TrimExcess()" ta ner den till samma som aktuellt Count-värde.
                   Det går också att explicit sätta ett värde själv med Capacity som är större än lika som aktuell kapacitet.
             */

            List<string> theList = new List<string>();
            
            AddToList("First");
            AddToList("Second");

			Console.WriteLine("\nThis is how the list looks like now:");
            Console.WriteLine("====================================");
            ShowList();
			
            bool backToMainMenu = false;
            char nav = ' ';

            do
            {
                Console.WriteLine("Please enter input like \"+Word\" or \"-Word\""
                    + "\nto either Add or Remove \"Word\" to the list."
                    + "\nEnter Q to be returned to the Main Menu.");
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
                    case '-':
                        if (input.Length == 1) Console.WriteLine("Only '-' is entered.");
                        else
                        {
                            input = input.Substring(1);
							Console.WriteLine($"The word '{input}' are now Removed from the list (if exist).");
                            RemoveFromList(input);
							Console.WriteLine("\nThe list now looks like this:");
							Console.WriteLine("=============================");
                            ShowList();
                        }
                        break;
                    case '+':
                        if (input.Length == 1) Console.WriteLine("Only '+' is entered.");
                        else
                        {
                            input = input.Substring(1);
                            Console.WriteLine($"The word '{input}' are now Added to the list.");
                            AddToList(input);
                            Console.WriteLine("\nThe list now looks like this:");
                            Console.WriteLine("=============================");
                            ShowList();
                        }
                        break;
                    case 'Q': // Avslutar meny.
                    case 'q':
                        backToMainMenu = true;
						Console.WriteLine("You will now be returned to the Main Menu.\n");
                        break;
                    default:
                        break;
                }


            } while (!backToMainMenu);

            void ShowList()
            {
                foreach (var item in theList)
                {
                    Console.WriteLine(item);

                }
                Console.WriteLine("\nCapacity: {0}", theList.Capacity);
                Console.WriteLine("Count: {0}\n", theList.Count);
            }
            void AddToList(string addToList)
            {
                theList.Add(addToList);
            }
            void RemoveFromList(string removeFromList)
            {
                theList.Remove(removeFromList);
            }
        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queueICA = new Queue<string>();

            Methods.TestQueue(queueICA);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            bool backToMainMenu = false;
            char nav = ' ';
            Queue<string> queueICA = new Queue<string>();

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
            static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

