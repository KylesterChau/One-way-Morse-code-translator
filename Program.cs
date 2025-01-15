using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Morse_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String morse = "";
            string[] morseCode = {".----","..---","...--","....-",".....","-....",
            "--...","---..","----.","-----",".-","-...","-.-.","-..",".","..-.",
            "--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",
            ".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
            string alphanumeric = "1234567890abcdefghijklmnopqrstuvwxyz";
            char[] chars = alphanumeric.ToCharArray();
            Console.Write("Enter sentence to translate into morse code: ");
            //Takes in the input and converts it to lowercase
            String sentence = Console.ReadLine().ToLower();
            for (int i = 0; i < sentence.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < chars.Length; j++)
                {
                    //sets the index to the position of the character in the array
                    if (chars[j] == sentence[i])
                    {
                        index = j;
                        break;
                    }
                }
                //adds the morse code to the string
                morse += morseCode[index]+ " ";
            }
            Console.WriteLine(morse);
            Console.Write("Would you like to play the morse code as a sound?(Y/N) ");
            //Asks the user if they would like to play the morse code as a sound
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
            {
                foreach(char thing in morse)
                {
                    int freq = 800;
                    int dur = 0;
                    //checks what character the variable thing is and
                    //sets the duration accordingly
                    switch (thing)
                    {
                        case '.':
                            dur = 100;
                            break;
                        case '-':
                            dur = 300;
                            break;
                        case ' ':
                            Thread.Sleep(700);
                            break;
                    }
                    //Plays the sound if the duration has been changed
                    if (dur > 0) 
                    { 
                        Console.Beep(freq, dur);
                        Thread.Sleep(100);
                    }
                }
            }
            else
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
