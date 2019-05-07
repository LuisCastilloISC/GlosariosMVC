using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListedMnemonicSummaries
{
    public abstract class LanguageFileManager
    {
        public static void SaveLanguage(string strName)
        {
            BinaryFile<Language> file = new BinaryFile<Language>(@"Syntax\" + strName + ".synx");
            file.Close();
            file.OpenInReadWriteMode();
            switch (strName)
            {
                case "Español": file.WriteObject(LanguageCollection.Español()); break;
                case "English": file.WriteObject(LanguageCollection.English()); break;
            }
            file.Close();
        }

        public static Language LoadLanguage(string strName)
        {            
            BinaryFile<Language> file = new BinaryFile<Language>(@"Syntax\" + strName + ".synx");
            file.Close();
            file.OpenInReadMode();
            Language aLanguage = file.ReadObject();
            file.Close();
            return aLanguage;            
        }

    }
}
