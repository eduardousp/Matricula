using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace matricula.infra.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        
        [DefaultValue("true")]
        public bool Ativo { get; set; }
    }
}
