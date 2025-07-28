using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EjerciciosScriptingTaller1
{
    public class Ejemplos
    {
        // 1. Pública, sin parámetros ni retorno
        public void Saludar() { }

        // 2. Privada, con retorno entero
        private int ObtenerNumero() { return 42; }

        // 3. Protegida, con parámetro string
        protected void MostrarNombre(string nombre) { Console.WriteLine(nombre); }

        // 4. Interna, retorna booleano
        internal bool EstaActivo() { return true; }

        // 5. Pública estática, con parámetros int
        public static int Sumar(int a, int b) { return a + b; }

        // 6. Parámetro por defecto
        public void MostrarMensaje(string mensaje = "Mondongo") { Console.WriteLine(mensaje); }

        // 7. Parámetro por referencia
        public void Duplicar(ref int numero) { numero *= 2; }

        // 8. Parámetro out
        public void Dividir(int a, int b, out int resultado) { resultado = a / b; }

        // 9. Recibe arreglo
        public void ProcesarArreglo(int[] numeros) { Console.WriteLine(string.Join(", ", numeros)); }

        // 10. Retorna arreglo
        public string[] ObtenerColores() { return new string[] { "Amarillo", "Marron" }; }

        // 11. Recibe lista
        public void ProcesarLista(List<string> lista) { lista.ForEach(Console.WriteLine); }

        // 12. Retorna lista
        public List<int> GenerarLista() { return new List<int> { 67, 2, 53 }; }

        // 13. Recibe clase Persona
        public void ProcesarPersona(Persona persona) { Console.WriteLine($"{persona.Nombre}, {persona.Edad}"); }

        // 14. Retorna clase Persona
        public Persona CrearPersona(string nombre, int edad) { return new Persona { Nombre = nombre, Edad = edad }; }

        // 15. Función genérica
        public T ObtenerPrimero<T>(T[] arreglo) { return arreglo[0]; }

        // 16. Parámetros variables (params)
        public void SumarVarios(params int[] numeros) { Console.WriteLine($"Suma: {numeros.Length} elementos"); }

        // 17. Función con tupla como retorno
        public (int suma, int resta) Operaciones(int a, int b) { return (a + b, a - b); }

        // 18. Función asíncrona
        public async Task EsperarAsync() { await Task.Delay(100); Console.WriteLine("Esperado"); }

        // 19. Función privada estática
        private static void RegistrarLog(string mensaje) { Console.WriteLine($"Log: {mensaje}"); }

        // 20. Función protegida interna con retorno complejo
        protected internal Dictionary<string, List<int>> GenerarDiccionario()
        {
            return new Dictionary<string, List<int>> { { "clave", new List<int> { 1, 2, 3 } } };
        }

        // Método para invocar privados/protegidos desde esta clase
        public void InvocarPrivadosYProtegidos()
        {
            Console.WriteLine($"ObtenerNumero(): {ObtenerNumero()}"); // privada
            MostrarNombre("Juanes (protected)"); // protegida
            RegistrarLog("Probando log privado estático");
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Ejemplos ej = new Ejemplos();

            // 1
            ej.Saludar();

            // 2, 3 y 19 (privadas/protegidas)
            ej.InvocarPrivadosYProtegidos();

            // 4
            Console.WriteLine($"EstaActivo: {ej.EstaActivo()}");

            // 5 (estática)
            Console.WriteLine($"Suma: {Ejemplos.Sumar(3, 4)}");

            // 6
            ej.MostrarMensaje();
            ej.MostrarMensaje("Mensaje custom");

            // 7
            int numero = 5;
            ej.Duplicar(ref numero);
            Console.WriteLine($"Duplicado: {numero}");

            // 8
            ej.Dividir(10, 2, out int resultado);
            Console.WriteLine($"División: {resultado}");

            // 9
            ej.ProcesarArreglo(new int[] { 1, 2, 3 });

            // 10
            var colores = ej.ObtenerColores();
            Console.WriteLine($"Colores: {string.Join(", ", colores)}");

            // 11
            ej.ProcesarLista(new List<string> { "A", "B", "C" });

            // 12
            var lista = ej.GenerarLista();
            Console.WriteLine($"Lista: {string.Join(", ", lista)}");

            // 13
            ej.ProcesarPersona(new Persona { Nombre = "Ana", Edad = 22 });

            // 14
            var persona = ej.CrearPersona("Pedro", 30);
            Console.WriteLine($"{persona.Nombre}, {persona.Edad}");

            // 15
            Console.WriteLine($"Primero: {ej.ObtenerPrimero(new string[] { "X", "Y" })}");

            // 16
            ej.SumarVarios(1, 2, 3, 4, 5);

            // 17
            var (suma, resta) = ej.Operaciones(10, 5);
            Console.WriteLine($"Suma: {suma}, Resta: {resta}");

            // 18
            await ej.EsperarAsync();

            // 20
            var dicc = ej.GenerarDiccionario();
            foreach (var kv in dicc)
                Console.WriteLine($"{kv.Key}: {string.Join(", ", kv.Value)}");
        }
    }
}
