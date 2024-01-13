# Projeto Shop

## Visão Geral

Este projeto foi desenvolvido para praticar conceitos básicos do .NET Core e Angular. Ele consiste em uma aplicação web de compras, com um front-end em Angular, um back-end em .NET Core, e utiliza um banco de dados SQL Server.

## Passos de Execução

### 1. Clonar o projeto

```bash
git clone https://github.com/renanjorge/shop-project.git
cd shop-project
```

### 2. Clonar o projeto

Utilize o Docker Compose para iniciar os containers da aplicação:
```bash
docker-compose up -d
```

### 3. Acesso às Aplicações

- **Shop Web (Front-end)**
  - Acesse [localhost:4200](http://localhost:4200)

- **Shop API (Back-end)**
  - Acesse [localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html) para acessar a documentação Swagger.

- **Shop DB (Banco de Dados)**
  - O banco de dados SQL Server estará disponível em [localhost:1433](http://localhost:1433).

## Bibliotecas e Ferramentas

### Back-end (.NET Core)

- **EF Core + Migration:** ORM e ferramenta de migração para manipulação do banco de dados.
- **xUnit:** Framework de teste unitário para .NET.
- **Moq:** Biblioteca de mocking para testes.
- **AutoFixture:** Biblioteca para criação automática de objetos para testes.
- **Swagger:** Ferramenta para documentação e teste de APIs.
- **FluentValidation:** Biblioteca para validação de objetos.

### Front-end (Angular)

- **Angular:** Framework para construção de aplicações web.
- **Angular Material:** Biblioteca de componentes de interface do usuário para Angular.
- **Bootstrap:** Framework de design para estilização.
