using System;
using System.IO;

public static class GrabarLog
{
    public static void GrabarLogs(string sistema, string titulo, string texto)
    {
        string logFolderPath = RutaCarpeta();
        string logFilePath = RutaArchivo(logFolderPath);

        string logMessage = $"{DateTime.Now} - {sistema} - {titulo}: {texto}";

        try
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(logMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No se pudo escribir el archivo, error: {ex.Message}");
        }
    }

    private static string RutaCarpeta()
    {
        string rutaCarpetaLog = "C:\\Logs";

        return rutaCarpetaLog;
    }

    private static string RutaArchivo(string logFolderPath)
    {
        string logFileName = $"log_{DateTime.Now.ToString("yyyyMMdd")}.txt";
        string logFilePath = Path.Combine(logFolderPath, logFileName);

        if (!Directory.Exists(logFolderPath))
        {
            Directory.CreateDirectory(logFolderPath);
        }

        return logFilePath;
    }
}