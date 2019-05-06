using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListedMnemonicSummaries
{
    [Serializable]
    public class Language
    {
        public Language(string strName, List<Replaceable> replaceableList, string strTestString)
        {
            _strName = strName;
            _strTestString = strTestString;
            if (replaceableList.Count != 0)
            {
                foreach (Replaceable aReplaceable in replaceableList)                
                    Replaceables.Add(new Replaceable(aReplaceable.Original, aReplaceable.Summarized));                
                foreach (Replaceable aReplaceable in replaceableList)
                {                    
                    string strStartingWord = aReplaceable.Original.Trim();
                    Replaceables.Add(new Replaceable(strStartingWord.First().ToString().ToUpper() + strStartingWord.Substring(1) + " ", aReplaceable.Summarized));                    
                }                                    
            }                            
            else
                throw new Exception("Language items need at least one Replaceable.");            
        }

        public List<Replaceable> Replaceables = new List<Replaceable>();

        private string _strName;
        public string Name
        {
            get { return _strName; }
        }

        private string _strTestString;
        public string TestString
        {
            get { return _strTestString; }            
        }
    }
}
