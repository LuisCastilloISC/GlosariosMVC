using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ListedMnemonicSummaries
{
    public  class Rewriter
    {
       
        public string Rewrite(string strText, string strLanguage)
        {
            string strRewrited;
            Language aLanguage;
            aLanguage = LanguageFileManager.LoadLanguage(strLanguage);

            if (strText == "")              
               strRewrited = Rewrite(aLanguage.TestString, strLanguage);            
            else
            {
                strRewrited = strText.TrimStart();
                strRewrited = strRewrited.First().ToString().ToUpper() + strRewrited.Substring(1); //strText.ToLower(); Make this an option later. 
                foreach (Replaceable aReplaceable in aLanguage.Replaceables)                
                    strRewrited = strRewrited.Replace(aReplaceable.Original, aReplaceable.Summarized);                    
                strRewrited = Polish(strRewrited);
            }        
            return strRewrited;
        }

        public static string Polish(string strText)
        {
            string strRewrited = strText.Replace("  ", " ");
            strRewrited = strRewrited.Trim();
            return ConvertForCapitalization(strRewrited, '.'); ;
        }

        public static List<string> CapitalizeSentences(List<string> cSentences)
        {
            List<string> capitalizedSentences = new List<string>();
            foreach (string strString in cSentences)
                capitalizedSentences.Add(strString.First().ToString().ToUpper() + strString.Substring(1));
            return capitalizedSentences;
        }

        public static string ConvertForCapitalization(string strText, char chrCharacter)
        {
            List<string> sentences = TextToSentences(strText, chrCharacter);
            string strRewrited = SentencesToText(sentences);
            if (CapitalizeSentences(sentences).Count > 0)
                return strRewrited.TrimStart().First().ToString().ToUpper() + strRewrited.TrimStart().Substring(1);
            else
            {
                if (strText.TrimStart() != "")
                    return strText.TrimStart().First().ToString().ToUpper() + strText.TrimStart().Substring(1);
                else
                    return "";
            }
                
        }

        public static List<string> TextToSentences(string strText, char chrCharacter)
        {
            List<string> sentences = new List<string>();
            int intPosition = 0;
            int intStart = 0;
            do
            {
                intPosition = strText.IndexOf(chrCharacter, intStart);
                if (intPosition >= 0)
                {
                    sentences.Add(strText.Substring(intStart, intPosition - intStart + 1).Trim());
                    intStart = intPosition + 1;
                }
            } while (intPosition > 0);

            return sentences;
        }

        public static string SentencesToText(List<string> sentences)
        {
            string strRewrited = "";
            foreach (string strString in CapitalizeSentences(sentences))
            {
                if (strString[strString.Length - 1] != ' ')
                    strRewrited += strString + " ";
                else
                    strRewrited += strString;
            }
            return strRewrited;
        }

    }
}
