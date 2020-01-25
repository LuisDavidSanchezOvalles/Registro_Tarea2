using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Entidades;

namespace Registro.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas Persona)
        {
            bool Paso = false;
            Context db = new Context();

            try
            {
                if (db.Personas.Add(Persona) != null)
                    Paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Paso;
        }

        public static bool Modificar(Personas Persona)
        {
            bool Paso = false;
            Context db = new Context();

            try
            {
                db.Entry(Persona).State = EntityState.Modified;
                Paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Paso;
        }

        public static bool Eliminar(int Id)
        {
            bool Paso = false;
            Context db = new Context();

            try
            {
                var Eliminar = db.Personas.Find(Id);
                db.Entry(Eliminar).State = EntityState.Deleted;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Paso;
        }

        public static Personas Buscar(int Id)
        {
            Personas Persona = new Personas();
            Context db = new Context();
            try
            {
                Persona = db.Personas.Find(Id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Persona;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> Persona)
        {
            List<Personas> Lista = new List<Personas>();
            Context db = new Context();
            try
            {
                Lista = db.Personas.Where(Persona).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}