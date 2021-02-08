using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
	class FacitTillEfter
	{
		private static bool IsWellFormated(string input)
		{
			Dictionary<char, char> dict = GetDict();

			var stack = new Stack<char>();

			foreach (var c in input)
			{
				if (stack.Count == 0 && dict.ContainsValue(c))
					return false;

				if (dict.ContainsValue(c) && dict[stack.Pop()] != c) 
					return false;

				if (dict.ContainsKey(c)) stack.Push(c);
			}

			return stack.Count == 0;
		}

		private static Dictionary<char, char> GetDict()
		{
			return new Dictionary<char, char>
			{
				{ '{', '}' },
				{ '(', ')' },
				{ '[', ']' },
				{ '<', '>' }
			};
		}
	}
}
