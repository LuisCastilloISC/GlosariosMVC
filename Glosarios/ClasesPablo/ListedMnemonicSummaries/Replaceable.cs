using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListedMnemonicSummaries
{
    [Serializable]
    public class Replaceable
    {
        public Replaceable(string strOriginal, string strSummarized)
        {
            _strOriginal = strOriginal;
            _strSummarized = strSummarized;
        }

        public Replaceable(string strOriginal)
        {
            _strOriginal = strOriginal;
            _strSummarized = " ";
        }

        private string _strOriginal;
        public string Original
        {
            get { return _strOriginal; }
            set { _strOriginal = value; }
        }

        private string _strSummarized;
        public string Summarized
        {
            get { return _strSummarized; }
            set { _strSummarized = value; }
        }

    }
}
