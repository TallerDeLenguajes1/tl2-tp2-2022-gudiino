using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
namespace Cursos
{
    class Program
    {
        static void Main(string[] args)
        {//Alumno(int id, string nom, string ape, int dni, int curs)
            Alumno alumno0= new Alumno(10001,"Jorge","Gudiño",12345678,0);
            Alumno alumno1= new Alumno(10002,"Jose","Alvarez",12345678,1);
            Alumno alumno2= new Alumno(10002,"Jose","Alvarez",12345678,2);
            Alumno alumno3=cargar_datos();
            Console.WriteLine();
            alumno0.mostrar_info();
            alumno3.mostrar_info();
            //Console.WriteLine($"{Enum.GetName(typeof(Alumno.CursosInst), alumno1.Curso)}.csv");
            GuardarAlumno(alumno0);
            GuardarAlumno(alumno1);
            GuardarAlumno(alumno2);
            GuardarAlumno(alumno3);
            Console.WriteLine("\nFIN PROGRAMA.");
        }
        private static Alumno cargar_datos(){
            Console.WriteLine("Ingrese los datos del alumno");
            Console.Write("ID: ");
            string? dato_id=Console.ReadLine();
            int id=Convert.ToInt32(dato_id);
            Console.Write("Apellido: ");
            String? ape=Console.ReadLine();
            Console.Write("Nombre: ");
            String? nom=Console.ReadLine();
            Console.Write("DNI: ");
            string? dato_dni=Console.ReadLine();
            int dni=Convert.ToInt32(dato_dni);
            Console.Write("Curso: ");
            string? dato_curso=Console.ReadLine();
            int curso=Convert.ToInt32(dato_curso);
            Alumno alumno0= new Alumno(id,nom,ape,dni,curso);
            return alumno0;
        }
        private static void GuardarAlumno(Alumno nuevo)
        {//******************* guardar dato en csv
            string archivo = $"{Enum.GetName(typeof(Alumno.CursosInst), nuevo.Curso)}.csv";
            List<string[]> lista_alumno=HelperCSV.LeerCsv(archivo,',');
            string[] linea = nuevo.getDatos();
            lista_alumno.Add(linea);
            HelperCSV.GuardarCSV(archivo,lista_alumno);
        }
    }
}
    