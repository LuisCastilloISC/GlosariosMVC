using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Glosarios.Data;
using Glosarios.Models;
using Microsoft.AspNetCore.Identity;
using System.Data.Sql;
using System.Data.SqlClient;
using ListedMnemonicSummaries;
using System.IO;

namespace Glosarios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        ApplicationUser miUsuario;
        public static string  NickOn ="";

        public UsuariosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: Usuarios1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        public async Task<string> Loguear(string CCorreo, string CPassword)
        {

            miUsuario = new ApplicationUser
            {
                Email = CCorreo,
                Password = CPassword
            };
            var nickname = "";
            SqlConnection conexion = new SqlConnection("Data Source=CASTILLOW10\\KINGBRADLEY;Database=Glosarios;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (conexion)
            {
                conexion.Open();
                var sql = @"select NickName from AspNetUsers Where Email= '" + miUsuario.Email + "' AND Password ='" + miUsuario.Password + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    nickname = rd[0].ToString();
                    NickOn = nickname;
                }
            }
            
            return nickname;

        }
        public IActionResult Crear()
        {
            return View();
        }
        public IActionResult Resumenes()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<String> CrearUsuarios(string CCorreo, string CNombre,
             string CApellidoPat, string CApellidoMat,
             string CNickname, string CPassword)
        {


            miUsuario = new ApplicationUser
            {
                Email = CCorreo,
                Nombre = CNombre,
                ApellidoPaterno = CApellidoPat,
                ApellidoMaterno = CApellidoMat,
                NickName = CNickname,
                UserName = CNickname,
                Password = CPassword
            };
            var resp = "";
            var result = await _userManager.CreateAsync(miUsuario, miUsuario.Password);
            if (result.Succeeded)
            {
                resp = "Save";
            }
            else
            {
                resp = "NoSave";
            }
            return resp;

        }

        //Rewriter
        public string Rewrite(string strText, string strLanguage,string strConcepto)
        {
            string strRewrited;
            Language aLanguage;
            aLanguage = LanguageFileManager.LoadLanguage(strLanguage);

            if (strText == "")
                strRewrited = Rewrite(aLanguage.TestString, strLanguage,"");
            else
            {
                strRewrited = strText.TrimStart();
                strRewrited = strRewrited.First().ToString().ToUpper() + strRewrited.Substring(1); //strText.ToLower(); Make this an option later. 
                foreach (Replaceable aReplaceable in aLanguage.Replaceables)
                    strRewrited = strRewrited.Replace(aReplaceable.Original, aReplaceable.Summarized);
                strRewrited = Polish(strRewrited);
            }
            return strConcepto.ToUpper()+".\n"+strRewrited;
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

    

    //PDF
    public  void PDF(string strTopic,string strLanguage,string strText)
        {
           
            string strTXTDirectory = "";
            string strPDFDirectory = "";
            CrearPDF(strTopic, strText, strLanguage);
            switch (strLanguage)
            {
                case "Español":
                    if (System.IO.File.Exists( strTopic + ".txt"))
                    {
                        strTXTDirectory =  strTopic + ".txt";
                        strPDFDirectory =  strTopic + ".pdf";
                    }
                    else
                        throw new Exception(strTopic + ".txt no existe.");
                    break;
                default:
                case "English":
                    if (System.IO.File.Exists(@"Listed Mnemonic Summaries\" + strTopic + ".txt"))
                    {
                        strTXTDirectory = @"Listed Mnemonic Summaries\" + strTopic + ".txt";
                        strPDFDirectory = @"Listed Mnemonic Summaries\" + strTopic + ".pdf";
                    }
                    else
                        throw new Exception(strTopic + ".txt doesn't exist.");
                    break;
            }

            using (iTextSharp.text.Document aDocument = new iTextSharp.text.Document())
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(aDocument, new System.IO.FileStream(strPDFDirectory, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite));
                aDocument.Open();
                aDocument.Add(new iTextSharp.text.Paragraph(ListedTextFileManager.Read(strTXTDirectory)));
            }
        }
        public void CrearPDF(string strTopic, string strConceptAndText, string strLanguage)
        {
            bool blnAtBeggining;
            TextFile lmnsTopic;
            switch (strLanguage)
            {
                default:
                case "English":
                    blnAtBeggining = System.IO.File.Exists(strTopic + ".txt");
                    lmnsTopic = new TextFile(strTopic + ".txt");
                    if (blnAtBeggining)
                    {                        
                        lmnsTopic.Write(strConceptAndText);
                    }
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
                    blnAtBeggining = System.IO.File.Exists(strTopic + ".txt");
                    lmnsTopic = new TextFile(strTopic + ".txt");
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
