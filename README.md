<h1> Controle de Estoque em C#/.NET 7 </h1>
Status: Developing 🛠️
<br></br>
Este projeto é um sistema de controle de estoque desenvolvido em C#/.NET 7, utilizando ASP.NET para a construção do backend. O banco de dados é gerenciado pelo MySQL Workbench, e o servidor web WmapServer é empregado para hospedar os serviços.A iniciativa do projeto é de extensão universitária.
<h2>Estrutura do Projeto</h2>
O sistema é composto por três microserviços essenciais:

<h3>Cadastro de Produto</h3>
<ul>
  <li>Permite a adição, atualização e remoção de produtos no estoque.</li>
  <li>Fornece informações detalhadas sobre cada produto, como nome, preço, quantidade em estoque, etc.</li>
</ul>
<h3>Cadastro de Cliente</h3>
<ul>
  <li>Gerencia o cadastro e atualização de informações de clientes.</li>
  <li>Armazena dados relevantes, incluindo nome, endereço, e outras informações relacionadas aos clientes.</li>
</ul>
<h3>Cadastro de Venda</h3>
<ul>
  <li>Controla o processo de vendas, registrando as transações entre clientes e produtos.</li>
  <li>Mantém um histórico de vendas, incluindo detalhes como produtos vendidos, quantidades, preços, etc.</li>
</ul>
<h2>Instalação e Configuração</h2>
Siga os passos abaixo para configurar o projeto em sua máquina local:
<h3>Clonar o Repositório</h3>
  git clone https://github.com/LAOSTI/ControleDeEstoque.Net
<h3>Configurar o Banco de Dados</h3>
  <ul>
    <li>Crie um banco de dados com o nome "controledeestoque".</li>
    <li>Importe os arquivos localizados na pasta "Banco De Dados" dentro do repositório clonado.</li>
  </ul>
<h3>Configurar Visual Studio 2022</h3>
  <ul>
    <li>Execute o Visual Studio 2022</li>
    <li>Clique com o botão direito na solução.</li>
    <li>Selecione "Configure Startup Projects".</li>
    <li>Marque a opção "Multiple Startup Projects".</li>
    <li>Em "Action", selecione "Start" para ambas as aplicações.</li>
  </ul>
<h2>Uso</h3>
  <ul>
    <li>Execute o WampServer</li>
    <li>Execute a aplicação</li>
  </ul>
    
