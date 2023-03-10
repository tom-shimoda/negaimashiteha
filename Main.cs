class Negaimashiteha
{
    static readonly int numCount = 5;
    static readonly int numRangeMax = 1000;
    static readonly int numRangeMin = -1000;

    static void Main()
    {
        Random rnd = new Random();
        ConsoleKeyInfo input;
        int questionIndex = 1;

        do
        {
            List<int> nums = new List<int>();
            int answer = 0;

            // 問題生成
            for (int i = 0; i < numCount; i++)
            {
                var num = rnd.Next(numRangeMin, numRangeMax);
                nums.Add(num);
                answer += num;
            }

            // 問題表示
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Q{questionIndex}:");
            Console.ResetColor();
            foreach (var v in nums)
            {
                Console.WriteLine($"{v}");
            }
            Console.WriteLine("?");

            // 回答処理
            string guess = "";
            do
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Backspace && guess.Length > 0)
                {
                    guess = guess.Remove(guess.Length - 1);
                    Console.Write("\b \b");
                }
                else if (input.Key != ConsoleKey.Enter &&
                (input.KeyChar == '-' || (input.KeyChar >= '0' && input.KeyChar <= '9')))
                {
                    if (guess.Length > 0)
                    {
                        if (guess.Length == 1)
                        {
                            var startNum = guess[0] == '-' ? '1' : '0';
                            if (input.KeyChar >= startNum && input.KeyChar <= '9')
                            {
                                guess += input.KeyChar;
                                Console.Write(input.KeyChar);
                            }
                        }
                        else
                        {
                            if (input.KeyChar >= '0' && input.KeyChar <= '9')
                            {
                                guess += input.KeyChar;
                                Console.Write(input.KeyChar);
                            }
                        }
                    }
                    else
                    {
                        if (input.KeyChar == '-' || (input.KeyChar >= '1' && input.KeyChar <= '9'))
                        {
                            guess += input.KeyChar;
                            Console.Write(input.KeyChar);
                        }
                    }
                }
            } while (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Escape);

            Console.WriteLine();

            if (input.Key == ConsoleKey.Enter)
            {
                if (int.Parse(guess) == answer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("正解です！");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("不正解です。正解は " + answer + " です。");
                    Console.ResetColor();
                }
                Console.WriteLine("--------------------------");
            }
            else // ESCキーが押された場合
            {
                Console.WriteLine("問題を終了します。");
                break;
            }

            questionIndex++;
        } while (true);
    }
}
