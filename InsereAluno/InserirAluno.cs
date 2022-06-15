using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InsereAluno
{
    
    public abstract class InserirAluno : IHostedService, IDisposable
    {

        private System.Timers.Timer _timer;
        private readonly double _timeInMiliseconds;
        protected abstract Task ExecuteAsync(CancellationToken cancellationToken);
        protected InserirAluno(double timeInMiliseconds)=> _timeInMiliseconds = timeInMiliseconds;


       

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new System.Timers.Timer(_timeInMiliseconds);
            _timer.Elapsed += async (sender, arq) => await ExecuteAsync(cancellationToken);
            _timer.Start();
            await Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            await Task.CompletedTask;
        }


        public virtual void Dispose()
        {
            try
            {
                _timer?.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occured when disposed a object see details:{ex.Message}");
                Console.ResetColor();
            }
        }

    }
}
