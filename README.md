# Pizzaria UDS

Este é o projeto de uma simples pizzaria obedecendo os requisitos e regras de negócio da documentação recebida.

## Observações

Me baseei principalmente no projeto Equinox do MVP da Microsoft Eduardo Pires (https://github.com/EduardoPires/EquinoxProject). A arquitetura apresentada neste projeto é complexa e não é necessária para o desenvolvimento de projetos de menor escala como este, mas eu decidi utilizá-la para demonstrar conhecimento de novas tecnologias e padrões que seriam utilizados em projetos de grande escala.

## Requisitos

### API
Como o projeto vai apenas até a API, alguns detalhes dos requisitos como a ordem com que o usuário selecionaria os componentes de sua pizza (primeiramente o tamanho e em seguida o sabor) não puderam ser concretizados, uma vez que a API já assume que todos os valores estão corretos para entrar no sistema. A API é testável com o uso de Swagger, bastando inserir /swagger/ no fim da URL inicial do projeto. Vale notar que o nome da entidade escolhido é Order (Pedido), uma vez que é o pedido que será registrado, embora não tenha comportamento próprio, apenas utilizando as características da Pizza.

### 001 - Montar Pizza
Como documentado acima, a ordem presente neste requisito depende de uma tela, a qual o projeto não possui. A API recebe todos os valores referentes aos componentes da pizza já prontos e assim calcula o preço e o tempo estimado de preparo para a pizza/pedido.

### 002 - Personalizar Pizza
A API aceita uma lista de customizações de pizza, que no projeto são representadas por uma enumeração (Enum). Como em nenhum ponto dos requisitos foi solicitada a adição de novas customizações (e até sabores), estes ficaram fixos no código, embora em um cenário real eles seriam suas próprias entidades que seriam armazenadas no banco de dados. Além disso, a personalização é possível e está coberta por testes de forma que não existam testes redundantes, por exemplo, não são testadas todas as combinações, mas pelo menos uma vez cada uma delas e uma vez com todas elas juntas.

### 003 - Montar Pedido
Como nosso pedido é muito simples ele é basicamente um encapsulador de Pizza para registro, que foi a abordagem que eu decidi seguir. Os detalhes do pedido conforme o requisito pede nada mais é sua ViewModel, que será retornada fazendo uma requisição GET na API.

## Considerações Finais
Acabei realizando testes apenas para as regras de negócio, ou seja, a construção de uma pizza. Estes testes de domínio foram poucos mas garantem que a regra de negócio esteja correta. Decidi não fazer testes de integração por ocupar muito tempo e que não seriam tão relevantes ao objetivo do teste.
