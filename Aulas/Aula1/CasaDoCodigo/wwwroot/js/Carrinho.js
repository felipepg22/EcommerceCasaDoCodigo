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
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        });

        $("input[name='quantidade']").val(data.Quantidade);
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





