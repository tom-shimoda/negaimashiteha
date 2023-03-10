class Negaimashiteha
{
    static readonly int numCount = 5;
    static readonly int numRangeMax = 1000;
    static readonly int numRangeMin = 0;

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
            Console.WriteLine($"Q{questionIndex}:");
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
                if (input.Key != ConsoleKey.Enter && input.KeyChar >= '0' && input.KeyChar <= '9')
                {
                    guess += input.KeyChar;
                    Console.Write(input.KeyChar);
                }
                else if (input.Key == ConsoleKey.Backspace && guess.Length > 0)
                {
                    guess = guess.Remove(guess.Length - 1);
                    Console.Write("\b \b");
                }
            } while (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Escape);

            Console.WriteLine();

            if (input.Key == ConsoleKey.Enter)
            {
                if (int.Parse(guess) == answer)
                {
                    Console.WriteLine("正解です！");
                }
                else
                {
                    Console.WriteLine("不正解です。正解は " + answer + " です。");
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
