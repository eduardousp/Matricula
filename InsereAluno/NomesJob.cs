using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using matricula.domain.Services;
using matricula.infra.Entities;
namespace InsereAluno
{
    public class NomesJob : InserirAluno
    {
        IAlunoService _service;
        public NomesJob(double timeInMiliseconds) : base(timeInMiliseconds)
        {
            
        }


        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _service = new AlunoService();
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
             
               await Task.CompletedTask;
            }
        }
    }
}
