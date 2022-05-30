using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConvertToRimFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string answer;
            bool engine = true;
            while (true)
            {
                answer = Console.ReadLine();
                try
                {   
                    if(answer == "quit")
                    {
                        engine = false;
                    }
                    else
                    {
                        int toConvert = Convert.ToInt32(answer);
                        Rim test = new Rim(toConvert);
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    Rim test = new Rim(answer);
                }
            }
        }
    }

    public class Rim
    {
        int thousand;
        int hundred;
        int desyatki;
        int oneNumber;
        string answer = "";
        int answerInt = 0;
        Dictionary<char, int> map = new Dictionary<char, int>()
        {
            {'M',1000  },
            {'D',  500},
            {'C',  100},
            {'L', 50 },
            {'X',  10},
            {'V', 5 },
            {'I', 1 }
        };

        public Rim(int kiril)
        {
            thousand = kiril / 1000;
            hundred = (kiril % 1000) / 100 ;
            desyatki = (kiril % 100) / 10;
            oneNumber = (kiril % 10);
            Convert();
        }

        public Rim(string rim)
        {
            char[] chars = rim.ToCharArray();
            for(int i=0; i < chars.Length; i++)
            {
                if(i + 1 < chars.Length && map[chars[i]] > map[chars[i + 1]])
                {
                    answerInt += map[chars[i]];
                }
                else if(i + 1 < chars.Length && map[chars[i]] < map[chars[i + 1]])
                {
                    answerInt += map[chars[i + 1]] - map[chars[i]];
                    i += 1;
                }
                else
                {
                    answerInt += map[chars[i]];
                }
            }
            Console.WriteLine(answerInt);
        }

        public void Convert()
        {
            thousandConvert();
            hundredConvert();
            desyatkiConvert();
            oneNumberConvert();
            Console.WriteLine(answer);
        }

        public void thousandConvert()
        {
            if(thousand == 0)
            {

            }
            else
            {
                answer += string.Concat(Enumerable.Repeat("M", thousand)); 
            }
        }

        public void hundredConvert()
        {
            if(hundred != 0)
            {
                if(hundred < 5)
                {
                    answer += string.Concat(Enumerable.Repeat("C", hundred));
                }
                else
                {
                    answer += 'D';
                    answer += string.Concat(Enumerable.Repeat("C", hundred - 5));
                }
            }
        }
        
        public void desyatkiConvert()
        {
            if(desyatki != 0)
            {
                if (desyatki < 4)
                {
                    answer += string.Concat(Enumerable.Repeat("X", desyatki));
                }
                else if (desyatki == 4)
                    answer += "XL";
                else if (desyatki == 5)
                    answer += 'L';
                else if (desyatki > 5 && desyatki < 9)
                {
                    answer += 'L';
                    answer += string.Concat(Enumerable.Repeat("X", desyatki - 5));
                }  
                else answer += "XC";
            }
        }

        public void oneNumberConvert()
        {
            if (oneNumber != 0)
            {
                if (oneNumber < 4)
                {
                    answer += string.Concat(Enumerable.Repeat("I", oneNumber));
                }
                else if (oneNumber == 4)
                    answer += "IV";
                else if (oneNumber == 5)
                    answer += 'V';
                else if (oneNumber > 5 && oneNumber < 9)
                {
                    answer += 'V';
                    answer += string.Concat(Enumerable.Repeat("I", oneNumber - 5));
                }
                    
                else answer += "IX";
            }
        }

    }
}
