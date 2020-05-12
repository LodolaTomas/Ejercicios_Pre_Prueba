using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Atributo
        ECilindrada cilindrada;
        #endregion
        
        #region Metodos

        #region Constuctor
        public Moto(string marca, EPais pais, string modelo,float precio, ECilindrada cilindrada) : base(marca,pais,modelo,precio)
        {
            this.cilindrada = cilindrada;
        }
        #endregion
        #region Operadores
        public static explicit operator Single(Moto m)
        {
            return m.precio;
        }
        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }
        public static bool operator ==(Moto a, Moto b)
        {
            bool retorno = false;
            if (!Object.Equals(a, null) && !Object.Equals(b, null))
            {
                if (a.cilindrada == b.cilindrada && (Vehiculo)a == (Vehiculo)b)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj is Moto)
            {
                return this ==(Moto)obj;
            }
            return false;
        }

        public override string ToString()
        {
            return (string)this + "Cilindrada: " + this.cilindrada;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
