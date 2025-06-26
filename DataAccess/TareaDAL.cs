using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FinalASP.NET.Models;

namespace FinalASP.NET.DataAccess
{
    public class TareaDAL
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        // Método para obtener todas las tareas de la base de datos
        public static List<Class1> ObtenerTodos()
        {
            // Crear una lista para almacenar las tareas
            List<Class1> lista = new List<Class1>();

            // Establecer la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                // Definir la consulta SQL para obtener todas las tareas
                string query = "SELECT * FROM Tareas";

                // Crear un comando SQL con la consulta y la conexión
                SqlCommand comando = new SqlCommand(query, conexion);

                // Abrir la conexión
                conexion.Open();

                // Ejecutar el comando y obtener un lector de datos
                SqlDataReader reader = comando.ExecuteReader();

                // Leer los datos y agregarlos a la lista
                while (reader.Read())
                {
                    lista.Add(new Class1
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TareaTexto = reader["TareaTexto"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"])
                    });

                }
            }
            // Devolver la lista de tareas
            return lista;
        }

        // Método para guardar una tarea en la base de datos
        public static void Guardar(Class1 TareaTexto)
        {
            // Establecer la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                // Definir la consulta SQL para insertar una nueva tarea
                string query = "INSERT INTO Tareas (TareaTexto, Fecha) VALUES (@TareaTexto, @Fecha)";
                // Crear un comando SQL con la consulta y la conexión
                SqlCommand comando = new SqlCommand(query, conexion);
                // Agregar los parámetros al comando
                comando.Parameters.AddWithValue("@TareaTexto", TareaTexto.TareaTexto);
                comando.Parameters.AddWithValue("@Fecha", TareaTexto.Fecha);
                // Abrir la conexión
                conexion.Open();
                // Ejecutar el comando para insertar la tarea
                comando.ExecuteNonQuery();
            }
        }

        // Método para obtener una tarea por su ID
        public static Class1 ObtenerPorId(int id)
        {
            // Establecer la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                // Definir la consulta SQL para obtener una tarea por su ID
                string query = "SELECT * FROM Tareas WHERE Id = @Id";

                // Crear un comando SQL con la consulta y la conexión
                SqlCommand comando = new SqlCommand(query, conexion);

                // Agregar el parámetro al comando
                comando.Parameters.AddWithValue("@Id", id);

                // Abrir la conexión
                conexion.Open();

                // Ejecutar el comando y obtener un lector de datos
                SqlDataReader reader = comando.ExecuteReader();

                // Verificar si se encontró una tarea
                if (reader.Read())
                {
                    return new Class1
                    {
                        Id = (int)reader["Id"],
                        TareaTexto = reader["TareaTexto"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"])
                    };
                }
            }
            // Si no se encontró ninguna tarea, devolver null
            return null;
        }

        // Método para actualizar una tarea en la base de datos
        public static void Actualizar(Class1 TareaTexto)
        {
            // Establecer la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                // Definir la consulta SQL para actualizar una tarea
                string query = "UPDATE Tareas SET TareaTexto = @TareaTexto, Fecha = @Fecha WHERE Id = @Id";

                // Crear un comando SQL con la consulta y la conexión
                SqlCommand comando = new SqlCommand(query, conexion);

                // Agregar los parámetros al comando
                comando.Parameters.AddWithValue("@TareaTexto", TareaTexto.TareaTexto);
                comando.Parameters.AddWithValue("@Fecha", TareaTexto.Fecha);
                comando.Parameters.AddWithValue("@Id", TareaTexto.Id);

                // Abrir la conexión
                conexion.Open();

                // Ejecutar el comando para actualizar la tarea
                comando.ExecuteNonQuery();
            }
        }

        // Método para eliminar una tarea por su ID
        public static void Eliminar(int id)
        {
            // Establecer la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                // Definir la consulta SQL para eliminar una tarea por su ID
                string query = "DELETE FROM Tareas WHERE Id = @Id";

                // Crear un comando SQL con la consulta y la conexión
                SqlCommand comando = new SqlCommand(query, conexion);

                // Agregar el parámetro al comando
                comando.Parameters.AddWithValue("@Id", id);

                // Abrir la conexión
                conexion.Open();

                // Ejecutar el comando para eliminar la tarea
                comando.ExecuteNonQuery();
            }
        }
    }
}