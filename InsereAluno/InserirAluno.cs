using matricula.domain.Services;
using matricula.infra.Entities;
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
    public interface IInserirAluno : IHostedService
    {
        void SetaTimer(int milisegundos);
        bool IsRunning();
    }

    public  class InserirAluno : IInserirAluno
    {
        private static InserirAluno _instance;
        public static InserirAluno Instance => _instance;
        private bool isRunning { get; set; }
        private System.Timers.Timer _timer;
       
        IAlunoService _service;
       
        public InserirAluno()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            _service = new AlunoService();
          _timer = new System.Timers.Timer(60000);

        }

        public void SetaTimer(int milisegundos) 
        {
            _timer = new System.Timers.Timer(milisegundos);
        }

        public bool IsRunning()
        {
           return isRunning;
        }
        
        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
           // _timer = new System.Timers.Timer(_timeInMiliseconds);
            _timer.Elapsed += async (sender, arq) => await ExecuteAsync(cancellationToken);
            _timer.Start();
            await Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            isRunning = false;
            _timer = new System.Timers.Timer(0);
            await Task.CompletedTask;
        }


        public virtual void Dispose()
        {           
            try
            {
                isRunning = true;
              
            }
            catch (Exception ex)
            {
                isRunning = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occured when disposed a object see details:{ex.Message}");
                Console.ResetColor();
                throw ex;
            }
        }
        protected async Task ExecuteAsync(CancellationToken cancellationToken)
        {
           
            var requisicaoWeb = WebRequest.CreateHttp("https://gerador-nomes.herokuapp.com/nomes/5");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                string[] dadosDoCadastro = objResponse.ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
                streamDados.Close();
                resposta.Close();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                var time = DateTime.Now;
                Console.WriteLine($"{time} - {dadosDoCadastro[0]}  e {dadosDoCadastro[1]} e {dadosDoCadastro[2]} e {dadosDoCadastro[3]} e {dadosDoCadastro[4]}");
                Console.ResetColor();

                List<Aluno> alunos = new List<Aluno>();
                foreach (var item in dadosDoCadastro)
                {
                    Aluno aluno = new Aluno();
                    aluno.Nome = item;
                    aluno.DataCadastro = DateTime.Now;
                    aluno.DataAlteracao = DateTime.Now;
                    aluno.Ativo = true;
                    alunos.Add(aluno);

                }
                _service.AddRange(alunos);


            }
            await Task.CompletedTask;
        }    

    }
}
