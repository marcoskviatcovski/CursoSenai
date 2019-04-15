using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [MetadataType(typeof(Medicos))]
    
    public class Medicos
    {
        public int id_medico { get; set; }
        public Nullable<int> id_especialidade { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar crm")]
        public string crm { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar bairro")]
        public string bairro { get; set; }

        public Nullable<int> id_cidade { get; set; }



        public Nullable<bool> atende_por_convenio { get; set; }
        public Nullable<bool> tem_clinica { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar website")]
        public string web_site_blog { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual Especialidade Especialidade { get; set; }
    }
}