using AutoMapper;
using bookstore.domain.models;
using bookstore.domain.objectvalue;
using bookstore.dto;
using bookstore.interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Apagar(int codigo)
        {
            var livro = _repository.BuscarPeloCodigo(codigo).ToArray()[0];
            _repository.Apagar(livro);
            await _repository.Salvar();
        }

        public async Task Atualizar(JsonPatchDocument<LivroDto> livroPatch, int codigo)
        {
            try
            {
                var livro = _repository.BuscarPeloCodigo(codigo).ToArray()[0];
                LivroDto livroDto = _mapper.Map<LivroDto>(livro);

                livroPatch.ApplyTo(livroDto);

                _mapper.Map(livroDto, livro);
                _repository.Atualizar(livro);
                await _repository.Salvar();

            }
            catch (AutoMapperMappingException e)
            {

                throw new Exception("erro: ", e);            
            }
        }

        public Livro[] BuscarPeloAutor(LivroDto livroDto)
        {
            var autor = new Autor(livroDto.PrimeiroNome, livroDto.Sobrenome);
            var x = _repository.BuscarPeloAutor(autor).ToArray();
            return x;
        }

        public Livro[] BuscarTodos() =>
            _repository.BuscarTodos().ToArray();

        public Livro[] BuscarPeloCodigo(int codigo) =>
            _repository.BuscarPeloCodigo(codigo).ToArray();

        public Livro[] BuscarPeloIsbn(string isbn) => 
            _repository.BuscarPeloIsbn(isbn).ToArray();

        public Livro[] BuscarPeloTitulo(string titulo) => 
            _repository.BuscarPeloTitulo(titulo).ToArray();

        public async Task  Inserir(LivroDto livroDto)
        {
            var livro = CriarLivro(livroDto);
            _repository.Inserir(livro);
            await _repository.Salvar();
        }

        private Livro CriarLivro(LivroDto livroDto) 
        {
            var autor = new Autor(livroDto.PrimeiroNome, livroDto.Sobrenome);
            return new Livro(livroDto.Titulo, livroDto.SubTitulo, autor, 
            livroDto.Isbn, livroDto.AnoDeLancamento);
        }
    }
}