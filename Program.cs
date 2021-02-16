using System;
using System.Linq;


namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKey = new ConsoleKeyInfo();

         Repeat:
                
                int numberForCheck;
                Console.WriteLine("Input some number more than 999 and less 100,000,000");
                string number = Console.ReadLine().Trim();
                var check = Int32.TryParse(number, out numberForCheck);
                if(number.Length > 8 || number.Length < 4)
                {
                   Console.WriteLine("Pleas input only numbers more than 999 and less 100,000,000. Try again");
                    goto Repeat; 
                }
                if (!check)
                {
                    Console.WriteLine("Pleas input only numbers. Try again");
                    goto Repeat;
                }
                bool result = IsLucky(numberForCheck);
                if (result)
                {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The number of ticket is lucky");
                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number of ticket is not lucky");
                }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you wanna continue? If YES - press any key, No - N ");
            consoleKey = Console.ReadKey();
            if(consoleKey.KeyChar == 'n' || consoleKey.KeyChar == 'N') 
            {
                Environment.Exit(0);
            }
            Console.Clear();
                goto Repeat;
            
        }

        public static bool IsLucky(Int32 number) 
        {
            string lucky = String.Empty;
            int result = number.ToString().Length;
            
            if (result % 2 != 0)
            
                lucky = "0" + number.ToString();
            
            else
            
                lucky = number.ToString();
            
            int onepart = CheckStr(lucky);
            string  str = new string( lucky.Reverse().ToArray());
            int secondpart = CheckStr(str);
            return onepart == secondpart;

        }

        public static int CheckStr(string number) 
        {
            int result = 0;
            for(int x = 0; x < number.Length/2; x++) 
            {
                result += Convert.ToInt32(number[x].ToString());
            }
            return result;
        }
    }
}
