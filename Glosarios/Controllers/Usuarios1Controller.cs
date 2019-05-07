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

namespace Glosarios.Controllers
{
    public class Usuarios1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        ApplicationUser miUsuario;

        public Usuarios1Controller(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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
        public async Task<String> CrearUsuario(string CCorreo, string CNombre,
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

    }
       
}
