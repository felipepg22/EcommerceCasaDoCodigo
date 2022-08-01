using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
