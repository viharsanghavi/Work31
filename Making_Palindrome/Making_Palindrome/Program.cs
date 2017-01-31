using System;

using System.Linq;

namespace Making_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string str;
                int start = 0, end, b = 0;
                bool palr = false, print = false;
                char[] buff = new char[100];
                Console.Write("Enter String: ");
                str = Console.ReadLine();
                char[] str1 = str.ToCharArray();
                char[] reverse = str.ToCharArray();
                Array.Reverse(reverse);
                if (Enumerable.SequenceEqual(str1, reverse) == true) //Check whether string is palindrome or not
                {
                    Console.WriteLine("String is already Palindrome");
                }
                else
                {
                    char[] pal = new char[str1.Length];
                    end = str1.Length - 1;
                    for (int i = 0; i < str1.Length; i++)
                    {
                        palr = false;
                        if (str1[i] == ' ')
                        {
                            continue;
                        }

                        for (int j = i + 1; j < str1.Length; j++)
                        {
                            if (str1[i] == str1[j])  //Comparing with other characters
                            {
                                pal[start++] = str1[i];
                                pal[end--] = str1[j];
                                str1[j] = ' ';  // Removing character from array
                                palr = true;
                                break;

                            }
                        }
                        if (palr == false) //Check character has one occurance or not
                        {
                            buff[b++] = str1[i];
                        }
                        if (b >= 2)    //Check no of characters with one occurance 
                        {
                            Console.WriteLine("String can't be palindrome");
                            print = true;
                            break;
                        }

                    }
                    if (b == 1)
                    {
                        pal[start] = buff[0];    // Copy buffer character to main array 
                    }
                    if (print == false)
                    {
                        string temp = new string(pal);
                        Console.Write("Palindrome String: " + temp);

                    }




                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error...");
            }
            Console.ReadKey();
        }
           
        
    }
}
