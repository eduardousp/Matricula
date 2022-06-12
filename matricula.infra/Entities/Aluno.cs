using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matricula.infra.Entities
{
    public class Aluno:Entity
    {
        [MaxLength(150)]
        [Required]
        [Index(IsUnique = true)]
        public string  Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
       
        [MaxLength(20)]
        public string Identificacao { get; set; }
        
        [MaxLength(15)]
        public string Telefone { get; set; }
    }
}
