using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using bookstore.domain.models;
using bookstore.domain.objectvalue;
using bookstore.dto;
using Microsoft.AspNetCore.JsonPatch;

namespace bookstore.interfaces
{

    public interface ILivroService
    {
        Task Inserir(LivroDto livroDto);
        Task Atualizar(JsonPatchDocument<LivroDto> livroPatch, int codigo);
        Task Apagar(int codigo);
        Livro[] BuscarPeloIsbn(string campo);
        Livro[] BuscarPeloAutor(LivroDto livroDto);
        Livro [] BuscarPeloCodigo(int codigo);
        Livro[] BuscarPeloTitulo(string titulo);
        Livro[] BuscarTodos();
    }

}