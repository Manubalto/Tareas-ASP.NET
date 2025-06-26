using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASP.NET.Models
{
    public class Class1
    {
        public int Id { get; set; }

        
        public string TareaTexto { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}