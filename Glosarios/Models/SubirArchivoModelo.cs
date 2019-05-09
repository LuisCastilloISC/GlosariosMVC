using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace Glosarios.Models
{
    public class SubirArchivoModelo 
    {
        public string Confirmacion
        {
            get;set;
        }
        public string rutaImg
        {
            get;set;
        }
        public Exception Error { get; set; }
        public void SubirArchivo(IFormFile file)
        {
            try
            {
                var Ruta = "~/img/";
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(Ruta,FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    this.Confirmacion = "Fichero Guardado";
                    this.rutaImg = "~/img/" + file.FileName;
                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}