using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListedMnemonicSummaries
{
    public abstract class ListedTextFileManager
    {
        public static void Write(string strTopic, string strConceptAndText, string strLanguage)
        {
            bool blnAtBeggining;
            TextFile lmnsTopic;
            switch (strLanguage)
            {
                default:
                case "English":
                    blnAtBeggining = File.Exists(@"Listed Mnemonic Summaries\" + strTopic + ".txt");
                    lmnsTopic = new TextFile(@"Listed Mnemonic Summaries\" + strTopic + ".txt");
                    if (blnAtBeggining)
                        lmnsTopic.Write(strConceptAndText);
                    else
                    {
                        lmnsTopic.Write("Listed Mnemonic Summary Designer by Pablo Lavín, 2019.");
                        lmnsTopic.Write("Date: " + DateTime.Now.ToShortDateString());
                        lmnsTopic.Write("Author: " + Environment.UserName);
                        lmnsTopic.Write("Topic: " + strTopic.ToUpper());
                        lmnsTopic.Write("");
                        lmnsTopic.Write(strConceptAndText);
                    }
                    break;
                case "Español":
                    blnAtBeggining = File.Exists(@"Resúmenes Mnemotécnicos Listados\" + strTopic + ".txt");
                    lmnsTopic = new TextFile(@"Resúmenes Mnemotécnicos Listados\" + strTopic + ".txt");
                    if (blnAtBeggining)
                        lmnsTopic.Write(strConceptAndText);
                    else
                    {
                        lmnsTopic.Write("Diseñador de Resumen Mnemotécnico Listado por Pablo Lavín, 2019.");
                        lmnsTopic.Write("Fecha: " + DateTime.Now.ToShortDateString());
                        lmnsTopic.Write("Autor: " + Environment.UserName);
                        lmnsTopic.Write("Tema: " + strTopic.ToUpper());
                        lmnsTopic.Write("");
                        lmnsTopic.Write(strConceptAndText);
                    }
                    break;
            }

            
        }
    }
}
