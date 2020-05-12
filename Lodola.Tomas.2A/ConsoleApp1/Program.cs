using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shopping alto_palermo = 5;

            Comerciante a = new Comerciante("Alberto", "Samudio");
            Comerciante b = new Comerciante("Juan", "Leirado");
            Exportador e1 = new Exportador("Electrónica 80", 15200f, "Domingo", "Caballo", Exportador.ETipoProducto.Tecnologia);
            Importador i1 = new Importador("Granola S.A.", 23900f, a, Importador.EPaises.UnionEuropea);
            Exportador e2 = new Exportador("Matarife", 29095f, "Joe", "Molleja", Exportador.ETipoProducto.Rural);
            Importador i2 = new Importador("Matarife", 203000f, a, Importador.EPaises.Taiwan);
            Importador i3 = new Importador("Matarife", 98000f, a, Importador.EPaises.China);
            Importador i4 = new Importador("Matarife", 10350f, b, Importador.EPaises.UnionEuropea);

            alto_palermo += e1;
            alto_palermo += e1;
            alto_palermo += i1;
            alto_palermo += e2;
            alto_palermo += i2;
            alto_palermo += i3;
            alto_palermo += i4;

            Console.WriteLine(Shopping.Mostrar(alto_palermo));

            Console.ReadKey();
        }
    }
}
