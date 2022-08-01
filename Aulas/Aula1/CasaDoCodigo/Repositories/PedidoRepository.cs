using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
