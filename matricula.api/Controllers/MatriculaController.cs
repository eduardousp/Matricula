using matricula.domain.Services;
using matricula.infra.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace matricula.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        IAlunoService _service;
      
        public MatriculaController() 
        { 
            _service=new AlunoService();
   
        }
        // GET: api/<MatriculaController>
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _service.List();
        }

        // GET api/<MatriculaController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return _service.Find(id);
        }

        // POST api/<MatriculaController>
        [HttpPost]
        public void Post(Aluno aluno)
        {
            _service.Add(aluno);
         
        }

        // PUT api/<MatriculaController>/5
        [HttpPut("{id}")]
        public  void Put(long id, Aluno aluno)
        {
            if (id == aluno.Id)
            {
                _service.Edit(aluno);
            }        
                     
            
        }

        // DELETE api/<MatriculaController>/5
        [HttpDelete("{id}")]
        public void Delete(Aluno aluno)
        {
            _service.Remove(aluno);
        }
        //[HttpDelete("{id}")]
        //public void DeleteAll()
        //{
        //    _service.rem.Remove();
        //}
    }
}
