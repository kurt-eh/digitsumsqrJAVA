using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dss_challenge
{
    class Program
    {

        static void Main(string[] args)
        {
            questionOne(10);
            questionTwo(500);
            questionThree(10000000);
            Console.ReadKey();
        }
        static int digitSquareSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int number = n % 10;
                sum += (number * number);
                n = n / 10;
            }
            return sum;
        }
        static void questionOne(int n)
        {
            Console.WriteLine("Question 1:\n");
            string result = "1,1\n";
            for (int i = 2; i <= n; i++)
            {
                result += i + "," + digitSquareSum(i) + "\n";
            }
            Console.WriteLine(result);
        }
        static void questionTwo(int n)
        {
            Console.WriteLine("Question 2:\n");
            int result = 0;
            String sumsToOne = "1";
            //Console.WriteLine("\n");
            for (int i = 2; i <= n; i++)
            {
                List<int> results = new List<int>();
                bool stop = false;
                results.Add(i);
                //Console.Write("\n" + i + ": ");
                result = digitSquareSum(i);
                results.Add(result);
                //Console.Write(result + ", ");
                if (result == 1) sumsToOne += (", " + i);
                do
                {
                    result = digitSquareSum(result);
                    //Console.Write(result + ", ");
                    if (results.Contains(result))
                    {
                        stop = true;
                    }
                    else if (result == 1)
                    {
                        sumsToOne += ", " + i;
                        stop = true;
                    }
                    results.Add(result);
                } while (!stop);

            }
            Console.WriteLine(sumsToOne);
        }
        static void questionThree(int n)
        {
            Console.WriteLine("\nQuestion 3:");
            int result = 0;
            int sevenPlusExecutions = 0;
            //Console.WriteLine("\n");
            for (int i = 2; i <= n; i++)
            {
                List<int> results = new List<int>();
                bool stop = false;
                results.Add(i);
                //Console.Write("\n" + i + ": ");
                result = digitSquareSum(i);
                int j = 1;
                results.Add(result);
                //Console.Write(result + ", ");
                do
                {
                    result = digitSquareSum(result);
                    j++;
                    //Console.Write(result + ", ");
                    if (j < 7 && result == 89) stop = true;
                    else if (results.Contains(result) && !results.Contains(89)) stop = true;
                    else if (result == 89 && j > 7)
                    {
                        sevenPlusExecutions++;
                        stop = true;
                    }
                    results.Add(result);
                } while (!stop);
            }
            Console.WriteLine("\n" + sevenPlusExecutions);
        }
    }
}
