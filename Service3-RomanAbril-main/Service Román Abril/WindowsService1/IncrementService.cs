using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace IncrementService
{
    public class IncrementService : ServiceBase
    {
        private Timer timer;
        private int contador;
        private DateTime FechaHora;
        private TimeSpan interval;

        public IncrementService()
        {
            this.ServiceName = "IncrementService";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            ConfiguracionHoraria();

            contador = 0;
            string path = @"E\increment.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            timer = new Timer();
            timer.Interval = interval.TotalMilliseconds;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void ConfiguracionHoraria()
        {
            FechaHora = new DateTime(2023, 8, 30, 12, 0, 0);
            interval = TimeSpan.FromHours(24);
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now >= FechaHora)
            {
                contador++;
                string path = @"E\Increment.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(contador);
                }

                FechaHora = FechaHora.Add(interval);
            }
        }
    }
}