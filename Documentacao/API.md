# Documentação API

 * [SiriusTattooApi](#siriustattooapi)
 * [Controllers](#método-de-controle)
    * [Agenda](#agenda-endpoints)
    * [Clientes](#clientes-endpoints)
    * [Compras](#compras-endpoints)
    * [Tatuadores](#tatuadores-endpoints)
    * [Tatuagens](#tatuagens-endpoints)
---

# SiriusTattoo.Api 

**Uma API RESTful completa para gestão de estúdios de tatuagem.**

A SiriusTattoo API é uma solução back-end desenvolvida em C# e .NET para gerenciar as operações de um estúdio de tatuagem. A API expõe endpoints RESTful para interagir com um front-end WebForms, utilizando HttpClient para realizar requisições HTTP e obter dados em formato JSON. O back-end utiliza Entity Framework Core para interagir com um banco de dados SQL Server, armazenando informações sobre clientes, tatuadores, tatuagens, agendamentos e compras.

**Características:**
* **Interação com WebForms:** Utiliza HttpClient para comunicação com o front-end.
* **Gerenciamento completo:** Cadastro de clientes, tatuadores, tatuagens e agendamento de sessões.
* **Tecnologia:** C#, .NET, Entity Framework Core, SQL Server.
* **Formato de dados:** JSON.


---
# Método de Controle

## Agenda Endpoints

### 1. **GET /api/v1/agendas**
- **Descrição**: Retorna uma lista de todos os agendamentos.
- **Retorno**: `IEnumerable<AgendaModel>`
- **Exemplo de Resposta**:
    ```json
    [
      { "Id": 1, "ClienteId": 1, "TatuadorId": 1, "Data": "2024-09-30T10:00:00", "Observacao": "Tatuagem de dragão." },
      { "Id": 2, "ClienteId": 2, "TatuadorId": 2, "Data": "2024-10-05T14:00:00", "Observacao": "Tatuagem de flor." }
    ]
    ```
---

### 2. **POST /api/v1/agendas/cadastrar**
- **Descrição**: Realiza o cadastro de um novo agendamento.
- **Corpo**: `AgendaModel` no corpo da requisição, contendo os seguintes dados:
    ```json
    {
      "ClienteId": 1,
      "TatuadorId": 1,
      "Data": "2024-09-30T10:00:00",
      "Observacao": "Tatuagem de dragão."
    }
    ```
- **Tratamento de Erros**: Se o objeto `AgendaModel` for nulo ou algum campo obrigatório estiver vazio, um erro será retornado com o status `400 Bad Request` e uma mensagem apropriada.
- **Processo**: Chama `CadastrarAgendamento()` do `AgendaRepository`.
- **Resposta**:
    - `201 Created`: Objeto `AgendaModel` cadastrado com o ID no cabeçalho da resposta.
    - **Exemplo de Resposta**:
        ```json
        {
          "Id": 1,
          "ClienteId": 1,
          "TatuadorId": 1,
          "Data": "2024-09-30T10:00:00",
          "Observacao": "Tatuagem de dragão."
        }
        ```
---

### 3. **DELETE /api/v1/agendas/{id}**
- **Descrição**: Deleta um agendamento com base no seu ID.
- **Parâmetro**: `id` (long) – O ID do agendamento a ser deletado.
- **Processo**:
    1. Busca o agendamento pelo ID utilizando o método `BuscarPorId` do `AgendaRepository`.
    2. Verifica se o agendamento existe:
        - Se o agendamento não for encontrado, retorna `404 Not Found` com a mensagem "Agendamento não encontrado."
        - Se encontrado, chama o método `DeletarAgendamentoPorId` do `AgendaRepository` para remover o agendamento do banco de dados.
    3. Se a exclusão for bem-sucedida, retorna `204 No Content`.
- **Possíveis Respostas**:
    - `204 No Content`: Agendamento deletado com sucesso, sem conteúdo de resposta.
    - `404 Not Found`: Agendamento não encontrado.
    - `500 Internal Server Error`: Em caso de erro interno no servidor, retorna a mensagem de erro.
- **Exemplo de Requisição**:
    ```http
    DELETE /api/v1/agendas/1
    ```
- **Exemplo de Resposta**:
    - Se o agendamento for deletado:
        ```http
        HTTP/1.1 204 No Content
        ```
    - Se o agendamento não for encontrado:
        ```json
        HTTP/1.1 404 Not Found
        {
          "message": "Agendamento não encontrado."
        }
        ```
---

## Clientes Endpoints

### 1. `GET /api/v1/clientes`
- **Descrição**: Retorna uma lista de todos os clientes.
- **Retorno**: `IEnumerable<ClientesModel>`
- **Exemplo de Resposta**:
    ```json
      { "Id": 1, "Nome": "João", "Email": "joao@example.com" },
      { "Id": 2, "Nome": "Maria", "Email": "maria@example.com" }
    ```

---

### 2. `POST /api/v1/clientes/login`
- **Descrição**: Realiza o login de um cliente.
- **Corpo**: `LoginRequest`
- **Exemplo de Requisição**:
    ```json
    { 
      "Email": "joao@example.com", 
      "Senha": "senha123" 
    }
    ```
- **Possíveis Respostas**:
    - `200 OK`: Autenticação bem-sucedida.
    - `401 Unauthorized`: Credenciais inválidas.

---

### 3. `POST /api/v1/clientes/Cadastro`
- **Descrição**: Cadastra um novo cliente.
- **Corpo**: `ClientesModel`
- **Exemplo de Requisição**:
    ```json
    {
      "Nome": "João Silva",
      "Email": "joao.silva@example.com",
      "Senha": "senhaSegura123",
      "Telefone": "123456789",
      "DataNascimento": "1990-01-01"
    }
    ```
- **Tratamento de Erros**: Se o objeto `ClientesModel` for nulo ou algum campo obrigatório estiver vazio, um erro será retornado com o status `400 Bad Request` e uma mensagem apropriada.
- **Processo**: Chama `CadastrarCliente()` do `ClientesRepository`.
- **Resposta**:
    - `201 Created`: Objeto `ClientesModel` cadastrado com o ID no cabeçalho da resposta.
- **Exemplo de Resposta**:
    ```json
    {
      "Id": 1,
      "Nome": "João Silva",
      "Email": "joao.silva@example.com"
    }
    ```

---

### 4. `DELETE /api/v1/clientes/DeletarCliente/{id}`
- **Descrição**: Deleta um cliente com base no seu ID.
- **Parâmetro**: `id` (long) → O ID do cliente a ser deletado.
- **Processo**:
    1. Busca o cliente pelo ID utilizando o método `BuscarPorId` do `ClientesRepository`.
    2. Verifica se o cliente existe:
        - Se o cliente não for encontrado, retorna `404 Not Found` com a mensagem "Cliente não encontrado."
        - Se encontrado, chama o método `DeletarClientePorId` do `ClientesRepository` para remover o cliente do banco de dados.
    3. Se a exclusão for bem-sucedida, retorna `204 No Content`.
- **Possíveis Respostas**:
    - `204 No Content`: Cliente deletado com sucesso, sem conteúdo de resposta.
    - `404 Not Found`: Cliente não encontrado.
    - `500 Internal Server Error`: Em caso de erro interno no servidor, retorna a mensagem de erro.
- **Exemplo de Requisição**:
    ```http
    DELETE /api/v1/clientes/DeletarCliente/1
    ```
- **Exemplo de Resposta**:
    - Se o cliente for deletado:
        ```http
        HTTP/1.1 204 No Content
        ```
    - Se o cliente não for encontrado:
        ```json
        HTTP/1.1 404 Not Found
        {
          "message": "Cliente não encontrado."
        }
        ```
---

## Tatuadores Endpoints

### 1. **GET /api/v1/tatuadores**
- **Descrição**: Retorna uma lista de todos os tatuadores.
- **Retorno**: `IEnumerable<TatuadoresModel>`
- **Exemplo de Resposta**:
    ```json
      { "Id": 1, "Nome": "Carlos", "Email": "carlos@example.com" },
      { "Id": 2, "Nome": "Ana", "Email": "ana@example.com" }
    ```
---

### 2. **POST /api/v1/tatuadores/login**
- **Descrição**: Autentica um tatuador com base no email e na senha fornecidos.
- **Corpo**: `LoginRequest`
- **Exemplo de Requisição**:
    ```json
    { "Email": "carlos@example.com", "Password": "senha123" }
    ```
- **Possíveis Respostas**:
    - `200 OK`: Autenticação bem-sucedida.
    - `401 Unauthorized`: Usuário ou senha inválidos.
---

### 3. **POST /api/v1/tatuadores/cadastro**
- **Descrição**: Realiza o cadastro de um novo tatuador no sistema.
- **Corpo**: `TatuadoresModel` no corpo da requisição, contendo os seguintes dados:
    ```json
    {
      "Nome": "Carlos Silva",
      "Email": "carlos.silva@example.com",
      "Senha": "senhaSegura123",
      "Telefone": "987654321",
      "Especialidade": "Realismo"
    }
    ```
- **Tratamento de Erros**: Se o objeto `TatuadoresModel` for nulo ou algum campo obrigatório estiver vazio, um erro será retornado com o status `400 Bad Request` e uma mensagem apropriada.
- **Processo**: Chama `CadastrarTatuador()` do `TatuadoresRepository`.
- **Resposta**:
    - `201 Created`: Objeto `TatuadoresModel` cadastrado com o ID no cabeçalho da resposta.
    - **Exemplo de Resposta**:
        ```json
        {
          "Id": 1,
          "Nome": "Carlos Silva",
          "Email": "carlos.silva@example.com"
        }
        ```
---

### 4. **DELETE /api/v1/tatuadores/DeletarTatuador/{id}**
- **Descrição**: Deleta um tatuador com base no seu ID.
- **Parâmetro**: `id` (long) – O ID do tatuador a ser deletado.
- **Processo**:
    1. Busca o tatuador pelo ID utilizando o método `BuscarPorId` do `TatuadoresRepository`.
    2. Verifica se o tatuador existe:
        - Se o tatuador não for encontrado, retorna `404 Not Found` com a mensagem "Tatuador não encontrado."
        - Se encontrado, chama o método `DeletarTatuadorPorId` do `TatuadoresRepository` para remover o tatuador do banco de dados.
    3. Se a exclusão for bem-sucedida, retorna `204 No Content`.
- **Possíveis Respostas**:
    - `204 No Content`: Tatuador deletado com sucesso, sem conteúdo de resposta.
    - `404 Not Found`: Tatuador não encontrado.
    - `500 Internal Server Error`: Em caso de erro interno no servidor, retorna a mensagem de erro.
- **Exemplo de Requisição**:
    ```http
    DELETE /api/v1/tatuadores/DeletarTatuador/1
    ```
- **Exemplo de Resposta**:
    - Se o tatuador for deletado:
        ```http
        HTTP/1.1 204 No Content
        ```
    - Se o tatuador não for encontrado:
        ```json
        HTTP/1.1 404 Not Found
        {
          "message": "Tatuador não encontrado."
        }
        ```
---
## Tatuagens Endpoints

### 1. **GET /api/v1/tatuagens**
- **Descrição**: Retorna uma lista de todas as tatuagens disponíveis.
- **Retorno**: `IEnumerable<TatuagensModel>`
- **Exemplo de Resposta**:
    ```json
    [
      { "Id": 1, "Nome": "Dragão", "Preco": 300, "Descricao": "Tatuagem de dragão em estilo oriental." },
      { "Id": 2, "Nome": "Flor", "Preco": 150, "Descricao": "Tatuagem de flor com cores vibrantes." }
    ]
    ```
---

### 2. **GET /api/v1/tatuagens/tatuador/{Id}**
- **Descrição**: Busca as tatuagens de um tatuador com base no ID fornecido.
- **Parâmetro**: `Id` (long) - ID do tatuador.
- **Retorno**: `IEnumerable<TatuagensModel>`
- **Exemplo de Resposta**:
    ```json
    [
      { "Id": 1, "Nome": "Dragão", "Preco": 300, "Descricao": "Tatuagem de dragão em estilo oriental." },
      { "Id": 3, "Nome": "Lobo", "Preco": 250, "Descricao": "Tatuagem de lobo em estilo tribal." }
    ]
    ```
---

### 3. **POST /api/v1/tatuagens/cadastrar**
- **Descrição**: Realiza o cadastro de uma nova tatuagem no sistema.
- **Corpo**: `TatuagensModel` no corpo da requisição, contendo os seguintes dados:
    ```json
    {
      "Nome": "Dragão",
      "Preco": 300,
      "Descricao": "Tatuagem de dragão em estilo oriental.",
      "TatuadorId": 1
    }
    ```
- **Tratamento de Erros**: Se o objeto `TatuagensModel` for nulo ou algum campo obrigatório estiver vazio, um erro será retornado com o status `400 Bad Request` e uma mensagem apropriada.
- **Processo**: Chama `CadastrarTatuagem()` do `TatuagensRepository`.
- **Resposta**:
    - `201 Created`: Objeto `TatuagensModel` cadastrado com o ID no cabeçalho da resposta.
    - **Exemplo de Resposta**:
        ```json
        {
          "Id": 1,
          "Nome": "Dragão",
          "Preco": 300,
          "Descricao": "Tatuagem de dragão em estilo oriental."
        }
        ```
---

### 4. **DELETE /api/v1/tatuagens/{id}**
- **Descrição**: Deleta uma tatuagem com base no seu ID.
- **Parâmetro**: `id` (long) – O ID da tatuagem a ser deletada.
- **Processo**:
    1. Busca a tatuagem pelo ID utilizando o método `BuscarPorId` do `TatuagensRepository`.
    2. Verifica se a tatuagem existe:
        - Se a tatuagem não for encontrada, retorna `404 Not Found` com a mensagem "Tatuagem não encontrada."
        - Se encontrada, chama o método `DeletarTatuagemPorId` do `TatuagensRepository` para remover a tatuagem do banco de dados.
    3. Se a exclusão for bem-sucedida, retorna `204 No Content`.
- **Possíveis Respostas**:
    - `204 No Content`: Tatuagem deletada com sucesso, sem conteúdo de resposta.
    - `404 Not Found`: Tatuagem não encontrada.
    - `500 Internal Server Error`: Em caso de erro interno no servidor, retorna a mensagem de erro.
- **Exemplo de Requisição**:
    ```http
    DELETE /api/v1/tatuagens/1
    ```
- **Exemplo de Resposta**:
    - Se a tatuagem for deletada:
        ```http
        HTTP/1.1 204 No Content
        ```
    - Se a tatuagem não for encontrada:
        ```json
        HTTP/1.1 404 Not Found
        {
          "message": "Tatuagem não encontrada."
        }
        ```
---
