# Trivium_API
<strong>Este projeto foi criado fazendo uso de Entity Framework e SQLite, a criação do banco de dados, tabelas e relações são feitas automaticamente pela classe Program.cs. </strong>
Os seguintes endpoints foram criados e seus respectivos caminhos estão especificados na declaração das classes:
* ClientsController
  * GetClients: GET usado para retornar todos os clientes cadastrados;
  * GetClient: GET, recebendo como parâmetro a id, usado para retornar cliente específico;
  * CreateClient: POST usado para criar cliente novo;
  * UpdateClient: PATCH usado para atualizar cliente;
  * DeleteClient: DELETE uasdo para excluir cliente;
  * GetPurcharsesByClient: GET, recebendo como parâmetro a id do cliente, usado para buscar as compras de cliente específico, listando produtos e valor total da compra - REF Bonus #1;
  * GetMostBoughtProducts: GET, recebendo como parâmetro a id do cliente, usado para buscar os produtos mais comprados pelo cliente especificado - REF Bonus #4.

* ProductsController
  * GetProducts: GET usado para retornar todos os produtos cadastrados;
  * GetProduct: GET, recebendo como parâmetro a id do produto, usado para retornar produto específico;
  * GetTotalFromProduct: GET, recebendo como parâmetro a id do produto, usado para buscar compras para um produto - REF Bonus #2;
  * GetProfitByPurchase: GET, uasdo para listar produtos, total de compras e total arrecadado - REF Bonus #3.

* PurchasesController
  * GetPurchases: GET usado para retornar todas as compras;
  * GetPurchase: GET, recebendo como parâmetro a id da compra, usado para retornar compra específica.

<strong> Os endpoints foram testados com Swagger e os mesmos testes podem ser feitos executando o projeto e navegando até /swagger/index.html no navegador.</strong>


