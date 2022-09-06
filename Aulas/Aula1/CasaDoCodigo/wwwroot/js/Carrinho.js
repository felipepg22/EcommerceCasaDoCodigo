class Carrinho
{
    clickIncremento(btn)
    {
        let data = this.GetData(btn);
        data.Quantidade++;
        this.PostQuantidade(data);
    }

    clickDecremento(btn)
    {
        let data = this.GetData(btn);
        data.Quantidade--;
        this.PostQuantidade(data);
    }

    updateQuantidade(input)
    {
        let data = this.GetData(input);        
        this.PostQuantidade(data);
    }

    PostQuantidade(data) {

        let headers = {};

        headers['RequestVerificationToken'] = $('[name=__RequestVerificationToken]').val();

        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {

            let itemPedido = response.itemPedido;
            let linhaDoItem = $(`[item-id=${itemPedido.id}]`);
            let carrinhoViewModel = response.carrinhoViewModel;            

            linhaDoItem.find('input').val(itemPedido.quantidade);
            linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());

            $('[numero-itens]').html(`Total: ${carrinhoViewModel.itens.length} itens`);
            $('[total]').html((carrinhoViewModel.total).duasCasas());

            if (itemPedido.quantidade == 0) {

                linhaDoItem.remove();
            }

            

            
            
        });

        
    }

    GetData(elemento) {
        let linhaItem = $(elemento).parents('[item-id]');
        let itemId = $(linhaItem).attr('item-id');
        let novaQtde = $(linhaItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {

    return this.toFixed(2).replace('.', ',');
}



