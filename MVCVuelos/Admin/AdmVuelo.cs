using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCVuelos.Models;
using MVCVuelos.Data;
using System.Data.Entity;

namespace MVCVuelos.Admin
{
    public static class AdmVuelo
    {
        private static VueloDbContext context = new VueloDbContext();
        public static List<Vuelo> Listar()
        {
            var vuelos = context.Vuelos.ToList();
            return vuelos;
        }
        public static List<Vuelo> ListarPorDestino(string destino)
        {
            var vuelos = (from v in context.Vuelos
                          where v.Destino == destino
                          select v).ToList();
            return vuelos;
        }
        public static void Crear(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            context.SaveChanges();
        }
        public static Vuelo BuscarPorId(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            return vuelo;
        }
        public static void Eliminar(Vuelo vuelo)
        {
            context.Vuelos.Remove(vuelo);
            context.SaveChanges();
        }
        public static void Modificar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.SaveChanges();
        }
        public static Vuelo BuscarPorIdParaDestino(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            context.Entry(vuelo).State = EntityState.Detached;
            context.SaveChanges();
            return vuelo;
        }
    }
}