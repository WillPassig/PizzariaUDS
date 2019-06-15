using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Models.Pizzas
{
    //Os nomes dos sabores foram mantidos em português pois são nomes comuns e conhecidos de pizzas no Brasil. Marguerita (Margherita) é uma exceção pois ainda é conhecida com este nome fora do país.
    //Apesar do projeto e sua estrutura estarem em inglês, em um projeto real de maior escopo estes valores não ficariam armazenados neste enum e sim em uma tabela do banco de dados como uma própria entidade sabor
    public enum PizzaFlavor
    {
        CALABRESA,
        MARGUERITA,
        PORTUGUESA
    }
}
