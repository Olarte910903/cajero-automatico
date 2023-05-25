/*
 Nombre: Luis Miguel Olarte Bello
 Código: 1094922554
 Grupo: 213023_30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Cajero
{
	internal class CuentaBancaria : Usuario
	{
		private string numeroCuenta;
		private int saldo;
		private int puntosColombia;
        private int montoMaximoRetiros = 2000000;

		public CuentaBancaria (string numeroCuenta, string contraseña, int saldo)
		{
			this.numeroCuenta = numeroCuenta;
			this.Contraseña = contraseña;
			this.Saldo = saldo;

			puntosColombia = saldo / 3000 * 5;
		}

		public string NumeroCuenta
		{
			get { return numeroCuenta; }
			set { numeroCuenta = value; }
		}

		public int Saldo
		{
			get { return saldo; }
			set { saldo = value; }
		}

		public int PuntosColombia
		{
			get { return puntosColombia; }
			set { puntosColombia = value; }
		}

		public int MontoMaximoRetiros
		{
			get { return montoMaximoRetiros; }
			set { montoMaximoRetiros = value;  }
		}
	}
}
