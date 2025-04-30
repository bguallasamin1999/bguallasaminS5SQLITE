using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bguallasaminS5.Modelo;
using SQLite;

namespace bguallasaminS5.Repositorio
{
    public class PersonaRepositorio
    {
        string dbPath;
        private SQLiteConnection db;

        public string statusMessage { get; set; }
        public PersonaRepositorio(string path)
        {
            dbPath = path;

        }
        private void Initialize()
        {
            if (db is not null)
            {
                return;
                db = new(dbPath);
                db.CreateTable<Persona>();
            }
        }
        public void insertarPersona(string persona)
        {
            int resultado = 0;
            try
            {
                Initialize();
                if (string.IsNullOrEmpty(persona))
                {
                    statusMessage = "El nombre no puede estar vacio";
                    return;
                }
                Persona p = new() { Nombre = persona };
                resultado = db.Insert(p);
                statusMessage = resultado == 1 ? "Persona insertada correctamente" : "Error al insertar la persona";
            }
            catch (Exception ex)
            {

                statusMessage = $"Error: {ex.Message}";
            }
        }
        public List<Persona> obtenerPersonas()
        {

            try
            {
                Initialize();
                return db.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Error:" + ex.Message);
            }
            return new List<Persona>();
        }

        public void eliminarPersona(int persona)
        {

        }
    }
}
