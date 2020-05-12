using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        #region Atributos
        protected Fabricante fabricante;
        protected Random generadorDeVelocidad;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;
        #endregion

        #region Propiedades
        
        public int VelocidadMaxima
        {
            get 
            {
                if (this.velocidadMaxima == 0)
                {
                    this.velocidadMaxima = this.generadorDeVelocidad.Next(100, 280);
                }
                return this.velocidadMaxima;
            }
        }

        #endregion
        #region Metodos

        #region Constuctor

        private Vehiculo()
        {
            this.generadorDeVelocidad = new Random();
        }
        public Vehiculo(float precio, string modelo, Fabricante fabri):this()
        {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
        }
        public Vehiculo(string marca,EPais pais, string modelo, float precio):this(precio,modelo,new Fabricante(marca,pais))
        {

        }
        #endregion

        private static string Mostrar(Vehiculo v)
        {
            StringBuilder Cadena = new StringBuilder();

            Cadena.AppendLine("Fabricante: " + v.fabricante);
            Cadena.AppendLine("Modelo : " + v.modelo);
            Cadena.AppendLine("Velocidad Maxima: " + v.VelocidadMaxima);
            Cadena.AppendLine("Precio : " + v.precio);

            return Cadena.ToString();
        }

        #region Operadores
        public static implicit operator string(Vehiculo v)
        {
            return Mostrar(v);
        }
        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a==b);
        }
        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool retorno = false;

            if(!Object.Equals(a,null) && !Object.Equals(b,null))
            {
                if(a.modelo == b.modelo && a.fabricante == b.fabricante)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

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
