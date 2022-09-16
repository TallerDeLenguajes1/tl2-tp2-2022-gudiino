using System;
namespace Cursos
{
    public class Alumno
    {
        private int ID {get; set;}
        private string? Nombre {get; set;}
        private string? Apellido {get; set;}
        private int DNI {get; set;}
        public enum CursosInst{Atletismo, Voley, Futbol}
        public int Curso {get; set;}
        public Alumno(int id, string? nom, string? ape, int dni, int curs){
            ID=id;
            Nombre=nom;
            Apellido=ape;
            DNI=dni;
            Curso=curs;
        }
        public string[] getDatos(){
            string[] linea = {ID.ToString(),Apellido!,Nombre!,DNI.ToString()};
            return linea;
        }
        public void mostrar_info(){
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Apellido: {Apellido}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"DNI: {DNI}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine();
        }
        
    }
}