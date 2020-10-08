using System;
using System.Runtime.Serialization;

namespace bookstore.dto
{
    
    public class LivroDto
    {
        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string PrimeiroNome { get; set; }

        public string Sobrenome { get; set; }

        public string Isbn { get; set; }

        public string AnoDeLancamento { get; set; }
    }
}