using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthApi.ViewModel
{
    public class Pessoa
    {
        public int PessoaId { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string Telefone { get; set; }

        public short Peso { get; set; }

        public short Autura { get; set; }

        public bool Sexo { get; set; }
    }
}