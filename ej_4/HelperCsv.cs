using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cursos
{
    public static class HelperCSV
    {
        public static List<string[]> LeerCsv(string ruta, char caracter)
        {
            // if (!File.Exists(ruta))//validacion de su existencia
            // {
            //     File.Create(ruta);
            // }
            FileStream MiArchivo = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string? Linea = "";
            List<string[]> LecturaDelArchivo = new List<string[]>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(caracter);
                LecturaDelArchivo.Add(Fila);
            }
            MiArchivo.Close();
            return LecturaDelArchivo;
        }
        public static void GuardarCSV(string ruta, List<string[]> lista)
        {
            //**************************
            FileStream Fstream = new FileStream(ruta, FileMode.OpenOrCreate);
            using (StreamWriter StreamW = new StreamWriter(Fstream))
            {
                StreamW.WriteLine("ID,Apellido,Nombre,DNI");
                foreach (string[] linea in lista)
                {
                    StreamW.WriteLine(linea[0]+','+linea[1]+','+linea[2]+','+linea[3]);
                }
            }//using libera los recursos 
            Fstream.Close();
        }
    }
}
