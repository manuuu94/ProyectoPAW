using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        //se instancia una conexion y alIDALGenerico que contiene los métodos genéricos.
        private readonly PROYECTO_PAWContext context;
        //public IDALGenerico<Queja> quejaDAL;
        //public IDALGenerico<TablaGeneral> tablaDAL;
        public IDALGenerico<T> genericDAL;


        public UnidadDeTrabajo(PROYECTO_PAWContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);         
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
