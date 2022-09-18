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
            Random numRan= new Random();
            Alumno alumno0= new Alumno(numRan.Next(1000000),"Jorge","Gudiño",12345678,0);
            Alumno alumno1= new Alumno(numRan.Next(1000000),"Jose","Alvarez",12345678,1);
            Alumno alumno2= new Alumno(numRan.Next(1000000),"Jose","Alvarez",12345678,2);
            Alumno alumno3=cargar_datos();
            Console.WriteLine();
            alumno0.mostrar_info();
            alumno1.mostrar_info();
            alumno2.mostrar_info();
            alumno3.mostrar_info();
            //Console.WriteLine($"{Enum.GetName(typeof(Alumno.CursosInst), alumno1.Curso)}.csv");
            GuardarAlumno(alumno0);
            GuardarAlumno(alumno1);
            GuardarAlumno(alumno2);
            GuardarAlumno(alumno3);
            BorrarAlumnos(1);
            Console.WriteLine("\nFIN PROGRAMA.");
        }
        private static Alumno cargar_datos(){
            Console.WriteLine("Ingrese los datos del alumno");
            Console.WriteLine("............................");
            Random numRan= new Random();
            Console.Write("ID inscripcion: ");
            //string? dato_id=Console.ReadLine();
            //int id=Convert.ToInt32(dato_id);
            int id;
            id=numRan.Next(1000000);
            Console.Write(id);
            Console.WriteLine();
            Console.Write("Apellido: ");
            String? ape=Console.ReadLine();
            Console.Write("Nombre: ");
            String? nom=Console.ReadLine();
            //int cont=0;
            int dni=carga_entero("DNI");
            // while(cont<=2){
            //     try
            //     {
            //         Console.Write("DNI: ");
            //         dni=conversion_a_entero();
            //         cont=3;
            //     }
            //     catch(Exception)
            //     {
            //         cont++;
            //         if (cont==3)
            //         {
            //             Console.WriteLine("\n-------------ALERTA-----------------");
            //             Console.WriteLine("Fallo en la carga de los datos, reingrese de nuevo");
            //             Console.WriteLine("+++ FALLA: ");
            //             throw;
            //         }
            //         Console.WriteLine("Reintento: {0}/2",cont);
            //     }
            // }
            //Console.Write("DNI: ");
            //string? dato_dni=Console.ReadLine();
            //int dni=Convert.ToInt32(dato_dni);
            //int dni=conversion_a_entero();
            Console.WriteLine("Cursos: ");
            Console.WriteLine("0 -> Atletismo");
            Console.WriteLine("1 -> Voley");
            Console.WriteLine("2 -> Futbol");
            //string? dato_curso=Console.ReadLine();
            //int curso=Convert.ToInt32(dato_curso);
            int curso=carga_entero("Curso: ");
            if(curso<0||curso>2){
                Console.WriteLine("La opcion seleccionada es INVALIDA");
                int cont=0;
                Console.WriteLine("Opciones de cursos VALIDOS: ");
                Console.WriteLine("0 -> Atletismo");
                Console.WriteLine("1 -> Voley");
                Console.WriteLine("2 -> Futbol");
                while(cont<2){
                    Console.WriteLine("Reintento: {0}/2",cont+1);
                    curso=carga_entero("Curso");
                    if(curso<0||curso>2){
                        cont++;
                    }else{
                        cont=3;
                    }
                    if(cont==2){
                        throw new Exception("Los datos ingresados son incorrectos, reingrese de nuevo");
                    }
                }
            }
            Alumno alumno0= new Alumno(id,nom,ape,dni,curso);
            return alumno0;
        }
        private static void GuardarAlumno(Alumno nuevo)
        {//******************* guardar dato en csv
            string archivo = $"{Enum.GetName(typeof(Alumno.CursosInst), nuevo.Curso)}.csv";
            List<string[]> lista_alumno=HelperDeArchivos.LeerCsv(archivo,',');
            string[] linea = nuevo.getDatos();
            lista_alumno.Add(linea);
            HelperDeArchivos.GuardarCSV(archivo,lista_alumno);
        }
        private static void BorrarAlumnos(int curso)
        {//limpiar archivo y dejar solo el encabezado
            string archivo = $"{Enum.GetName(typeof(Alumno.CursosInst), curso)}.csv";
            //File.Delete(archivo);
            //List<string[]> lista_alumno=new List<string[]>();
            //HelperDeArchivos.GuardarCSV(archivo,lista_alumno);
            HelperDeArchivos.LimpiarCSV(archivo);
            Console.WriteLine($"Lista de Alumnos del curso {Enum.GetName(typeof(Alumno.CursosInst), curso)} borrados.");
        }
        private static int carga_entero(string dato){
            int cont=0;
            int dni=0;
            while(cont<=2){
                try
                {
                    Console.Write("{0}: ",dato);
                    dni=conversion_a_entero();
                    cont=3;
                }
                catch(Exception)
                {
                    cont++;
                    if (cont==3)
                    {
                        Console.WriteLine("\n-------------ALERTA-----------------");
                        Console.WriteLine("Fallo en la carga de los datos, reingrese de nuevo");
                        Console.WriteLine("+++ FALLA: ");
                        throw;
                    }
                    Console.WriteLine("Reintento: {0}/2",cont);
                }
            }
            return dni;
        }
        private static int conversion_a_entero(){
            int dato;
            string? dato_dni=Console.ReadLine();
            try
            {
                dato=Convert.ToInt32(dato_dni);
                return dato;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingreso un valor INVALIDO, debe ingresar un numeros ENTERO");
                throw;
            }
            catch(OverflowException)
            {
                Console.WriteLine("Ingreso un valor demasiado GRANDE");
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine("OPERACION no valida");
                Console.WriteLine("+++ MENSAJE EXCEPCION:");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
    