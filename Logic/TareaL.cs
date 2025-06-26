using System;
using System.Collections.Generic;
using System.Linq;
using FinalASP.NET.DataAccess;
using FinalASP.NET.Models;

namespace FinalASP.NET.Logic
{
    public class TareaL
    {
        public static List<Class1> ObtenerTodos()
        {
            return TareaDAL.ObtenerTodos();

        }
        public static string Guardar(Class1 TareaTexto)
        {
            if (string.IsNullOrWhiteSpace(TareaTexto.TareaTexto))
            {
                return "El campo TareaTexto es obligatorio.";
            }
            if (TareaTexto.Fecha == default(DateTime))
            {
                return "La fecha es obligatoria.";
            }
            TareaDAL.Guardar(TareaTexto);
            return null;
        }


        public static Class1 ObtenerPorId(int id)
        {
            return TareaDAL.ObtenerPorId(id);
        }
        public static string Actualizar(Class1 TareaTexto)
        {

           TareaDAL.Actualizar(TareaTexto);
            return null;
        }
        public static string Eliminar(int id)
        {
            var TareaTexto = TareaDAL.ObtenerPorId(id);
            if (TareaTexto == null)
            {
                return "Tarea no encontrada";
            }
            TareaDAL.Eliminar(id);
            return null;
        }




    }
}