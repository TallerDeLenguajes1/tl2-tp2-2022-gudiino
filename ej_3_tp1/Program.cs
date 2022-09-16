using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NLog;

namespace Ejercicio3
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            //empleado(string nom, string ape, DateTime fec, int civ, char gne, DateTime fecing, double salario, int carg, int hij){
            Empleado empleado1 = new Empleado("Jorge","Gudiño",new DateTime(1987,05,13),0,'M',new DateTime(2012,1,16),45000,0,0);
            TituloUniversitario titulo= new TituloUniversitario();
            titulo.NomTitulo="ingeniero";
            titulo.NomUniversidad="UNT";
            empleado1.titulo=titulo;
            empleado1.MostrarDatos();
            empleado1.Titulo_Universitario();
            CargarEmpleados();
        }
        static void CargarEmpleados()
        {
            Console.WriteLine("Indique la cantidad de empleados a cargar");
            List<Empleado> lista_empleado=new List<Empleado>();
            int num_empleados;
            string? value = Console.ReadLine();
            //num_empleados = Int32.Parse(Console.ReadLine());
            try
            {
                num_empleados = Convert.ToInt32(value);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Valor invalido '{0}'.", value);
                Console.WriteLine("Intentelo de nuevo");
                Logger.Info(ex,"formato ingresado invalido, no es numero");
                return;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("'{0}' es un numero que esta fuera del rango.", value);
                Console.WriteLine("Intentelo de nuevo");
                Logger.Debug(ex, "valor ingresado esta fuera de rango");
                return;
            }
            for (int i = 0; i < num_empleados; i++)
            {
                Console.WriteLine("Ingrese todos los datos solicitado del empleado {0}",i+1);
                CargarDatos(lista_empleado);
            }
        }
        static void CargarDatos(List<Empleado> lista)
        {
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string? apellido = Console.ReadLine();
            Console.Write("Fecha de nacimiento (ejemplo 01/01/1987): ");
            string? fecha_nac = Console.ReadLine();
            string[] Fila = fecha_nac!.Split('/');
            int fecha_nac_dia = Convert.ToInt32(Fila[0]);
            int fecha_nac_mes = Convert.ToInt32(Fila[1]);
            int fecha_nac_anio = Convert.ToInt32(Fila[2]);
            Console.WriteLine("Estado civil (0=Soltero, 1=Casado, 2=Divorciado, 3=Viudo)");
            Console.Write("Seleccione el número correspondiente: ");
            int E_civil = Convert.ToInt32(Console.ReadLine());
            string? fecha_divorcio;
            DateTime fecha_div;
            if (E_civil==2)
            {
                Console.Write("Fecha de divorcio (ejemplo 01/01/1987): ");
                fecha_divorcio = Console.ReadLine();
                fecha_div=DateTime.Parse(fecha_divorcio!);
                // string[] Fila1 = fecha_divorcio!.Split('/');
                // int fecha_divorcio_dia = Convert.ToInt32(Fila1[0]);
                // int fecha_divorcio_mes = Convert.ToInt32(Fila1[1]);
                // int fecha_divorcio_anio = Convert.ToInt32(Fila1[2]);
            }
            Console.Write("Genero (M=Masculino, F=Femenino): ");
            string? genero = Console.ReadLine();
            Console.Write("Fecha de ingreso (ejemplo 01/01/1987): ");
            string? fecha_ingreso = Console.ReadLine();
            var fecha_in=DateTime.Parse(fecha_ingreso!);
            Console.Write("Sueldo basico: ");
            double sueldoB = Double.Parse(Console.ReadLine()!);
            Console.Write("Cantidad de hijos: ");
            int hijos = Int32.Parse(Console.ReadLine()!);
            Console.WriteLine("Tiene titulo universitario: ");
            Console.WriteLine("Y --> SI ");
            Console.WriteLine("N --> NO");
            Console.Write("Seleccion: ");
            string? var1 = Console.ReadLine();
            TituloUniversitario nuevo=new TituloUniversitario();
            if(var1!.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Nombre del Título: ");
                nuevo.NomTitulo=Console.ReadLine();
                Console.Write("Nombre de la Universidad: ");
                nuevo.NomUniversidad=Console.ReadLine();
            }
            //Cargos{Auxiliar,Administrativo,Ingeniero,Especialista,Investigador};
            Console.Write("Cargo (0=Auxiliar,1=Administrativo,2=Ingeniero,3=Especialista,4=Investigador: ");
            int cargo = Int32.Parse(Console.ReadLine()!);
        }
    }
}