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
        string _dbPath;
        private SQLiteConnection conn;

        public string statusMessage { get; set; }
        
        private void Init()
        {
            if (conn is not null)
                return;
                conn = new(_dbPath);
                conn.CreateTable<Persona>();
            
        }
        public PersonaRepositorio(string path)
        {
            _dbPath = path;

        }
        public void insertarPersona(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                Persona p = new() { Nombre = nombre };
                result = conn.Insert(p);
                statusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
            }
        }
        public List<Persona> obtenerPersonas()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Error:" + ex.Message);
            }
            return new List<Persona>();
        }
        public void eliminarPersona(int id)
        {
            int result = 0;
            try
            {
                Init();
                result = conn.Delete<Persona>(id);
                statusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, id);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }
        public void actualizarPersona(Persona persona)
        {
            int result = 0;
            try
            {
                Init();
                result = conn.Update(persona);
                statusMessage = string.Format("{0} record(s) updated (Id: {1})", result, persona.Id);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Failed to update {0}. Error: {1}", persona.Id, ex.Message);
            }
        }

    }
}
