using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Speech;

namespace BARTVoice_noGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            String URLString = "http://api.bart.gov/api/etd.aspx?cmd=etd&orig=RICH&key=MW9S-E7SL-26DU-VV8V";
            XmlTextReader reader = new XmlTextReader(URLString);
            



            for (int i = 0; i <= 6; i++)
            {
                Console.WriteLine("TACOS");
                reader.Read();

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


                Console.ReadKey();

            }

        }
    }
}

