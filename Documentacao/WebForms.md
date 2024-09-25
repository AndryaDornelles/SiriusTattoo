# Documentação do WebForms - Sirius Tattoo

## Sumário
1. [Tela: Login](#tela-login)
2. [Tela: Cadastrar Cliente](#tela-cadastrar-cliente)
3. [Tela: Home](#tela-home)
4. [Tela: Tatuagens Disponíveis](#tela-tatuagens-disponíveis)
5. [Tela: Cadastrar Tatuagens](#tela-cadastrar-tatuagens)
6. [Tela: Cadastrar Tatuador](#tela-cadastrar-tatuador)
7. [Tela: Compras](#tela-compras)
8. [Tela: Agendar Sessão](#tela-agendar-sessão)
9. [Tela: Agenda](#tela-agenda)
10. [Tela: Site Master](#tela-site-master)

## Estrutura do Projeto

### 1. Tela: Login
- **Descrição**: Tela de autenticação para usuários (clientes e tatuadores).
- **Funcionalidades**:
  - Campos para inserção de e-mail e senha.
  - Botão de "Entrar" que autentica o usuário.
  - Link para "Cadastro" de cliente.
    
    ![Tela de Login](https://github.com/user-attachments/assets/4dd71bf9-86a8-4721-a092-ed7523505e45)

### 2. Tela: Cadastrar Cliente
- **Descrição**: Tela para cadastro de novos clientes.
- **Funcionalidades**:
  - Campos para nome, e-mail, telefone, senha e data de nascimento.
  - Botão para salvar as informações do cliente.
  - Botão para cancelar o preenchimento de cadastro. _*Exibe um alerta perguntando se tem certeza._

    ![Cliente](https://github.com/user-attachments/assets/90ec9ba5-43c5-4e3c-aaeb-226a68031b03)

### 3. Tela: Home
- **Descrição**: Tela inicial do aplicativo, apresenta informações sobre o estúdio, serviços oferecidos e links para tela tatuagens disponíveis.
- **Funcionalidades**:
  - Navegação para outras telas (pela barra de navegação) e botão para tela de tatuagens disponíveis.
    
    ![Tela de Home](https://github.com/user-attachments/assets/ca5177b1-1fc3-4866-8bd3-32de6ceba7ae)

### 4. Tela: Tatuagens Disponíveis
- **Descrição**: Exibe todas as tatuagens disponíveis para compra.
- **Funcionalidades**:
  - Imagens e descrições das tatuagens.
  - Filtro de seleção de tatuador.

    _Visão do Cliente_
    ![Tatuagens](https://github.com/user-attachments/assets/296a1d57-88c2-4fe0-bfef-c20a86e557e9)
 
    _Visão do Tatuador_    
    ![TatuagensTatuador](https://github.com/user-attachments/assets/101091ee-3856-43af-b2ef-2caa11350c5d)

### 5. Tela: Cadastrar Tatuagens
- **Descrição**: Tela para cadastro de Tatuagens.
- **Funcionalidades**:
- Campos para nome, descrição, preço, id do tatuador e upload de imagem.
- Botão para salvar as informações.
- Botão para cancelar.

  ![CadastrarTatuagem](https://github.com/user-attachments/assets/7763d9eb-37ba-4569-baf9-a4b545ef92eb)

### 6. Tela: Cadastrar Tatuador
- **Descrição**: Tela para cadastro de tatuadores.
- **Funcionalidades**:
  - Campos para nome, e-mail, especialização e foto do tatuador.
  - Botão para salvar as informações do tatuador.
  - Botão para cancelar o preenchimento do cadastro.

    ![Tatuador](https://github.com/user-attachments/assets/beee69b2-c6f8-4137-b9d4-afd9774b89e6)  

### 7. Tela: Compras
- **Descrição**: Permite que os clientes visualizem seu carrinho de compras de tatuagens.
- **Funcionalidades**:
  - Carrinho de compra com a tatuagem selecionada.
  - Opção para "pagar" tatuagens ao carrinho. *_Apenas visual_
  - Botão para finalizar e agendar a sessão.

    ![Carrinho](https://github.com/user-attachments/assets/f46506d7-39cb-4d2f-bae3-05cb10a626ac)
    ![Pagamento](https://github.com/user-attachments/assets/016cfd8e-76e9-4ca7-b82a-124068d60f43)

### 8. Tela: Agendar Sessão
- **Descrição**: Permite que o cliente agende uma nova sessão de tatuagem.
- **Funcionalidades**:
  - Seleção de data/hora.
  - Se tentar agendar horário já ocupado, irá receber um aviso para selecionar outro.
  - Seletor de horários pré-definidos.
  - Botão para confirmar agendamento.

    ![Agendar](https://github.com/user-attachments/assets/2ea0f8da-c76d-4336-9c17-14f20925c00d)

### 9. Tela: Agenda
- **Descrição**: Exibe a agenda de sessões agendadas.
- **Funcionalidades**:
  - Visualização de todas sessões agendadas e especificando o nome do cliente, se for tatuador.
  - Visualização de sessões agendadas, se for cliente, vê apenas as suas marcações.
 
    _Visão do Cliente_
    ![Agenda](https://github.com/user-attachments/assets/8db7b0fc-2b40-41c3-a9e2-88a93044fa5a)
    
    _Visão do Tatuador_
    ![AgendaTatuador](https://github.com/user-attachments/assets/f9d172d9-ed4b-4895-9e34-eccdfd753df8)


### 10. Tela: Site Master
- **Descrição**: Layout base para todas as páginas do site.
- **Funcionalidades**:
  - Navegação consistente entre as páginas.
  - Exibição de cabeçalho, rodapé e menus de navegação.
  - Uso de alguns scripts
