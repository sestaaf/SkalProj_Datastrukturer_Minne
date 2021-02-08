using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
	class Methods
	{
		public static void ListTest(List<string> theList)
		{
            AddToList("First");
            AddToList("Second");

            Console.WriteLine("\nThis is how the list looks like now:");
            Console.WriteLine("====================================");
            ShowList(theList);

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
                            ShowList(theList);
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
                            ShowList(theList);
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

            void ShowList(List<string> showList)
            {
                foreach (var item in showList)
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

                ShowQueueQueue(queueICA);

            } while (!backToMainMenu);
            
        }

		internal static void TestStack(Stack<string> queueICA)
		{

			bool backToLastMenu = false;
			char nav = ' ';

			do
            {
                Console.WriteLine("\nMenyalternativ 1 = Ställer Kalle och Greta i kö."
                    + "\nMenyalternativ 2 = Ställer Stina och Olle i kö."
                    + "\nMenyalternativ 3 = En person lämnar kön"
                    + "\nMenyalternativ 4 = Testa att vända en sträng."
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
                        queueICA.Push("Kalle");
                        queueICA.Push("Greta");
                        ShowQueueStack(queueICA);
                        break;
                    case '2': // Ställer Stina och Olle i kö.
                        queueICA.Push("Stina");
                        queueICA.Push("Olle");
                        ShowQueueStack(queueICA);
                        break;
                    case '3': // Tar bort en person ur kön.
                        if (queueICA.Count != 0) queueICA.Pop();
                        ShowQueueStack(queueICA);
                        break;
                    case '4': // Kör reversera sträng.
                        Stack<char> testReverseStack = new Stack<char>();
                        ReverseText(testReverseStack);
                        break;
                    case 'Q': // Avslutar meny.
                    case 'q':
                        backToLastMenu = true;
                        break;
                    default:
                        break;
                }

            } while (!backToLastMenu);

        }

        private static void ReverseText(Stack<char> testReverseStack)
		{
            Console.WriteLine("\nPlease input a string to be reversed:");

            string inputFromUser = Console.ReadLine();

            char[] charArr = inputFromUser.ToCharArray();

            foreach (char ch in charArr)
            {
                testReverseStack.Push(ch);
                // Console.WriteLine(ch);
            }

            int lengthInput = inputFromUser.Length;
            string outputToUser = "";

            for (int i = 0; i < lengthInput; i++)
            {
                char fromStack;
                fromStack = testReverseStack.Peek();
                fromStack = testReverseStack.Pop();
                outputToUser += fromStack.ToString();
            }

            Console.WriteLine($"\nEntered string backwards: {outputToUser}");
        }

        internal static void CheckParantheses()
        {
            Console.WriteLine("\nPlease input a string including signs '{([])}");
            string inputFromUser = "(";
          
            var dict = new Dictionary<char, char>
            {
                {'(', ')' },
                {'[', ']' },
            };

			char[] charArr = inputFromUser.ToCharArray();
			int sum = 0;
			bool inputPairsOK = false;
			bool inputOrderOK = false;


			var stack = new Stack<char>();
            bool result = false;

            foreach (char ch in inputFromUser)
            {

            //    //

            //    if (dict.ContainsKey(ch))
            //        stack.Push(ch);
            //    else if (dict.ContainsValue(ch) && stack.Count != 0)
            //    {
            //       return dict[stack.Pop()] != ch;

            //    }
            //}
                        
                switch (ch)
				{
                    
                    case '(':
                        sum += 1;
                        break;
                    case '{':
                        sum += 1;
                        break;
                    case '[':
                        sum += 1;
                        break;
                    case ')':
                        sum -= 1;
                        break;
                    case '}':
                        sum -= 1;
                        break;
                    case ']':
                        sum -= 1;
                        break;
                    default:
                        break;
				}
			}



            if (sum != 0) inputPairsOK = false;
            else
            {
                inputPairsOK = true;

                for (int i = 0; i < inputFromUser.Length - 1; i++)
                {
					{
                        for (int j = 1; j <= inputFromUser.Length; j++)
                        {
                            if (charArr[i] == '(' && charArr[j] != '}' && charArr[j] != ']')
                            { inputOrderOK = false; break; }
                            else if (charArr[i] == '{' && charArr[j] != ')' && charArr[j] != ']')
                            { inputOrderOK = false; break; }
                            else if (charArr[i] == '[' && charArr[j] != ')' && charArr[j] != '{')
                            { inputOrderOK = false; break; }
                            else if (charArr[i] == '(' && charArr[j] != '(' && charArr[j] != '{' && charArr[j] != '[') continue;
                            else if (charArr[i] == '{' && charArr[j] != '}') continue;
                            else if (charArr[i] == '[' && charArr[j] != ']') continue;
                        }
					}
                    if (!inputOrderOK) break;
                }
            }

            if (inputPairsOK && inputOrderOK)
            {
                Console.WriteLine("The string you entered has the Parantheses in right order.\n");
            }
            else
            {
                Console.WriteLine("The string you entered is NOT OK as the Parantheses comes in the wrong order.");
                Console.WriteLine("And/Or the pairs of Parantheses doesn't match\n");
            }

        }

        // Here starts methods that are called upon from above.
        private static void ShowQueueQueue(Queue<string> showQueue)
        {
            Console.Write($"\nPeople in Queue: {showQueue.Count}");
            Console.Write($"\nWho in Queue: ");
            PrintValues(showQueue);
        }
        private static void ShowQueueStack(Stack<string> showQueue)
        {
            Console.Write($"\nPeople in Queue: {showQueue.Count}");
            Console.Write($"\nWho in Queue: ");
            PrintValues(showQueue);
        }
        private static void PrintValues(IEnumerable<string> printQueue)
        {
            foreach (string customer in printQueue)
                Console.Write($"{customer} ");
            Console.WriteLine();
        }
	}
}

