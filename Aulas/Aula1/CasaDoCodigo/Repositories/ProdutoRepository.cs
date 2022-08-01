using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext contexto;
        private readonly DbSet<Produto> DbSet;

        public ProdutoRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            DbSet = contexto.Set<Produto>();
        }

        public IList<Produto> GetProdutos()
        {
            return contexto.Set<Produto>().ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                 
                if (!DbSet.Where(p => p.Codigo == livro.Codigo).Any())//Evita cadastros repetidos
                {
                    DbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));

                }
            }

            contexto.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
