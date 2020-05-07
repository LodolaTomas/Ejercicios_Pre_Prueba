using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo
    {
        #region Atributo
        private List<Mascota> manada;
        private string nombre;
        private static EtipoManada tipo;
        #endregion

        #region Propiedades

        public EtipoManada Tipo
        {
            set { tipo = value; }
        }

        #endregion

        #region Metodos
        
        static Grupo()
        {
            tipo = EtipoManada.Unica;
        }
        private Grupo()
        {
            this.manada = new List<Mascota>();
        }
        public Grupo(string nombre):this()
        {
            this.nombre = nombre;
        }
        public Grupo(string nombre,EtipoManada tipo):this(nombre)
        {
            this.Tipo = tipo;
        }

        public static implicit operator string(Grupo g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Grupo: {g.nombre} - tipo: {tipo}");
            sb.AppendLine($"Integrantes({g.manada.Count})");
            //for(int i=0;i>g.manada.Count;i++)
            //{
            //    sb.AppendLine(g.manada[i].ToString());
            //}
            foreach (Mascota item in g.manada)
            {
                sb.AppendLine(item.ToString());
            }


            return sb.ToString();
        }

        public static bool operator !=(Grupo g, Mascota m)
        {
            return !(g == m);
        }
        public static bool operator ==(Grupo g, Mascota m)
        {
            bool retorno = false;
            if (g.manada.Count > 0)
            {
                foreach (Mascota item in g.manada)
                {
                    if (item.Equals(m))
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public static Grupo operator +(Grupo g,Mascota m)
        {
            if (g != m)
            {
                g.manada.Add(m);
            }
            return g;
        }

        public static Grupo operator -(Grupo g,Mascota m)
        {
            if (g == m)
            {
                g.manada.Remove(m);
            }
            return g;
        }

        #endregion

    }
}
