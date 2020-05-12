using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        

        #region Atributos
        private string marca;
        private EPais pais;
        #endregion

        #region Metodos

        #region Constuctor
        public Fabricante(string marca,EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }
        #endregion
        #region Operadores
        public static implicit operator String(Fabricante f)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{f.marca} - {f.pais}");
            return sb.ToString();
        }
        public static bool operator ==(Fabricante a, Fabricante b)
        {
            bool retorno = false;
            if(!Object.Equals(a,null) && !Object.Equals(b,null))
            {
                if(a.marca==b.marca && b.pais == a.pais)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }
        #endregion
        
        #endregion
    }
}
