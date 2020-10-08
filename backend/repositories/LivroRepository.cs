using System.Collections.Generic;
using System.Threading.Tasks;
using bookstore.domain.models;
using bookstore.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using bookstore.data;
using System;
using bookstore.domain.objectvalue;

namespace bookstore.repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
        }

        public void Apagar(Livro livro)
        {
            _context.Remove<Livro>(livro);
        }

        public void Atualizar(Livro livro)
        {
            _context.Update<Livro>(livro);
        }


        public IEnumerable<Livro> BuscarPeloTitulo(string titulo) =>
            _context.Livros
                .Where(livro => livro.Titulo.Equals(titulo))
                .OrderBy(campo => campo.Titulo)
                .AsNoTracking()
                .AsEnumerable();

        public IEnumerable<Livro> BuscarPeloIsbn(string isbn) =>
            _context.Livros
                .Where(livro => livro.Isbn.Equals(isbn))
                .OrderBy(campo => campo.Titulo)
                .AsNoTracking()
                .AsEnumerable();

        public IEnumerable<Livro> BuscarPeloAutor(Autor autor) =>
            _context.Livros
                .Where(livro => 
                    livro.Autor.PrimeiroNomeDoAutor
                    .Equals(autor.PrimeiroNomeDoAutor)
                    && livro.Autor.SobreNomeDoAutor
                    .Equals(autor.SobreNomeDoAutor)
                )
                .OrderBy(campo => campo.Titulo)
                .AsNoTracking()
                .AsEnumerable();
        
        public IEnumerable<Livro> BuscarPeloCodigo(int codigo) =>
            _context.Livros
            .Where(livro => livro.Codigo.Equals(codigo))
                .OrderBy(campo => campo.Titulo)
                .AsNoTracking()
                .AsEnumerable();
        
        public  IEnumerable<Livro> BuscarTodos() =>
            _context.Livros
                .OrderBy(campo => campo.Titulo)
                .AsNoTracking()
                .AsEnumerable();

        public void Inserir(Livro livro)
        {
            _context.Add<Livro>(livro);
        }

        public async Task Salvar()
        {
            try{
                await _context.SaveChangesAsync();
            } 
            catch (DbUpdateException e)
            {
                throw new Exception("Erro: ", e);
            }
            catch (ObjectDisposedException err)
            {
                throw new Exception("Erro: ", err);
            }
        }
    }
}