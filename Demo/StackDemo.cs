public static class StackDemo
{
    public static void Demo()
    {
        string sentence1 = "[()]{}{[()()]()}";
        string sentence2 = "[(])";
        string sentence3 = ")(])";
        string sentence4 = "";
        string sentence5 = null;
        string sentence6 = "(";

        Console.WriteLine(BalancedBrackets(sentence1) + ": " + sentence1);
        Console.WriteLine(BalancedBrackets(sentence2) + ": " + sentence2);
        Console.WriteLine(BalancedBrackets(sentence3) + ": " + sentence3);
        Console.WriteLine(BalancedBrackets(sentence4) + ": " + sentence4);
        Console.WriteLine(BalancedBrackets(sentence5) + ": " + sentence5);
        Console.WriteLine(BalancedBrackets(sentence6) + ": " + sentence6);

        while (true)
            Console.WriteLine(BalancedBrackets(Console.ReadLine()));

        bool BalancedBrackets(string sentence)
        {
            if (sentence == null)
                return true;
            if (sentence.Length == 0)
                return true;

            Stack<char> stack = new Stack<char>();

            foreach (var character in sentence)
            {
                if (IsOpeningBracket(character))
                {
                    stack.Push(character);
                }
                else if (IsClosingBracket(character) && stack.Count == 0)
                {
                    return false;
                }
                else if (character == ')' && stack.Pop() != '(')
                {
                    return false;
                }
                else if (character == '}' && stack.Pop() != '{')
                {
                    return false;
                }
                else if (character == ']' && stack.Pop() != '[')
                {
                    return false;
                }
            }

            if (stack.Count == 0)
                return true;
            else
                return false;
        }

        bool IsOpeningBracket(char character)
        {
            return character == '(' || character == '{' || character == '[';
        }

        bool IsClosingBracket(char character)
        {
            return character == ')' || character == '}' || character == ']';
        }
    }
}