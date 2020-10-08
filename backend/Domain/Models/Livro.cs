using System;
using System.Runtime.Serialization;
using bookstore.domain.objectvalue;

namespace bookstore.domain.models
{
        public class Livro
    {
        public Livro() {}

        public Livro
        (
            string titulo,
            string subTitulo,
            Autor autor,
            string isbn,
            string anoDeLancamento
            )
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoDeLancamento = anoDeLancamento;
            SubTitulo = subTitulo;
        }

        public int Codigo { get; private set; }
        public String Titulo { get; private set; }
        public string SubTitulo { get; private set; }
        public Autor Autor { get; private set; }
        public string Isbn { get; private set; }
        public string AnoDeLancamento { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Livro livro &&
                Isbn == livro.Isbn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Isbn);
        }
    }
}