using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IncrementService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IncrementService service = new IncrementService();
                ServiceBase.Run(service);

                GrabarLog.GrabarLogs("Log Estado", "Inicio del Servicio", "Servicio Iniciado");
            }
            catch (Exception e)
            {
                GrabarLog.GrabarLogs("Log: ", "No se puedo crear el servicio: ", e.Message);
            }

        }
    }
}

