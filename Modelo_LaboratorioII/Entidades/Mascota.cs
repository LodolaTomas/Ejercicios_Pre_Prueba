using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Mascota
    {
        #region Atributos

        private string nombre;
        private string raza;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Raza
        {
            get { return this.raza; }
        }

        #endregion

        #region Metodos

        protected virtual string DatosCompletos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.nombre} - {this.raza}");

            return sb.ToString();
        }

        protected abstract string Ficha();

        public Mascota(string nombre,string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }

        public static bool operator !=(Mascota m1,Mascota m2)
        {
            return !(m1 == m2);
        }

        public static bool operator ==(Mascota m1,Mascota m2)
        {
            bool retorno = false;
            if(!Object.Equals(m1,null) && !Object.Equals(m2,null))
            {
                if(m1.nombre == m2.nombre && m1.raza == m2.raza)
                {
                    retorno = true;
                }

            }
            return retorno;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
