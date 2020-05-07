using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro: Mascota
    {
        #region Atributos

        private int edad;
        private bool esAlfa;

        #endregion

        #region Propiedades

        public Perro(string nombre, string raza) : base(nombre, raza)
        {
            this.esAlfa = false;
            this.edad = 0;
        }

        public Perro(string nombre, string raza, int edad, bool esAlfa) : this(nombre, raza)
        {
            this.esAlfa = esAlfa;
            this.edad = edad;
        }

        #endregion

        #region Operadores

        public static explicit operator int(Perro p)
        {
            return p.edad;
        }

        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Perro p1, Perro p2)
        {
            bool retorno = false;
            if (!Object.Equals(p1, null) && !Object.Equals(p2, null))
            {
                if ((int)p1 == (int)p2 && p1 == (Mascota)p2)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        #endregion


        #region Metodos

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(this is Perro && obj is Perro)
            {
                retorno = (this == (Perro)obj);
            }
            return retorno;
        }

        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();
            if (this.esAlfa)
            {
                sb.Append($"perro - {base.Nombre} - {base.Raza}, alfa de la manada, edad {this.edad}");
            }
            else
            {
                sb.Append($"perro - {base.Nombre} - {base.Raza}, edad {this.edad}");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        #endregion
    }
}
