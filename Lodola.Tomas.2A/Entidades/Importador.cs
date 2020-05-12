using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Importador : Comercio
    {
        public enum EPaises
        {
            China,
            Taiwan,
            UnionEuropea
        }

        #region Atributos
        public EPaises paisOrigen;
        #endregion

        #region Constructor
        public Importador(string nombreComercio,float precioAlquiler,Comerciante comerciante,EPaises paisOrigen):
            base(nombreComercio,comerciante,precioAlquiler)
        {
            this.paisOrigen = paisOrigen;
        }
        #endregion

        #region Operadores

        public static implicit operator double(Importador n)
        {
            return n._precioAlquiler;
        }

        public static bool operator ==(Importador a, Importador b)
        {
            bool retorno = false;
            if (!Object.Equals(a, null) && !Object.Equals(b, null))
            {
                if (a.paisOrigen == b.paisOrigen && (Comercio)a == (Comercio)b)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Importador a, Importador b)
        {
            return !(a == b);
        }

        #endregion

        #region Atributos

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(((Comercio)this));
            sb.AppendLine($"TIPO: {this.paisOrigen}");

            return sb.ToString();
        }
        #endregion
    }
}
