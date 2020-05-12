using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    

    public class Shopping
    {

        public enum EComercio
        {
            Importador,
            Exportador,
            Ambos
        }

        #region Atributos

        private int _capacidad;
        private List<Comercio> _comercios;

        #endregion

        #region Constructores

        private Shopping()
        {
            this._comercios = new List<Comercio>();
        }

        private Shopping(int capacidad):this()
        {
            this._capacidad = capacidad;
        }

        #endregion

        #region Propiedades

        public double PrecioDeExportadores
        {
            get { return this.ObtenerPrecio(EComercio.Exportador); }
        }

        public double PrecioDeImportadores
        {
            get { return this.ObtenerPrecio(EComercio.Importador); }
        }


        public double PrecioTotal
        {
            get { return this.ObtenerPrecio(EComercio.Ambos); }
        }
        #endregion

        #region Operadores

        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
        }

        public static bool operator ==(Shopping s, Comercio c)
        {
            bool retorno = false;
            if (!Object.Equals(s, null) && !Object.Equals(c, null))
            {
                foreach (Comercio item in s._comercios)
                {
                    if(item == c)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Shopping s, Comercio c)
        {
            return !(s == c);
        }

        public static Shopping operator +(Shopping s, Comercio c)
        {
            if (s != c && s._comercios.Count < s._capacidad)
            {
                s._comercios.Add(c);
            }
            else if (s._comercios.Count >= s._capacidad)
            {
                Console.WriteLine("No hay mas capacidad en el Shopping !!");
            }
            else
            {
                Console.WriteLine("El comercio ya esta en el shopping");
            }

            return s;
        }

        #endregion

        #region Metodos

        public static string Mostrar(Shopping s)
        {
            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine($"Capacidad del Shopping: {s._capacidad}");
            sb.AppendLine($"Total por Importadores: ${s.PrecioDeImportadores}");
            sb.AppendLine($"Total por Exportadores: ${s.PrecioDeExportadores}");
            sb.AppendLine($"Total: ${s.PrecioTotal}");
            sb.AppendLine("*************************************************************");
            sb.AppendLine("Listado  de Comercios");
            sb.AppendLine("*************************************************************");
            foreach (Comercio item in s._comercios)
            {
                if(item is Exportador)
                {
                    sb.Append(((Exportador)item).Mostrar());
                }
                else
                {
                    sb.Append(((Importador)item).Mostrar());
                }
            }

            return sb.ToString();
        }

        private double ObtenerPrecio(EComercio tipoComercio)
        {
            double gananciaExportador = 0;
            double gananciaImportador = 0;
            double retorno = 0;

            foreach (Comercio item in this._comercios)
            {
                if (item is Importador)
                {
                    gananciaExportador += (Importador)item;
                }
                else if (item is Exportador)
                {
                    gananciaImportador += (Exportador)item;
                }
            }

            switch (tipoComercio)
            {
                case EComercio.Exportador:
                    retorno = gananciaExportador;
                    break;

                case EComercio.Importador:
                    retorno = gananciaImportador;
                    break;

                case EComercio.Ambos:
                    retorno = gananciaExportador + gananciaImportador;
                    break;
            }

            return retorno;
        }

        #endregion
    }
}
