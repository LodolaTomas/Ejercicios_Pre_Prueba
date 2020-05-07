using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gato:Mascota
    {
        #region Metodos

        
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(this is Gato && obj is Gato)
            {
                retorno = (this == (Gato)obj);
            }
            return retorno;
        }


        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"gato - {base.Nombre} - {base.Raza}");

            return sb.ToString();
        }

        public Gato(string nombre,string raza): base(nombre,raza)
        {

        }

        public static bool operator !=(Gato g1,Gato g2)
        {
            return !(g1==g2);
        }
        public static bool operator ==(Gato g1, Gato g2)
        {
            bool retorno = false;
            if (!Object.Equals(g1, null) && !Object.Equals(g2, null))
            {
                if ((Mascota)g1 == g2)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        #endregion




    }
}
