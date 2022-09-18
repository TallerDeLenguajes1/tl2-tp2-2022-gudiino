using System;
using NLog;
public static class Program
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public static void Main()
    {
        try
        {                                          
            Logger.Info("Hello world");
            System.Console.ReadKey();
            int a=1;
            int b=0;
            int resultado = a/b;
        }
        catch (Exception ex)
        {
                                                 //nivel de registro
            Logger.Trace("Ejemplo de mensaje de trace ");//0
            Logger.Debug("Ejemplo de mensaje debug ");//1
            Logger.Info("Ejemplo de mensaje de información");//2
            Logger.Warn("Ejemplo de mensaje de Warm");//3
            Logger.Error(ex,"Ejemplo de mensaje de error");//4
            Logger.Fatal("Ejemplo de mensaje de error Fatal");//5
        }
    }
} 