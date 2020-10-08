using System.Threading.Tasks;
using bookstore.domain.models;
using bookstore.dto;
using bookstore.interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.controller
{
    [Route("/rest/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service)
        {
            _service = service;
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Inserir([FromBody]LivroDto livroDto)
        {
            if (livroDto == null)
                return NotFound();

            await _service.Inserir(livroDto);
            return StatusCode(201);
        }

        [HttpPatch("atualizar/{codigo}")]
        public async Task<IActionResult> Atualizar([FromBody]JsonPatchDocument<LivroDto> livroPatch, int codigo)
        {
            if (livroPatch == null)
                return NotFound();

            var livro = _service.BuscarPeloCodigo(codigo);

            await _service.Atualizar(livroPatch, codigo);
            return StatusCode(201);
        }

        [HttpDelete("apagar/{codigo}")]
        public async Task Apagar(int codigo) =>
            await _service.Apagar(codigo);

        [HttpGet("buscarpelocodigo/{codigo}")]
        public Livro[] BuscarPeloCodigo(int codigo) =>
            _service.BuscarPeloCodigo(codigo);

        [HttpGet("buscartodos")]
        public Livro[] BuscarTodos() =>
            _service.BuscarTodos();

        [HttpGet("buscarpelotitulo/{titulo}")]
        public Livro[] BuscarTodos(string titulo) =>
            _service.BuscarPeloTitulo(titulo);
        
        [HttpGet("buscarpeloisbn/{isbn}")]
        public Livro[] BuscarPeloIsbn(string isbn) =>
            _service.BuscarPeloIsbn(isbn);

        [HttpGet("buscarpeloautor")]
        public Livro[] BuscarPeloAutor([FromBody]LivroDto livroDto) =>
            _service.BuscarPeloAutor(livroDto);
    }
}