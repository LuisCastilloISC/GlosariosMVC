using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListedMnemonicSummaries
{
    public static class LanguageCollection
    {
        public static Language Español()
        {
            string strNombre = "Español";
            string strPrueba = "Esta es una prueba que va hacia el inicio o el final y hacia el infinito. A decir verdad, quisiera vivir mi futuro junto a ti.";            
            // Prueba → inicio/final, → infinito. Decir verdad, quisiera vivir futuro+ti.
            
            List<Replaceable> Reemplazables = new List<Replaceable>();

            //ESPAÑOL'S DEFAULT REPLACEABLES 
            //
            //  Add: ante cabe cuando entre según sobre //// durante mientras hasta
            //
            //Multiword Replaceables
            Reemplazables.Add(new Replaceable(" mayor que ", " > "));
            Reemplazables.Add(new Replaceable(" menor que ", " < "));            
            Reemplazables.Add(new Replaceable(" sin embargo, ", " pero, "));
            Reemplazables.Add(new Replaceable(" sin embargo ", " pero "));
            Reemplazables.Add(new Replaceable(" no obstante ", " pero "));
            Reemplazables.Add(new Replaceable(" todos y cada uno ", " *&c/u "));
            Reemplazables.Add(new Replaceable(" cada uno ", " * c/u "));
            Reemplazables.Add(new Replaceable(" con el propósito de ", " para "));

        //
        //Replaceables
            Reemplazables.Add(new Replaceable(" arriba ", " ↑ "));
            Reemplazables.Add(new Replaceable(" abajo ", " ↓ ")); //bajo
            Reemplazables.Add(new Replaceable(" bajo ", " ↓ "));
            Reemplazables.Add(new Replaceable(" contra ", " vs ")); //vs.
            Reemplazables.Add(new Replaceable(" hacia ", " → ")); 
            Reemplazables.Add(new Replaceable(" mayor ", " > "));
            Reemplazables.Add(new Replaceable(" menor ", " < "));
            Reemplazables.Add(new Replaceable(" sintaxis ", " syntax "));            
            Reemplazables.Add(new Replaceable(" vasca ", " vasconia "));
            Reemplazables.Add(new Replaceable(" versus ", " vs ")); // vs.
            //
            //Left Sided Replaceables            
            Reemplazables.Add(new Replaceable("mente ", "mt "));
            //
            //Blank Replaceables "Deletables" "Eatables"
            Reemplazables.Add(new Replaceable(" a "));
            Reemplazables.Add(new Replaceable(" al "));
            Reemplazables.Add(new Replaceable(" aquel ")); //ese
            Reemplazables.Add(new Replaceable(" aquella ")); //esa
            Reemplazables.Add(new Replaceable(" cada ")); 
            Reemplazables.Add(new Replaceable(" de "));
            Reemplazables.Add(new Replaceable(" del "));
            Reemplazables.Add(new Replaceable(" el "));            
            Reemplazables.Add(new Replaceable(" en "));            
            Reemplazables.Add(new Replaceable(" es "));
            Reemplazables.Add(new Replaceable(" ese "));
            Reemplazables.Add(new Replaceable(" esta "));
            Reemplazables.Add(new Replaceable(" este "));
            Reemplazables.Add(new Replaceable(" fue "));
            Reemplazables.Add(new Replaceable(" ha "));
            Reemplazables.Add(new Replaceable(" hay "));
            Reemplazables.Add(new Replaceable(" que "));
            Reemplazables.Add(new Replaceable(" la "));
            Reemplazables.Add(new Replaceable(" las "));
            Reemplazables.Add(new Replaceable(" le "));
            Reemplazables.Add(new Replaceable(" lo "));
            Reemplazables.Add(new Replaceable(" los "));
            Reemplazables.Add(new Replaceable(" me "));
            Reemplazables.Add(new Replaceable(" mi "));
            Reemplazables.Add(new Replaceable(" para "));
            Reemplazables.Add(new Replaceable(" se "));
            Reemplazables.Add(new Replaceable(" siendo "));
            Reemplazables.Add(new Replaceable(" su "));
            Reemplazables.Add(new Replaceable(" solo "));
            Reemplazables.Add(new Replaceable(" somos "));
            Reemplazables.Add(new Replaceable(" son "));
            Reemplazables.Add(new Replaceable(" todo "));
            Reemplazables.Add(new Replaceable(" todos "));
            Reemplazables.Add(new Replaceable(" un "));
            Reemplazables.Add(new Replaceable(" una "));
            Reemplazables.Add(new Replaceable(" va "));
            Reemplazables.Add(new Replaceable(" así mismo"));
            //
            //Right Sided Replaceables
            Reemplazables.Add(new Replaceable(" siempre ", " ∞")); //∞
            Reemplazables.Add(new Replaceable(" toda ", " *")); //∞
            Reemplazables.Add(new Replaceable(" todos ", " *")); //∞
            Reemplazables.Add(new Replaceable(" entre otros", " etc")); 
            Reemplazables.Add(new Replaceable(" etcétera", " etc"));
            Reemplazables.Add(new Replaceable(" aumento ", " ++"));
            Reemplazables.Add(new Replaceable(" incremento ", " ++"));
            Reemplazables.Add(new Replaceable(" decremento ", " --"));
            Reemplazables.Add(new Replaceable(" disminución ", " --"));

            //
            //Joining Replaceables "Joinables" "Space Deletion Replaceables"            
            Reemplazables.Add(new Replaceable(" y/o ", "&/"));
            Reemplazables.Add(new Replaceable(" y ", "&"));
            Reemplazables.Add(new Replaceable(" e ", "&"));
            Reemplazables.Add(new Replaceable(" o ", "/"));
            Reemplazables.Add(new Replaceable(" u ", "/"));
            Reemplazables.Add(new Replaceable(" por ", "×"));
            Reemplazables.Add(new Replaceable(" mediante ", "×"));
            Reemplazables.Add(new Replaceable(" tras ", "×"));
            Reemplazables.Add(new Replaceable(" vía ", "×"));
            Reemplazables.Add(new Replaceable(" desde", "×"));
            Reemplazables.Add(new Replaceable(" junto ", "+"));
            Reemplazables.Add(new Replaceable(" con ", "+"));
            Reemplazables.Add(new Replaceable(" más ", "+"));
            Reemplazables.Add(new Replaceable(" igual ", "="));
            Reemplazables.Add(new Replaceable(" iguales ", "="));
            Reemplazables.Add(new Replaceable(" idéntico ", "="));
            Reemplazables.Add(new Replaceable(" idéntica ", "="));
            Reemplazables.Add(new Replaceable(" sin ", "-"));
            Reemplazables.Add(new Replaceable(" menos ", "-"));            

            Language español = new Language(strNombre, Reemplazables, strPrueba);            
            return español;
        }

        public static Language English()
        {
            string strName = "English";
            string strTest = "Time is a valuable thing. Watch it fly by as the pendulum swings. Watch it count down to the end of the day. The clock ticks life away.";                 
            //Time valuable. Watch fly pendulum swings. Watch count down end day. Clock ticks life away.
            List<Replaceable> Replaceables = new List<Replaceable>();
            
            //Multiword Replaceables
            Replaceables.Add(new Replaceable(" greather than ", " > "));

            //Replaceables                                    
            Replaceables.Add(new Replaceable(" cannot ", " can't "));
            Replaceables.Add(new Replaceable(" next ", " → "));
            Replaceables.Add(new Replaceable(" to ", " → "));
            Replaceables.Add(new Replaceable(" versus ", " vs "));

            //Right Sided Replaceables            
            Replaceables.Add(new Replaceable(" forever ", " ∞")); //∞

            //Blank Replaceables "Deletables" "Eatables"
            Replaceables.Add(new Replaceable(" a "));
            Replaceables.Add(new Replaceable(" all "));
            Replaceables.Add(new Replaceable(" an "));
            Replaceables.Add(new Replaceable(" as "));
            Replaceables.Add(new Replaceable(" are "));
            Replaceables.Add(new Replaceable(" each "));
            Replaceables.Add(new Replaceable(" in "));                               
            Replaceables.Add(new Replaceable(" it "));            
            Replaceables.Add(new Replaceable(" by "));
            Replaceables.Add(new Replaceable(" of "));
            Replaceables.Add(new Replaceable(" that "));
            Replaceables.Add(new Replaceable(" the "));          
            Replaceables.Add(new Replaceable(" thing "));
            Replaceables.Add(new Replaceable(" was "));

            //Left Sided Replaceables            
            Replaceables.Add(new Replaceable(" and ", "&"));            
            Replaceables.Add(new Replaceable(" am ", "'m "));
            Replaceables.Add(new Replaceable(" will ", "'ll "));
            Replaceables.Add(new Replaceable(" would ", "'d "));            
            Replaceables.Add(new Replaceable(" has ", "'s "));
            Replaceables.Add(new Replaceable(" have ", "'ve "));                        
            Replaceables.Add(new Replaceable(" is ", "'s "));
            Replaceables.Add(new Replaceable(" not ", "n't "));            

            //Joining Replaceables "Joinables" "Space Deletion Replaceables"
            Replaceables.Add(new Replaceable(" or ", "/"));
            Replaceables.Add(new Replaceable(" equal ", "="));
            Replaceables.Add(new Replaceable(" identical ", "="));

            Language english = new Language(strName, Replaceables, strTest);            
            return english;
        }
    }
}
