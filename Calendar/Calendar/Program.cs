using System;


namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int year, leapCnt, nonLeapCnt, day, month, date, remainDay;
                string temp;
                bool leap = false, complete = false;
                int[] monthCnt = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                again:
                Console.Write("Enter year: ");
                temp = Console.ReadLine();
                if (DigitsOnly(temp) == false)         //Check year contains only digits or not
                {
                    Console.WriteLine("Year should contains only digits.");
                    goto again;
                }
                year = Convert.ToInt32(temp);
                if (year < 1900 || year > 2030)         //Check year is in range or not
                {
                    Console.WriteLine("Year should be in between 1900 to 2030");
                    goto again;
                }
                again1:
                Console.Write("Enter month number: ");
                temp = Console.ReadLine();
                if (DigitsOnly(temp) == false)         //Check month contains only digits or not
                {
                    Console.WriteLine("Month should contains only digits.");
                    goto again1;
                }
                month = Convert.ToInt32(temp);
                if (month < 1 || month > 12)            //Check month is in range or not
                {
                    Console.WriteLine("Month should be in between 1 to 12");
                    goto again1;
                }

                if (year % 100 == 0)                //Check year is century year or not 
                {
                    if (year % 400 == 0)            //Check year is century leap year or not 
                    {
                        leap = true;
                    }
                }
                else if (year % 4 == 0)             //Check year is leap year or not 
                {
                    leap = true;
                }
                if (leap == true)
                {
                    monthCnt[1] = 29;               //Change no of days of feb month due to leap year 
                }
                leapCnt = (year - 1) / 4;           //Count total leap year 
                nonLeapCnt = (year - 1) - leapCnt;  //Count total non-leap year
                day = ((leapCnt * 2) + nonLeapCnt);
                for (int i = 0; i < month - 1; i++)
                {
                    day = day + monthCnt[i];        //Count total extra days
                }
                day = day % 7;
                remainDay = 7 - day;
                Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
                date = 1;
                while (day > 0)
                {
                    Console.Write("\t");
                    day--;
                }
                for (int i = 0; i < remainDay; i++)
                {
                    Console.Write(" " + date + "\t");
                    date++;
                }
                Console.WriteLine("");
                while (complete != true)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (date < 10)                 //For right justification 
                        {
                            Console.Write(" " + date + "\t");
                        }
                        else
                        {
                            Console.Write(date + "\t");
                        }

                        date++;
                        if (date > monthCnt[month - 1])
                        {
                            complete = true;
                            break;
                        }
                    }
                    Console.WriteLine("");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error..");
            }
            Console.ReadKey();

        }

        static bool DigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
