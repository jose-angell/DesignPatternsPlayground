using System;
using System.Threading;

namespace DesignPatterns.Creational.Singleton{
//Casso de uso para Singleton
//Tener una única instancia global que se use para escribir mensajes de log (registro) desde cualquier parte de la aplicación.
	public sealed class Logger
	{
		// instancia de la clase que siempre se devuelve
		private static Logger? _instance;

		// Objeto especial de sincronizacion, usado solo como "Candado".
		// Es static porque queremos un unico candado para toda la clase'
		// Es readonly por que nunca cambio despues de ser creado.
		// Usa object porque lock en C# requiere una referencia a cualquier objeto, y no importa su contenido, solo su identidad.
		private static readonly object _lock = new(); 

		private Logger(){}

		public static Logger Instance
		{
			get 
			{
				// El lock(_lock) significa: bloquea este bloque de codigo para que solo un hilo pueda ejecutarlo a la vez, usando 
				// _lock como candado.
				lock(_lock)
				{
					// verifica si _instance ya fue creda, si no la crea, si ya fue creada simplemente la devuelve.
					_instance ??= new Logger();
					return _instance;
				}
			}
		}
		public void Log(string message)
		{
			Console.WriteLine($"[LOG] {message}");
		}
	}
}