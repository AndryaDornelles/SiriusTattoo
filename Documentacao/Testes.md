# Visão Geral dos Testes de Integração

Os testes de integração são fundamentais para garantir que diferentes componentes de um sistema interajam corretamente. No projeto, implementou-se vários testes para verificar as operações da API, que lidam com agendamentos, clientes, compras, tatuadores e tatuagens. Cada classe de teste tem uma responsabilidade específica, permitindo verificar se a API está se comportando conforme o esperado.

## Estrutura Geral dos Testes

A estrutura de cada classe de teste é semelhante, com um foco claro em uma parte específica da API:

1. **Configuração do Cliente HTTP**:
   - Cada classe de teste inicializa um `HttpClient` com a URL base da API (`https://localhost:7154/`), permitindo a realização de requisições HTTP para os endpoints definidos.
   
2. **Métodos de Teste**:
   - Cada classe contém métodos de teste, implementados como métodos assíncronos que utilizam o atributo `[Fact]` do xUnit para indicar que são testes que devem ser executados.
   - Os métodos seguem uma estrutura comum:
     - **Preparação**: Configuração dos dados de entrada.
     - **Execução**: Chamada à API usando `HttpClient`.
     - **Validação**: Verificação das respostas recebidas.

## Detalhamento das Classes de Teste

### AgendaApiTests
- **Objetivo**: Testar as operações relacionadas à agenda de tatuagens.
- **Métodos**:
  - `GetAgenda_ReturnsOk`: Verifica se a lista de agendamentos é retornada corretamente.
  - `GetAgenda_PorCliente_ReturnsOK`: Testa a filtragem de agendamentos por cliente.
  - `PostAgenda_Agendar_ReturnsCreated`: Verifica se um novo agendamento pode ser criado.

### ClientesApiTests
- **Objetivo**: Testar as operações de clientes.
- **Métodos**:
  - `GetClientes_ReturnsOK`: Verifica se a lista de clientes é retornada corretamente.
  - `PostCliente_Cadastrar_ReturnsCreated`: Testa a criação de um novo cliente e valida os dados retornados.

### ComprasApiTests
- **Objetivo**: Testar as operações de compra de tatuagens.
- **Métodos**:
  - `GetCompras_ReturnsOK`: Verifica se a lista de compras é retornada corretamente.
  - `PostCompras_Compras`: Testa a criação de uma nova compra e valida a resposta.

### TatuadoresApiTests
- **Objetivo**: Testar as operações relacionadas a tatuadores.
- **Métodos**:
  - `GetTatuadores_ReturnsOk`: Verifica se a lista de tatuadores é retornada corretamente.
  - `PostTatuador_Cadastrar_ReturnsCreated`: Testa a criação de um novo tatuador.

### TatuagensApiTests
- **Objetivo**: Testar as operações de tatuagens.
- **Métodos**:
  - `GetTatuagens_ReturnsOK`: Verifica se a lista de tatuagens é retornada corretamente.
  - `PostTatuagens_Cadastrar_ReturnsCreated`: Testa a criação de uma nova tatuagem.

## Ferramentas Utilizadas

- **Newtonsoft.Json**: Para realizar a serialização e desserialização de objetos JSON, permitindo a conversão de dados entre objetos C# e JSON.
- **System.Net.Http.Json**: Para facilitar a manipulação de requisições e respostas JSON, oferecendo métodos para ler e escrever conteúdo JSON diretamente.
- **xUnit**: A biblioteca de testes utilizada, que fornece a estrutura para a criação e execução de testes unitários. Os testes são organizados em classes e métodos, e o atributo `[Fact]` é usado para marcar métodos como testes a serem executados.
