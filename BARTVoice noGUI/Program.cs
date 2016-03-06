using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Speech;
using System.Speech.Synthesis;

namespace BARTVoice_noGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            String URLString = "http://api.bart.gov/api/etd.aspx?cmd=etd&orig=RICH&key=MW9S-E7SL-26DU-VV8V";
            String destination;
            String t2a;
            String length;
            XmlTextReader reader = new XmlTextReader(URLString);
            SpeechSynthesizer synth = new SpeechSynthesizer();
            while (true)
            {
                reader.ReadToFollowing("etd");
                reader.Read();
                reader.Read();
                destination = reader.Value;
                reader.ReadToFollowing("minutes");
                reader.Read();
                t2a = reader.Value;
                reader.ReadToFollowing("length");
                reader.Read();
                length = reader.Value;
                synth.Speak(length + " car train for " + destination + " in " + t2a + "minutes");
                Console.ReadKey();
            }
           /* while (reader.Read()) {
                {
                   

                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);
                            Console.WriteLine(">");
                            break;

                        case XmlNodeType.Text: //Display the text in each element.
                            Console.WriteLine(reader.Value);
                            break;

                        case XmlNodeType.EndElement: //Display the end of the element.
                            Console.Write("</" + reader.Name);
                            Console.WriteLine(">");
                            break;
                    }
                }*/

                Console.ReadKey();

            }

        }
    }

