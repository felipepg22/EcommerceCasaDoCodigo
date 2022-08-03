﻿using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
    }
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }

        public Pedido GetPedido()
        {
            var pedidoId = this.getPedidoId();

            var pedido = dbSet.Where(p => p.Id == pedidoId).SingleOrDefault();

            if(pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                contexto.SaveChanges();
            }

            return pedido;
        }

        private int? getPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void setPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

    }
}
