using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Glosarios.Data;
using Glosarios.Models;
using ListedMnemonicSummaries;
using Tesseract;


namespace Glosarios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUsuario,Nombre,ApellidoMaterno,ApellidoPaterno,NickName,Password,status,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("idUsuario,Nombre,ApellidoMaterno,ApellidoPaterno,NickName,Password,status,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
        //rewriter
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
        public string Polish(string strText)
        {
            string strRewrited = strText.Replace("  ", " ");
            strRewrited = strRewrited.Trim();
            return ConvertForCapitalization(strRewrited, '.'); ;
        }
        public List<string> CapitalizeSentences(List<string> cSentences)
        {
            List<string> capitalizedSentences = new List<string>();
            foreach (string strString in cSentences)
                capitalizedSentences.Add(strString.First().ToString().ToUpper() + strString.Substring(1));
            return capitalizedSentences;
        }

        public string ConvertForCapitalization(string strText, char chrCharacter)
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

        public List<string> TextToSentences(string strText, char chrCharacter)
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

        public string SentencesToText(List<string> sentences)
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
        private static TesseractEngine _engine;
        private static TesseractEngine Engine
        {
            get
            {
                if (_engine == null || _engine.IsDisposed)
                {
                    _engine = new TesseractEngine($@"C:\wamp\www\MVC glosarios\GlosariosMVC\Glosarios\tessdata", "spa",EngineMode.TesseractOnly);

                }
                return _engine;
            }
        }
        public string ReconocerTexto()
        {
            string ocrResult="";           
            string imageFilePath = @"C:\Users\arman\Desktop\1.PNG";
            var pix = Pix.LoadFromFile(imageFilePath);
            var page = Engine.Process(pix);
            ocrResult = page.GetText();
            Engine.Dispose();
            return ocrResult;
        }

    }

}

 


