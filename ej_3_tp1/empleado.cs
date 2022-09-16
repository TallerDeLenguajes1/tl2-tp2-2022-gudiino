using System;
namespace Ejercicio3
{
    public class TituloUniversitario
    {
        public string? NomTitulo;
        public string? NomUniversidad;
    }
    public class Empleado
    {
        public string Nombre;
        public string Apellido;
        public DateTime FecNac;
        public enum EstadoCivilItem{Solero,Casado,Divorciado,Viudo};
        public int EstadoCivil;
        public DateTime FechDivorcio;
        public char Genero;
        public DateTime FecIngreso;
        public double SueldoBasico;
        public int hijos;
        public TituloUniversitario? titulo;
        public enum Cargos{Auxiliar,Administrativo,Ingeniero,Especialista,Investigador};
        public int cargo;
        public Empleado(string nom, string ape, DateTime fec, int civ, char gne, DateTime fecing, double salario, int carg, int hij){
            Nombre=nom;
            Apellido=ape;
            FecNac=fec;
            EstadoCivil=civ;
            Genero=gne;
            FecIngreso=fecing;
            SueldoBasico=salario;
            cargo=carg;
            hijos=hij;
        }
        public int Antiguedad()
        {
            DateTime actual = DateTime.Now;
            var antiguedad = actual - FecIngreso;
            int anios = (int)(antiguedad.TotalDays / 365.25);
            //int meses = (int)(((antiguedad.TotalDays / 365.25) - anios) * 12);
            //Console.WriteLine($"Antiguedad: {anios} años {(meses > 0 ? $"y {meses} meses" : "")}");
            return anios;
        }
        public int Edad()
        {
            DateTime actual = DateTime.Now;
            var edad = actual - FecNac;
            int anios = (int)(edad.TotalDays / 365.25);
            //Console.WriteLine($"Edad: {anios} años");
            return anios;
        }
        public double Salario()
        {
            return SueldoBasico+SueldoAdicional()-SueldoDescuento();
        }
        public double SueldoAdicional()
        {
            if(Antiguedad()>20) return 0.25*SueldoBasico;//25% del sueldo basico
            return 0.01*Antiguedad()*SueldoBasico;//1% del sueldo basico
        }
        public double SueldoDescuento()
        {
            return SueldoBasico*0.15;
        }
        public void ConsultaEstadoCivil()
        {
            try
            {
                switch (EstadoCivil)
                {
                    case 0:
                        Console.WriteLine("Soltero/a");
                        break;
                    case 1:
                        Console.WriteLine("Casado/a");
                        Console.WriteLine("Cantidad de hijos {0}", Hijos());
                        break;
                    case 2:
                        Console.WriteLine("Divorciado/a");
                        Console.WriteLine("Fecha de divorcio:.......... {0:d}", FechDivorcio);
                        break;
                    case 3:
                        Console.WriteLine("Viudo/a");
                        break;
                    default:
                        Console.WriteLine("Estado civil no asignado");
                        break;
                }
            }
            catch
            {//este declarado el divorcio pero no tenga la fecha de divorcio
                Console.WriteLine("Faltan datos del empleado o falla del sistema");
            }
        }
        public void Casado()
        {
            if(EstadoCivil==1)
            {
                Console.WriteLine("Cantidad de hijos {0}", Hijos());
                return;
            }
            Console.WriteLine("No es Cadado");
        }
        public int Hijos()
        {
            return hijos;
        }
        public void EstudioUniversitario()
        {
            Console.WriteLine($"Apellido: {Apellido}");
            Console.WriteLine($"Nombre: {Nombre}");
        }
        public void MostrarDatos()
        {
            Console.WriteLine($"Apellido: {Apellido}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad()} años");
            //Console.WriteLine("Fecha de nacimiento: {0:d}", FecNac);
            Console.WriteLine($"Antiguedad: {Antiguedad().ToString()} años");
            Console.WriteLine("Salario : {0} pesos",Salario());
        }
        public void Titulo_Universitario()
        {
            if (titulo==null)
            {
                Console.WriteLine("Sin titulo");
            }else{
                Console.WriteLine("Con titulo");
                Console.WriteLine("Título: {0}",titulo.NomTitulo);
                Console.WriteLine("Universidad: {0}",titulo.NomUniversidad);
            }
        }
    }
}