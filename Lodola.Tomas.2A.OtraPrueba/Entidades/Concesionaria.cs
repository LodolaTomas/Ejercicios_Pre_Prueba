using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concesionaria
    {
		private int capacidad;
		private List<Vehiculo> vehiculos;

		public double PrecioDeAutos
		{
			get { return this.ObtenerPrecio(EVehiculo.PrecioDeAutos); }
		}

		public double PrecioDeMotos
		{
			get { return this.ObtenerPrecio(EVehiculo.PrecioDeMotos); }
		}

		public double PrecioTotal
		{
			get { return this.ObtenerPrecio(EVehiculo.PrecioTotal); }
		}


		private Concesionaria()
		{
			this.vehiculos = new List<Vehiculo>();
		}
		private Concesionaria(int capacidad):this()
		{
			this.capacidad = capacidad;
		}

		public static implicit operator Concesionaria(int capacidad)
		{
			return new Concesionaria(capacidad);
		}

		public static string Mostrar(Concesionaria c)
		{
			StringBuilder Cadena = new StringBuilder();

			Cadena.AppendLine($"Capacidad : {c.capacidad}\n");
			Cadena.AppendLine($"Total por Autos: ${c.PrecioDeAutos}\n");
			Cadena.AppendLine($"Total por Motos: ${c.PrecioDeMotos}\n" );
			Cadena.AppendLine($"Total: ${c.PrecioTotal}\n");
			Cadena.AppendLine("*****************************");
			Cadena.Append("Listado de Vehiculos\n");
			Cadena.AppendLine("*****************************");

			foreach (Vehiculo item in c.vehiculos)
			{
				if (item is Auto)
				{
					Cadena.AppendLine(item.ToString());
				}
				else
				{
					Cadena.AppendLine(item.ToString());
				}
				Cadena.AppendLine("  ");
			}

			return Cadena.ToString();
		}

		private double ObtenerPrecio(EVehiculo tipoVehiculo)
		{
			double precioAutos=0;
			double precioMotos=0;
			double precio=0;

			foreach (Vehiculo item in this.vehiculos)
			{

				if(item is Auto)
				{
					precioAutos += (Single)(Auto)item;

				}else if(item is Moto)
				{
					precioMotos += (Single)(Moto)item;
				}

			}

			switch (tipoVehiculo)
			{
				case EVehiculo.PrecioDeAutos:
					precio = precioAutos;
					break;
				case EVehiculo.PrecioDeMotos:
					precio = precioMotos;
					break;
				case EVehiculo.PrecioTotal:
					precio = precioAutos + precioMotos;
					break;
				default:
					break;
			}

			return precio;
		}

		public static Concesionaria operator +(Concesionaria c, Vehiculo v)
		{

			if(!Object.Equals(c, null) && !Object.Equals(v, null))
			{
				if(c!=v && c.vehiculos.Count < c.capacidad)
				{
					c.vehiculos.Add(v);
				}else if(c.vehiculos.Count >= c.capacidad)
				{
					Console.WriteLine("No hay mas lugar en la concesionaria!!!");
				}
				else
				{
					Console.WriteLine("El vehiculo ya esta en la concesionaria!!!");
				}
			}
			return c;
		}

		public static bool operator !=(Concesionaria c, Vehiculo v)
		{
			return !(c == v);
		}
		public static bool operator ==(Concesionaria c, Vehiculo v)
		{
			bool retorno = false;

			if (!Object.Equals(c, null) && !Object.Equals(v, null))
			{
				foreach (Vehiculo item in c.vehiculos)
				{
					if(item is Auto && v is Auto)
					{
						if (((Auto)item) == ((Auto)v))
						{
							retorno = true;
							break;
						}
					}
					else if(item is Moto && v is Moto)
					{
						if (((Moto)item) == ((Moto)v))
						{
							retorno = true;
							break;
						}
					}
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


	}
}
