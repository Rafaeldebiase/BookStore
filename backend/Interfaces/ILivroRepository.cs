using System.Collections.Generic;
using System.Threading.Tasks;
using bookstore.domain.models;
using bookstore.domain.objectvalue;

namespace bookstore.interfaces
{
    public interface ILivroRepository
    {
        void Inserir(Livro livro);
        void Atualizar(Livro livro);
        void Apagar(Livro livro);
        Task Salvar();
        IEnumerable<Livro> BuscarPeloCodigo(int codigo);
        IEnumerable<Livro> BuscarPeloIsbn(string campo);
        IEnumerable<Livro> BuscarTodos();
        IEnumerable<Livro> BuscarPeloTitulo(string titulo);
        IEnumerable<Livro> BuscarPeloAutor(Autor autor);
    }
}