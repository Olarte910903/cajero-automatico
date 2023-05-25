/*
 Nombre: Luis Miguel Olarte Bello
 Código: 1094922554
 Grupo: 213023_30
 */
namespace Ejercicio_Cajero
{
	internal class Cajero
	{
		public List<CuentaBancaria> usuarios = new List<CuentaBancaria>();

		public Cajero()
		{
			CrearUsuario();
		}
		public void CrearUsuario()
		{
			CuentaBancaria usuario1 = new CuentaBancaria("1234", "1234", 5000000);
			CuentaBancaria usuario2 = new CuentaBancaria("5678", "5678", 2000000);
			CuentaBancaria usuario3 = new CuentaBancaria("9123", "9123", 3000000);
			usuarios.Add(usuario1);
			usuarios.Add(usuario2);
			usuarios.Add(usuario3);
		}

		public void PantallaLogin()//Pantalla principal
		{
			Console.Clear();
			string numeroCuenta;
			Console.WriteLine("Bienvenido a su banco\n");
			Console.Write("Ingrese el número de cuenta: ");
			numeroCuenta = Console.ReadLine();

			if (ComprobarCuentaExistente(numeroCuenta))
			{
				string contraseña;
				Console.Write("Ingrese la contraseña: ");
				contraseña = Console.ReadLine();

				if (ValidarContraseña(contraseña, numeroCuenta))
				{
					MenuUsuario(numeroCuenta);
				}
				else
				{
					Console.WriteLine("Contraseña erronea!");
					Console.ReadKey();
					PantallaLogin();
				}

			}
			else
			{
				Console.WriteLine("Usuario Inexistente");
				Console.ReadKey();
				PantallaLogin();
			}

		}

		public void MenuUsuario(string numeroCuenta)
		{
			try
			{
				Console.Clear();
				Console.WriteLine("Bienvenido Usuario\n");
				Console.WriteLine("Seleccione una opción\n");
				Console.WriteLine("1. Consulta Saldo");
				Console.WriteLine("2. Retiros");
				Console.WriteLine("3. Transferencias");
				Console.WriteLine("4. Consulta puntos ViveColombia");
				Console.WriteLine("5. Canjear puntos ViveColombia");
				Console.WriteLine("6. Salir");



				int opcion = Convert.ToInt32(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						ConsultaSaldo(numeroCuenta);
						Console.ReadKey();
						MenuUsuario(numeroCuenta);
						break;

					case 2:
						Retiro(numeroCuenta);
						Console.ReadKey();
						MenuUsuario(numeroCuenta);
						break;

					case 3:
						Transferencia(numeroCuenta);
						Console.ReadKey();
						MenuUsuario(numeroCuenta);
						break;

					case 4:
						ConsultaPuntos(numeroCuenta);
						Console.ReadKey();
						MenuUsuario(numeroCuenta);
						break;

					case 5:
						CanjearPuntosColombia(numeroCuenta);
						Console.ReadKey();
						MenuUsuario(numeroCuenta);
						break;

					case 6:
						PantallaLogin();
						break;
					default:
						Console.WriteLine("INGRESE ÚNICAMENTE NÚMEROS DEL 1 AL 6!");
						Console.ReadKey();
						MenuUsuario(numeroCuenta);
						break;
				}
			}
			catch (Exception)
			{
				Console.WriteLine("INGRESE ÚNICAMENTE VALORES NUMÉRICOS!");
				Console.ReadKey();
				MenuUsuario(numeroCuenta);
			}
			
		}

		public bool ComprobarCuentaExistente(string numeroCuenta) //Método para comprobar que un usuario existe
		{
			var cuentaExistente = true;

			for (int i = 0; i < usuarios.Count; i++)
			{
				if (numeroCuenta == usuarios[i].NumeroCuenta)
				{
					cuentaExistente = true;
					break;
				}
				else
				{
					cuentaExistente = false;
				}
			}
			return cuentaExistente;
		}

		public int RetornarPosicionCuenta(string numeroCuenta)//método para  obtener la posicion en la lista
		{
			var cuentaExistente = 0;

			for (int i = 0; i < usuarios.Count; i++)
			{
				if (numeroCuenta == usuarios[i].NumeroCuenta)
				{
					cuentaExistente = i;
					break;
				}
				else
				{
					cuentaExistente = 0;
				}
			}
			return cuentaExistente;
		}

		public bool ValidarContraseña(string password, string numeroCuenta)
		{
			if (usuarios[RetornarPosicionCuenta(numeroCuenta)].Contraseña == password)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void ConsultaSaldo(string numeroCuenta)
		{
			Console.Clear();
			Console.WriteLine("CONSULTA DE SALDO\n");
			Console.Write($"Su saldo actual es de: ${usuarios[RetornarPosicionCuenta(numeroCuenta)].Saldo}");
			Console.WriteLine("\n\nPresione una tecla para continuar...");
		}

		public void ConsultaPuntos(string numeroCuenta)
		{
			Console.Clear();
			Console.WriteLine("Consulta de puntos Vive Colombia\n");
			Console.WriteLine($"Sus puntos acumulados son: {usuarios[RetornarPosicionCuenta(numeroCuenta)].PuntosColombia}");
		}

		public bool ValidarMontoDiario(string numeroCuenta, int valorRetiro)
		{
			if (usuarios[RetornarPosicionCuenta(numeroCuenta)].MontoMaximoRetiros >= valorRetiro)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCantidadRetiro(string numeroCuenta, int valorRetiro)//validar que el monto sea menor al saldo
		{
			if (valorRetiro < usuarios[RetornarPosicionCuenta(numeroCuenta)].Saldo)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Retiro(string numeroCuenta)
		{
			try
			{

			int valorRetiro;
			Console.Clear();
			Console.WriteLine("RETIROS\n");
			Console.Write("Ingrese el monto que desea retirar: ");

			valorRetiro = Convert.ToInt32(Console.ReadLine());

			if (ValidarCantidadRetiro(numeroCuenta, valorRetiro) && ValidarMontoDiario(numeroCuenta, valorRetiro))
			{
				usuarios[RetornarPosicionCuenta(numeroCuenta)].Saldo -= valorRetiro;
				usuarios[RetornarPosicionCuenta(numeroCuenta)].MontoMaximoRetiros -= valorRetiro;
				Console.WriteLine("\nRetiro Exitoso!");
				Console.ReadKey();
				ConsultaSaldo(numeroCuenta);
			}
			else
			{
				Console.WriteLine("No es posible hacer el retiro!");
			}
			}
			catch (Exception)
			{
				Console.WriteLine("\nINGRESE ÚNICAMENTE VALORES NUMÉRICOS");
				Console.ReadKey();
				Retiro(numeroCuenta);
			}
		}

		public void Transferencia(string numeroCuenta)
		{
			Console.Clear();
			Console.WriteLine("Transferencias bancarias\n");

			Console.Write("Ingrese el número de la cuenta destino: ");
			string cuentaDestino = Console.ReadLine();

			if (ComprobarCuentaExistente(cuentaDestino))
			{
				Console.Write("\nIngrese el monto a enviar: ");
				int monto = Convert.ToInt32(Console.ReadLine());

				if (ValidarCantidadRetiro(numeroCuenta, monto))
				{
					usuarios[RetornarPosicionCuenta(numeroCuenta)].Saldo -= monto;
					usuarios[RetornarPosicionCuenta(cuentaDestino)].Saldo += monto;

					usuarios[RetornarPosicionCuenta(cuentaDestino)].PuntosColombia += PuntosColombia(monto);

					Console.WriteLine("\nTransferencia Exitosa!");
					Console.WriteLine("\nPresione una tecla para continuar...");
					Console.ReadKey();
					ConsultaSaldo(numeroCuenta);
				}
				else
				{
					Console.WriteLine("Saldo insuficiente para realizar la transferencia!");
					
				}

			}
			else
			{
				Console.WriteLine("Cuenta destino Inexistente!");
				
			}
		}

		public int PuntosColombia(int monto)
		{
			return monto / 5000 * 5;
		}

		public bool ValidarExistenciaPuntos(string cuentaUsuario)
		{
			if (usuarios[RetornarPosicionCuenta(cuentaUsuario)].PuntosColombia > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void CanjearPuntosColombia(string cuentaUsuario)
		{
			int saldoEnPuntos;
			Console.Clear();
			if (ValidarExistenciaPuntos(cuentaUsuario))
			{
				saldoEnPuntos = usuarios[RetornarPosicionCuenta(cuentaUsuario)].PuntosColombia / 5;
				usuarios[RetornarPosicionCuenta(cuentaUsuario)].Saldo += saldoEnPuntos;
				Console.WriteLine($"Has canjeado tus: {usuarios[RetornarPosicionCuenta(cuentaUsuario)].PuntosColombia} puntos por: ${saldoEnPuntos} pesos con éxito!");
				usuarios[RetornarPosicionCuenta(cuentaUsuario)].PuntosColombia = 0;
			}
			else
			{
				Console.WriteLine("Saldo de puntos insuficiente!");
			}
		}




 






	}
}

