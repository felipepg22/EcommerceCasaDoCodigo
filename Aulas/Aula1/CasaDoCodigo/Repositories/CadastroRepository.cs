using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
