using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListedMnemonicSummaries
{
    [Serializable]
    class TextFile
    {
         private FileStream _stream;
        public FileStream Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        private string _strFileName;
        public string FileName
        {
            get { return _strFileName; }
            set { _strFileName = value; }
        }

        private string _strText;
        public string Text
        {
            get { return _strText; }
            set { _strText = value; }
        }


        public TextFile(string strDirectory)
        {
            _stream = null;
            FileName = strDirectory;
        }

        public void Write(string strText)
        {
            Text = strText;
            StreamWriter streamWriter = null;
            if (File.Exists(FileName))
            {
                Stream = new FileStream(FileName, FileMode.Append);
                streamWriter = new StreamWriter(Stream);
            }
            else                
                streamWriter = new StreamWriter(FileName);

            streamWriter.Write(strText + streamWriter.NewLine);
            if (streamWriter != null)
                streamWriter.Close();
            if (Stream != null)
                Stream.Close();
        }

        public string Read()
        {
            Text = "";
            StreamReader streamReader = null;
            streamReader = new StreamReader(FileName);
            while (!streamReader.EndOfStream)
            {
                Text += streamReader.ReadLine() + "\n";                
            }
            if (streamReader != null)
                streamReader.Close();
            if (Stream != null)
                Stream.Close();
            return Text;
        }

        private void Rename(string strDirectory)
        {
            FileName = strDirectory;
        }
    }
}
