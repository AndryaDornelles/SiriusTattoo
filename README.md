# SiriusTattoo - Sistema de Gestão de Estúdio de Tatuagem
# Sumário

1. [Descrição](#descrição)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Instalação](#instalação)
   - [1. Clonar o Repositório](#1-clonar-o-repositório)
   - [2. Configurar o Banco de Dados](#2-configurar-o-banco-de-dados)
   - [3. Restaure os pacotes NuGet necessários](#3-restaure-os-pacotes-nuget-necessários)
   - [4. Configure a string de conexão](#4-configure-a-string-de-conexão)
   - [5. Execute as migrações do banco de dados](#5-execute-as-migrações-do-banco-de-dados)
   - [6. Inicie a aplicação](#6-inicie-a-aplicação)
   - [7. Verifique se tudo está funcionando](#7-verifique-se-tudo-está-funcionando)
4. [Utilização](#utilização)
5. [Funcionalidades](#funcionalidades)
6. [Estrutura do Projeto](#estrutura-do-projeto)
7. [Documentação da API](#documentação-da-api)


## Descrição
O SiriusTattoo é um sistema web completo para gestão de estúdios de tatuagem, composto por uma aplicação WebForms e uma API RESTful. A aplicação permite cadastrar clientes, tatuadores, tatuagens, agendar sessões e muito mais. A API expõe endpoints para diversas funcionalidades, permitindo a integração com outros sistemas e utiliza LINQ para consultas eficientes ao banco de dados.

## Tecnologias Utilizadas
* **Front-end:** ASP.NET WebForms, HTML, CSS, JavaScript, Bootstrap
* **Back-end:** C#, ASP.NET
* **API:** ASP.NET Core, C#
* **Banco de dados:** SQL Server
* **Testes Unitários:** xUnit
* **Comunicação JSON:** System.Net.Http.Json
* **LINQ:** Para consultas eficientes ao banco de dados

## Instalação

Para instalar o projeto, siga estas etapas:

### **1. Clonar o Repositório**  
- Acesse o repositório do GitHub e clone-o:
  ```bash
  git clone https://github.com/AndryaDornelles/SiriusTattoo.git
  ```
### **2. Configurar o [Banco de Dados](https://github.com/AndryaDornelles/SiriusTattoo/blob/main/Documentacao/BancoDeDados.md)**
- **Criar o Banco de Dados**
  - Execute o script [SQLQuerySiriusTattoo.sql](SiriusTattooWebAplication/App_Data/SQLQuerySiriusTattoo.sql) no SQL Server Management Studio (SSMS) para criar o banco e tabelas.
  
- **Popular o Banco de Dados**
  - Apenas o 1º Tatuador é necessário popular antes da inicialização, faça diretamente pelo o SSMS, escolhendo os dados de seu agrado.

### 3. Restaure os pacotes NuGet necessários:

- No Visual Studio, clique com o botão direito do mouse na solução no Solution Explorer.
- Selecione **Restore NuGet Packages**. Isso baixará e instalará todas as dependências necessárias para o projeto.

### 4. Configure a string de conexão:

- Localize o arquivo `appsettings.json` na pasta do projeto da API.
- Abra o arquivo e encontre a seção `ConnectionStrings`.
- Atualize a string de conexão para apontar para o seu banco de dados SQL Server. O formato geralmente se parece com isto:

  ```json
  "ConnectionStrings": {
    "connection": "Server=NOTEBOOK;Database=SiriusTattoo;trusted_connection=true;TrustServerCertificate=True;"
  },
  ```

  Certifique-se de substituir pelos valores apropriados com a sua string de conexão.

### 5. Execute as migrações do banco de dados

- Abra o **Package Manager Console** no Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
- Execute o comando para aplicar as migrações:

  ```powershell
  Update-Database
  ```
  Isso criará as tabelas e a estrutura necessária no banco de dados conforme definido nas migrações do Entity Framework.

### 6. Inicie a aplicação

- Para a aplicação WebForms, você pode pressionar `F5` ou clicar em **Start** no Visual Studio.
- Para a API, você pode definir o projeto da API como o projeto de inicialização e, em seguida, iniciar a depuração.

### 7. Verifique se tudo está funcionando

- Acesse a aplicação WebForms pelo navegador no endereço `http://localhost:[PORTA]`, onde `[PORTA]` é a porta atribuída ao seu projeto.
- Teste os endpoints da API usando ferramentas como Postman ou Insomnia para garantir que todas as operações estão funcionando conforme o esperado.

Execute as migrações do banco de dados.

## Utilização
* **Aplicação WebForms:** Acesse a aplicação através do navegador para realizar as operações do dia a dia do estúdio.
* **API:** Utilize ferramentas como Postman ou um cliente HTTP para consumir os endpoints da API. A documentação da API está disponível em [Documentacao/API.md](https://github.com/AndryaDornelles/SiriusTattoo/blob/main/Documentacao/API.md).

## Funcionalidades

* **Aplicação WebForms:**
  * Cadastro de clientes
  * Cadastro de tatuadores
  * Cadastro de tatuagens
  * Agendamento de sessões

* **API:**

  * **Consultas avançadas:** Utilize os endpoints da API para realizar consultas complexas aos dados, aproveitando as funcionalidades do LINQ.

## Estrutura do Projeto
* **WebForms:** Contém a aplicação WebForms.
* **API:** Contém a aplicação ASP.NET Core com os endpoints da API.
* **Models:** Contém as classes que representam as entidades do domínio (Cliente, Tatuador, etc.).
* **DAL:** Contém a camada de acesso a dados (Data Access Layer) com implementações utilizando LINQ to Entities ou LINQ to SQL.
* **Tests:** Contém os testes unitários escritos com xUnit.

## Documentação da API
A documentação completa da API está disponível em [Documentação da API](https://github.com/AndryaDornelles/SiriusTattoo/blob/main/Documentacao/API.md). A documentação inclui:
* **Endpoints:** Uma lista de todos os endpoints disponíveis, com exemplos de requisições e respostas.
* **Modelos de dados:** A estrutura dos dados enviados e recebidos pelos endpoints.
* **Códigos de status:** Os códigos de status HTTP retornados pelos endpoints.
* **Consultas LINQ:** Exemplos de consultas LINQ utilizadas para obter os dados.

## Documentação dos [Testes](https://github.com/AndryaDornelles/SiriusTattoo/blob/main/Documentacao/Testes.md)

Testes Unitários com xUnit
Para garantir a qualidade e a confiabilidade do código no projeto SiriusTattoo, foram desenvolvidos testes unitários utilizando o framework xUnit. 
Esses testes cobrem diversas funcionalidades críticas na API, validação de regras de negócio e manipulação de dados. 
