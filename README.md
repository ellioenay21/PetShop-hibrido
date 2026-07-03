# 🐾 PetShop Híbrido

Sistema de gerenciamento de clientes e pets desenvolvido com **ASP.NET Core MVC**, utilizando **Entity Framework Core**, **SQLite** e a arquitetura **MVC + Repository Pattern + Service Layer**.

Este projeto foi desenvolvido com o objetivo de praticar conceitos fundamentais do desenvolvimento backend em .NET, incluindo CRUD completo, relacionamentos entre entidades, injeção de dependência e organização em camadas.

---

# 📌 Funcionalidades

## Clientes

* ✅ Cadastrar cliente
* ✅ Editar cliente
* ✅ Listar clientes
* ✅ Visualizar detalhes
* ✅ Ativar cliente
* ✅ Inativar cliente
* ✅ Excluir cliente
* ✅ Validação de CPF único

---

## Pets

* ✅ Cadastrar pet
* ✅ Vincular pet a um cliente
* ✅ Editar pet
* ✅ Listar pets
* ✅ Visualizar detalhes
* ✅ Ativar pet
* ✅ Inativar pet

---

# 🛠 Tecnologias utilizadas

* ASP.NET Core MVC
* C#
* Entity Framework Core
* SQLite
* Razor Views
* Bootstrap 5
* FluentValidation

---

# 📂 Estrutura do Projeto

```text
WebApplication1
│
├── Controllers
│   ├── ClienteController.cs
│   ├── PetController.cs
│   └── HomeController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Models
│   ├── Cliente.cs
│   ├── Pet.cs
│   └── ErrorViewModel.cs
│
├── Repositories
│   ├── ClienteRepository.cs
│   ├── PetRepository.cs
│   └── Interfaces
│
├── Services
│   ├── ClienteServices.cs
│   └── PetService.cs
│
├── Validators
│
├── ViewModels
│
├── Views
│
├── wwwroot
│
├── Program.cs
│
└── appsettings.json
```

---

# 🏛 Arquitetura utilizada

O projeto segue a arquitetura MVC.

```text
Usuário

↓

View

↓

Controller

↓

Service

↓

Repository

↓

DbContext

↓

SQLite
```

### Camadas

### View

Responsável pela interface do usuário.

---

### Controller

Recebe as requisições HTTP e coordena o fluxo da aplicação.

---

### Service

Implementa as regras de negócio.

Exemplos:

* validar CPF duplicado;
* impedir cadastro de pet para cliente inativo;
* ativar e inativar clientes e pets.

---

### Repository

Responsável exclusivamente pelo acesso ao banco de dados.

---

### DbContext

Realiza a comunicação entre o Entity Framework Core e o banco SQLite.

---

# 💾 Banco de Dados

O projeto utiliza **SQLite**.

O banco é criado automaticamente na primeira execução da aplicação através do:

```csharp
db.Database.EnsureCreated();
```

---

# 🚀 Como executar o projeto

## 1. Clonar o repositório

```bash
git clone https://github.com/ellioenay21/PetShop-hibrido.git
```

---

## 2. Entrar na pasta

```bash
cd PetShop-hibrido
```

---

## 3. Restaurar os pacotes

```bash
dotnet restore
```

---

## 4. Compilar

```bash
dotnet build
```

---

## 5. Executar

```bash
dotnet run
```

ou

```bash
dotnet watch
```

---

# 📦 Pacotes utilizados

```xml
Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Sqlite

Microsoft.EntityFrameworkCore.Tools

FluentValidation.AspNetCore
```

---

# 🧩 Comandos úteis do .NET CLI

## Restaurar dependências

```bash
dotnet restore
```

---

## Compilar

```bash
dotnet build
```

---

## Executar

```bash
dotnet run
```

---

## Executar monitorando alterações

```bash
dotnet watch
```

---

## Limpar projeto

```bash
dotnet clean
```

---

## Publicar

```bash
dotnet publish
```

---

# 🗃 Comandos Git

## Verificar status

```bash
git status
```

---

## Adicionar arquivos

```bash
git add .
```

---

## Criar commit

```bash
git commit -m "Descrição do commit"
```

Exemplo:

```bash
git commit -m "feat: cadastro de pets"
```

---

## Enviar para o GitHub

```bash
git push
```

---

## Atualizar repositório local

```bash
git pull
```

---

## Ver branches

```bash
git branch
```

---

## Criar nova branch

```bash
git checkout -b nome-da-branch
```

---

## Trocar de branch

```bash
git checkout nome-da-branch
```

---

## Histórico de commits

```bash
git log
```

---

# 📖 Conceitos praticados

* ASP.NET Core MVC
* CRUD
* Entity Framework Core
* SQLite
* Repository Pattern
* Service Layer
* Injeção de Dependência
* Razor Views
* Relacionamento 1:N
* DataAnnotations
* FluentValidation
* Async/Await
* LINQ

---

# 🎯 Objetivo

Este projeto foi desenvolvido para consolidar conhecimentos em desenvolvimento com ASP.NET Core MVC e servir como base para estudos de arquiteturas mais avançadas, como Clean Architecture, APIs REST e Domain-Driven Design (DDD).

---

# 👨‍💻 Autor

**Ellioenay**

GitHub: https://github.com/ellioenay21

---

# 📄 Licença

Este projeto foi desenvolvido para fins de estudo e aprendizado.
