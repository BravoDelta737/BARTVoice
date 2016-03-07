using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Speech;
using System.Speech.Synthesis;
using System.Threading;

namespace BARTVoice_noGUI
{
    class Program
    {
         static void Main(string[] args)
        {
            String[] trainOne;
            String[] trainTwo;
            String[] trainThree;
            String atStation = Console.ReadLine();
            String URLString = "http://api.bart.gov/api/etd.aspx?cmd=etd&orig=" + atStation + "&key=MW9S-E7SL-26DU-VV8V";
            String destination;
            String t2a;
            String length;
            XmlTextReader reader = new XmlTextReader(URLString);
            SpeechSynthesizer synth = new SpeechSynthesizer();
            gatherInfo(reader);
            reader.ResetState();
            Console.ReadKey();
            gatherInfo(reader);
            
            

            
            }

            public static void gatherInfo(XmlTextReader reader)
        {
            String[] trainArray = new String[3];
            reader.ReadToFollowing("station");
            reader.Read();
            reader.Read();
            trainArray[0] = reader.Value;
            Console.WriteLine(reader.LinePosition);
            //The loop is doing something to the reader. It works without it
            //Checks for an error message in the XML
            /*if (reader.ReadToFollowing("error"))
            {
                //Moves the reader off the element error and puts it on the text inside the element
                reader.Read();//Reads the text(in this case, the error)
                Console.WriteLine("error " + reader.Value);*/

           // }
            //else 
            //{
                
                //Don't think read to following method is working
                reader.ReadToFollowing("etd");
                //If there is not an error, read all the info and put it in the array trainArray
                Console.WriteLine(reader.LinePosition); 
                reader.ReadToDescendant("destination");
                reader.Read();
                //May not be reading the right information!!!
                trainArray[1] = reader.Value;//Stores the value of the 
                reader.ReadToFollowing("minutes");
                reader.Read();
                trainArray[2]= reader.Value;
                reader.ReadToFollowing("length");
                reader.Read();
                //trainArray[3] = reader.Value;
                //Calls the method that dispalys the info
                dispalyTrainInfo(trainArray);
            //}
           

        }

        public static void dispalyTrainInfo(String[] array)
        {
            //Prints train info to the console
            Console.WriteLine("You are currently at " + array[0] + " station");
            Console.WriteLine("This train is headed for " + array[1]);
            Console.WriteLine("It will arrive in " + array[2] + " minutes");
            //Console.WriteLine("It is" + array[3] +" cars in length");

        }

        }
    }

