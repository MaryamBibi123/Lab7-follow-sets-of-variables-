namespace FirstFollowSet
{
    class Program
    {
        static int limit, x = 0;
        
        static char[,] production = new char[10, 10];
        static char[] array = new char[10];
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //To signify empty space.
                    production[i, j] = '-';
                }
            }
            int count = 0;
            char option, ch;
            Console.WriteLine("\nEnter Total Number of Productions:\t");
           
            limit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(limit);
            for (count = 0; count < limit; count++)
            {
                Console.WriteLine("\nValue of Production Number {0}:\t", count + 1);
            String temp = Console.ReadLine();
                for (int i = 0; i < temp.Length; i++)
                {
                    production[count, i] = temp[i];
                }
            }
            // Keep asking the user for non-terminal for which follow_set is needed.
        do
            {
                x = 0;
                Console.WriteLine("\nEnter production Value to Find Follow:\t");
               
                ch = Console.ReadKey().KeyChar;
                find_follow(ch);
                Console.WriteLine("\nFollow Value of {0}:\t", ch);
                for (count = 0; count < x; count++)
                {
                    Console.Write(array[count]);
                }
                Console.Write("}\n");
                Console.Write("To Continue, Press Y:\t");
                option = ch = Console.ReadKey().KeyChar;
            } while (option == 'y' || option == 'Y');
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   
                Console.Write(production[i, j]);
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
        static void find_follow(char ch)
        {
            int i = 0, j;
            for (int k = 0; k < 10; k++)
            {
                
            }
            int length = 10;
            if (Convert.ToChar(production[0, 0]).Equals(ch))
            {
                array_manipulation('$');
            }
            for (i = 0; i < limit; i++)
            {
                for (j = 2; j < length; j++)
                {
                    if (Convert.ToChar(production[i, j]).Equals(ch))
                    {
                        if (Convert.ToChar(production[i, j + 1]).Equals('\0'))
                        {
                            find_first(Convert.ToChar(production[i, j + 1]));
                        }
                        if (Convert.ToChar(production[i, j +
                       1]).Equals('\0') && ch.Equals(Convert.ToChar(production[i, 0])))
                        {
                            find_follow(Convert.ToChar(production[i, 0]));
                        }
                    }
                }
            }
        }
        static void find_first(char ch)
        {
            int i = 0, k;
            //Check for uppercase letter. 
            int val = System.Convert.ToInt32(ch);
            if (!(val >= 97 && val <= 122))
            {
                array_manipulation(ch); 
            }
            for (k = 0; k < limit; k++)
            {
                if (production[k, 0].Equals(ch))
                {
                    if (production[k, 2].Equals('$'))
                    {
                        find_follow(Convert.ToChar(production[i,
                       0]));
                    }
                    //Check for lowercase.
                    else if (Convert.ToInt32((production[k, 2])) >=
                   97 && Convert.ToInt32((production[k, 2])) <= 122)
                    {

                        array_manipulation(Convert.ToChar(production[k, 2]));
                    }
                    else
                    {
                        find_first(Convert.ToChar(production[k, 2]));
                    }
                }
            }
        }
        static void array_manipulation(char ch)
        {
            int count;
            for (count = 0; count <= x; count++)
            {
                if (array[count].Equals(ch))
                {
                    return;
                }
            }
            array[x++] = ch;
        }
    }
}