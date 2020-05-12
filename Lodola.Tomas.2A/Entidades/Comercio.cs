using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercio
    {
        #region Atributos
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;
        #endregion

        #region Propiedades
        public int CantidadDeEmpleados 
        {
            get 
            {
                if(this._cantidadDeEmpleados==0)
                {
                    this._cantidadDeEmpleados=_generadorDeEmpleados.Next(1, 100);
                }

                return this._cantidadDeEmpleados;
            }
        }
        #endregion

        #region Constructores
        static Comercio()
        {
            _generadorDeEmpleados = new Random();
        }
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler)
        {
            this._nombre = nombre;
            this._precioAlquiler = precioAlquiler;
            this._comerciante = comerciante;
        }

        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido) : this(nombreComercio, new Comerciante(nombre, apellido), precioAlquiler)
        {

        }

        #endregion

        #region Atributos

        private static string Mostrar(Comercio c)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE: {c._nombre}");
            sb.AppendLine($"CANTIDAD DE EMPLEADOS: {c._cantidadDeEmpleados}");
            sb.AppendLine($"COMERCIANTE: {c._comerciante}");
            sb.AppendLine($"PRECIO ALQUILER: {c._precioAlquiler}");
            return sb.ToString();
        }

        public static explicit operator string(Comercio c)
        {
            return Comercio.Mostrar(c);
        }

        public static bool operator ==(Comercio a, Comercio b)
        {
            bool retorno = false;
            if(!Object.Equals(a,null) && !Object.Equals(b,null))
            {
                if(a._nombre== b._nombre && a._comerciante==b._comerciante)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Comercio a, Comercio b)
        {
            return !(a==b);
        }

        #endregion



    }
}
