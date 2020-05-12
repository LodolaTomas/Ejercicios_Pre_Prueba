using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Exportador : Comercio
    {
        public enum ETipoProducto
        {
            Tecnologia,
            Rural,
            Varios
        }

        #region Atributo
        public ETipoProducto tipo;
        #endregion

        #region Constructor
        public Exportador(string nombreComercio,float precioAlquiler,string nombre,string apellido,ETipoProducto tipo):
            base(precioAlquiler,nombreComercio,nombre,apellido)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos


        #endregion
        #region Operadores
        public static implicit operator double(Exportador m)
        {
            return m._precioAlquiler;
        }

        public static bool operator ==(Exportador a, Exportador b)
        {
            bool retorno = false;
            if (!Object.Equals(a, null) && !Object.Equals(b, null))
            {
                if (a.tipo == b.tipo && (Comercio)a == (Comercio)b)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Exportador a, Exportador b)
        {
            return !(a == b);
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(((Comercio)this));
            sb.AppendLine($"TIPO: {this.tipo}");

            return sb.ToString();
        }

        #endregion


    }
}
