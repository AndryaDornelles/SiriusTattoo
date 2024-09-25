# Banco de Dados SQL Server

### Sumário

* [Introdução](#introdução)
* [Tabelas do Banco de dados](#tabelas-do-banco-de-dados)
    * [Agenda](#agenda)
    * [Clientes](#clientes)
    * [Compras](#compras)
    * [Tatuadores](#tatuadores)
    * [Tatuagens](#tatuagens)
* [Criação](#criação)
* [Operações Básicas](#operações-básicas)
* [Considerações Finais](#considerações-finais)

---

# Introdução
O banco de dados **SíriusTattoo** foi desenvolvido no **SQL Server** para gerenciar clientes, tatuadores, sessões de tatuagem (agenda), compras de tatuagens e os detalhes das tatuagens oferecidas pelo estúdio.

# Tabelas do Banco de Dados

## Agenda
| Nome da Coluna |        Tipo de Dados         |
|----------------|:----------------------------:|
| Id             | BIGINT IDENTITY(1,1) NOT NULL|
| Cliente_Id     | BIGINT NOT NULL              |
| Tatuador_Id    | BIGINT NOT NULL              |
| Data_Sessao    | DATETIMEOFFSET(7)            |
| Duracao        | TIME(7)                      |
| Status         | NVARCHAR(50)                 |

#### Chave Primária:

* `Id (CLUSTERED)`

#### Chave Estrangeira:

* `Cliente_Id` -> Clientes(Id)
* `Tatuador_Id` -> Tatuadores(Id)

## Clientes
| Nome da Coluna  |        Tipo de Dados          |
|-----------------|:-----------------------------:|
| Id              | BIGINT IDENTITY(1,1) NOT NULL |
| Nome            | NVARCHAR(255) NOT NULL        |
| Email           | NVARCHAR(90) NOT NULL         |
| Senha           | NVARCHAR(20) NOT NULL         |
| Telefone        | NVARCHAR(11) NOT NULL         |
| Data_Nascimento | DATE NOT NULL                 |

#### Chave Primária:

* `Id (CLUSTERED)`

#### Chave Única:

* `Email (NONCLUSTERED)`

## Compras
| Nome da Coluna  |        Tipo de Dados          |
|-----------------|:-----------------------------:|
| Id              | BIGINT IDENTITY(1,1) NOT NULL |
| Cliente_Id      | BIGINT NOT NULL               |
| Tatuagem_Id     | BIGINT NOT NULL               |
| DataCompra      | DATETIMEOFFSET(7) NOT NULL (DEFAULT  sysdatetimeoffset())                              |

#### Chave Primária:

* `Id (CLUSTERED)`

#### Chave Estrangeira:

* `Cliente_Id` -> Clientes(Id)
* `Tatuagem_Id` -> Tatuagens(Id)

## Tatuadores
| Nome da Coluna  |        Tipo de Dados          |
|-----------------|:-----------------------------:|
| Id              | BIGINT IDENTITY(1,1) NOT NULL |
| Nome            | NVARCHAR(255) NOT NULL        |
| Email           | NVARCHAR(90) NOT NULL         |
| Senha           | NVARCHAR(20) NOT NULL         |
| Telefone        | NVARCHAR(11) NOT NULL         |
| Especialidade   | NVARCHAR(50) NOT NULL         |

#### Chave Primária:

* `Id (CLUSTERED)`

#### Chave Única:

* `Email (NONCLUSTERED)`

## Tatuagens
| Nome da Coluna  |        Tipo de Dados          |
|-----------------|:-----------------------------:|
| Id              | BIGINT IDENTITY(1,1) NOT NULL |
| Nome            | NVARCHAR(255) NOT NULL        |
| Descricao       | NVARCHAR(MAX) NULL            |
| Preco           | MONEY NOT NULL                |
| Tatuador_Id	  | BIGINT NOT NULL               |
| Imagem          |	VARCHAR(300) NULL             |

#### Chave Primária:

* `Id (CLUSTERED)`

#### Chave Estrangeira:

* `Tatuador_Id` -> Tatuadores(Id)

# Criação
### Tabela Agenda
```
CREATE TABLE Agenda (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Cliente_Id BIGINT NOT NULL,
    Tatuador_Id BIGINT NOT NULL,
    Data_Sessao DATETIMEOFFSET(7) NOT NULL,
    Duracao TIME(7) NULL,
    Status NVARCHAR(50) NULL,
    CONSTRAINT FK_Agenda_Cliente FOREIGN KEY (Cliente_Id) REFERENCES Clientes(Id),
    CONSTRAINT FK_Agenda_Tatuador FOREIGN KEY (Tatuador_Id) REFERENCES Tatuadores(Id)
);

```
### Tabela Clientes
```
CREATE TABLE Clientes (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    Email NVARCHAR(90) NOT NULL UNIQUE,
    Senha NVARCHAR(20) NOT NULL,
    Telefone NVARCHAR(11) NOT NULL,
    Data_Nascimento DATE NOT NULL
);
```
### Tabela Compras
```
CREATE TABLE Compras (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Cliente_Id BIGINT NOT NULL,
    Tatuagem_Id BIGINT NOT NULL,
    DataCompra DATETIMEOFFSET(7) NOT NULL DEFAULT sysdatetimeoffset(),
    CONSTRAINT FK_Compras_Cliente FOREIGN KEY (Cliente_Id) REFERENCES Clientes(Id),
    CONSTRAINT FK_Compras_Tatuagem FOREIGN KEY (Tatuagem_Id) REFERENCES Tatuagens(Id)
);
```
### Tabela Tatuadores
```
CREATE TABLE Tatuadores (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(50) NOT NULL,
    Email NCHAR(90) NOT NULL UNIQUE,
    Senha NCHAR(10) NOT NULL,
    Telefone NVARCHAR(11) NOT NULL,
    Especialidade NVARCHAR(50) NOT NULL
);
`````````
### Tabela Tatuagens
```
CREATE TABLE Tatuagens (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    Descricao NVARCHAR(MAX) NULL,
    Preco MONEY NOT NULL,
    Tatuador_Id BIGINT NOT NULL,
    Imagem VARCHAR(300) NULL,
    CONSTRAINT FK_Tatuagens_Tatuador FOREIGN KEY (Tatuador_Id) REFERENCES Tatuadores(Id)
) ON PRIMARY TEXTIMAGE_ON PRIMARY;
```

# Operações Básicas

### Inserir um Cliente
```
INSERT INTO Clientes (Nome, Email, Senha, Telefone, Data_Nascimento)
VALUES ('João Silva', 'joao.silva@email.com', 'senha123', '99999999999', '1990-01-01');
```
### Inserir um Tatuador
```
INSERT INTO Tatuadores (Nome, Email, Senha, Telefone, Especialidade)
VALUES ('Carlos Pereira', 'carlos.pereira@email.com', 'senha456', '88888888888', 'Tatuagem Realista');
```
### Inserir uma Tatuagem
```
INSERT INTO Tatuagens (Nome, Descricao, Preco, Tatuador_Id, Imagem)
VALUES ('Dragão Oriental', 'Tatuagem detalhada de um dragão oriental', 150.00, 1, '/imagens/dragao.png');
```
### Inserir uma Compra
```
INSERT INTO Compras (Cliente_Id, Tatuagem_Id)
VALUES (1, 1);
```
### Inserir uma Sessão na Agenda
```
INSERT INTO Agenda (Cliente_Id, Tatuador_Id, Data_Sessao, Duracao, Status)
VALUES (1, 1, '2024-09-25T14:00:00-03:00', '02:00:00', 'Agendado');
```

# Considerações Finais
O banco de dados **SiriusTattoo** foi cuidadosamente projetado para suportar todas as operações necessárias para o gerenciamento de um estúdio de tatuagem, desde o cadastro de clientes e tatuadores, até o agendamento de sessões e compra de tatuagens.
