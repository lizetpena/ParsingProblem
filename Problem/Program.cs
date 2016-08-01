using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    class Program
    {
        /// <summary>
        /// This solution assumes only three levels of indentation on the input string
        /// The solution can be refactored to use recursion if there are more levels of indentation.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string input = "(id,created,employee(id,firstname,employeeType(id),lastname),location)";

            //remove first open parenthesis
            input=input.Remove(0, 1);

            List<Words> words = new List<Words>();

            Parser(input, words);
            DisplayWords(words);
            
        }

        private static void DisplayWords(List<Words> words)
        {
            Console.WriteLine("FIRST OUTPUT:");
            Console.WriteLine();

            foreach (Words i in words)
            {
                Console.WriteLine(i.name);

                foreach (Words j in i.children)
                {
                    Console.WriteLine("{0} {1}", "- ", j.name);
                    foreach (Words k in j.children)
                        Console.WriteLine("{0} {1}", "-- ", k.name);
                }

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BONUS (OUTPUT IN ALPHABETICAL ORDER):");
            Console.WriteLine();
            foreach (Words i in words.OrderBy(w => w.name))
            {
                Console.WriteLine(i.name);

                foreach (Words j in i.children.OrderBy(t => t.name))
                {
                    Console.WriteLine("{0} {1}", "- ", j.name);
                    foreach (Words k in j.children.OrderBy(d => d.name))
                        Console.WriteLine("{0} {1}", "-- ", k.name);
                }

            }


            Console.ReadLine();
        }

        private static void Parser(string input, List<Words> words)
        {
            string word = string.Empty;
            int level = 0;
            int word_count = -1;
            int child_count = -1;

            foreach (char s in input.ToCharArray())
            {
                if ((s == '(') || (s == ',') || (s == ')'))
                {
                    if ((level == 0) && (word.Length > 0))
                    {
                        words.Add(new Words(word));
                        word_count++;
                    }
                    else if ((level == 1) && (word.Length > 0))
                    {
                        words.ElementAt(word_count).children.Add(new Words(word));
                        child_count++;
                    }
                    else if (level == 2)
                    {
                        ((Words)((words.ElementAt(word_count)).children[child_count])).children.Add(new Words(word));
                    }


                    word = "";
                    if (s == '(')
                        level++;
                    if (s == ')')
                        level--;

                }
                else
                    word += s;


            }
        }

       
    }
}
