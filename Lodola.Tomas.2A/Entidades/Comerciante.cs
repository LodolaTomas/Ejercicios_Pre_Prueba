using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {

        #region Atributos
        private string apellido;

        private string nombre;

        #endregion

        #region Constructor

        public Comerciante(string nombre, string apellido)
        {
            this.apellido = apellido;
            this.nombre = nombre;
        }

        #endregion

        #region Atributos

        public static implicit operator string(Comerciante a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{a.nombre} - {a.apellido}");
            return sb.ToString();
        }

        public static bool operator ==(Comerciante a, Comerciante b)
        {
            bool retorno = false;
            if (!Object.Equals(a, null) && !Object.Equals(b, null))
            {
                if(a.apellido == b.apellido && a.nombre == b.nombre)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Comerciante a, Comerciante b)
        {
            return !(a == b);
        }

        #endregion

    }
}
