using GyCPersonal.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Repositorios.RepositorioProductos repo = new RepositorioProductos(new DbContext("MiDB"));
            Console.ReadLine();
        }
    }
}
