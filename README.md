J3D ORM
==============

**Projeto para cirar de forma semi automática web sites utilizando Clean Architecture e Domain‑Driven Design (DDD), em Asp Net MVC.**

---

##  Visão Geral

Este projeto aplica os princípios de Clean Architecture e DDD para promover um código modular, fácil de testar e bem organizado. A estrutura separa claramente a lógica de domínio, aplicação e infraestrutura.

---

##  Tecnologias (sugeridas)

- ASP.NET MVC
- C#
- Clean Architecture (ex: camadas Domain, Application, Infrastructure)
- DDD (entidades, agregados, value objects, repositórios, etc.)
- Banco de dados (ex.: My SQL)
- ADO
- Testes

---

##  Estrutura Sugerida do Projeto

```
SoccerWebApi/
├── src/
│   ├── Domain/           # Lógica de domínio: entidades, agregados, interfaces, value objects
│   ├── Infrastructure/   # Implementação técnica: Repositórios, DbContext, EF Core, API Clients
│   ├── Presentation/     # Camada de apresentação: Controllers, configuração de DI, middleware
│   └── Tests/            # Projetos de testes unitários ou de integração
├── J3DSolutions.sln      # Solução .NET contendo todos os projetos
└── README.md             # Este arquivo de descrição
```

---

## ▶ Como Executar (sugestões)

1. Clone o repositório:
   ```bash
   git clone https://github.com/jomarsales/Site-Template-Creation.git
   ```
2. Abra a solução com o Visual Studio ou usando a CLI .NET:
   ```bash
   cd j3d.orm
   dotnet restore
   ```
---

##  Boas Práticas Aplicadas

- Separação clara de responsabilidades entre domínio, aplicação e infraestrutura.
- Lógica de negócios centralizada na camada de domínio (DDD).
- Camada de aplicação para orquestração de casos de uso.
- Infraestrutura abstraída por interfaces e injeção de dependência.
- Preparado para testes automatizados.

---

##  Licença

Projeto criado com finalidade de estudo e prática, sem fins comerciais.
