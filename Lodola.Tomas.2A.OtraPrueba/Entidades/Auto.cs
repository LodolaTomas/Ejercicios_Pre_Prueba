using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        
        #region Atributos
        public ETipo tipo;
        #endregion

        #region Metodos

        #region Constuctor
        public Auto(string modelo, float precio, Fabricante fabri,ETipo tipo):base(precio,modelo,fabri)
        {
            this.tipo = tipo;
        }
        #endregion
        #region Operadores
        public static explicit operator Single(Auto a)
        {
            return a.precio;
        }
        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }
        public static bool operator ==(Auto a, Auto b)
        {
            bool retorno = false;
            if(!Object.Equals(a,null) && !Object.Equals(b,null))
            {
                if(a.tipo==b.tipo && (Vehiculo)a == (Vehiculo)b)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(this==(Auto)obj)
            {
                retorno = true;
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return (string)this + "Tipo: " + this.tipo;
        }

        #endregion
    }
}
