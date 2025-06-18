# Telemarketing Performance Indicators

Sistema de acompanhamento de desempenho para empresas de telemarketing, desenvolvido com .NET 8 e seguindo os princípios do Domain-Driven Design (DDD).

## 🚀 Funcionalidades

- Cadastro de indicadores de desempenho
- Registro de coletas diárias
- Cálculo automático de resultados (média ou soma)
- Atualização de valores de coletas
- API REST para integração

## 🛠️ Tecnologias

- .NET 8
- C# 12
- Entity Framework Core 8
- SQL Server
- xUnit (testes)
- Moq (mocks para testes)

## 📋 Pré-requisitos

- .NET 8 SDK
- SQL Server (ou SQL Server Express)
- Visual Studio 2022 ou VS Code

## 🔧 Instalação

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/telemarketing-performance.git
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Configure a string de conexão no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=TelemarketingPerformance;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

4. Execute as migrações do banco de dados:
```bash
cd TelemarketingPerformance.WebApi
dotnet ef database update
```

5. Execute o projeto:
```bash
dotnet run
```

## 🧪 Executando os Testes

```bash
dotnet test
```

## 📦 Estrutura do Projeto

O projeto segue a arquitetura DDD com as seguintes camadas:

- **Domain**: Entidades, enums e interfaces de repositório
- **Application**: DTOs e serviços de aplicação
- **Infrastructure**: Implementação do EF Core e repositórios
- **WebApi**: Endpoints REST
- **Tests**: Testes unitários

## 📝 Exemplos de Uso

### Criar um Indicador
```http
POST /api/Indicadores
Content-Type: application/json

{
    "nome": "Média de ligações",
    "tipoDeCalculo": "MEDIA"
}
```

### Adicionar uma Coleta
```http
POST /api/Indicadores/{id}/coletas
Content-Type: application/json

{
    "data": "2024-03-20",
    "valor": 15.5
}
```

### Atualizar uma Coleta
```http
PUT /api/Indicadores/coletas/{id}
Content-Type: application/json

{
    "valor": 20.5
}
```

## 🤝 Contribuindo

1. Faça um Fork do projeto
2. Crie uma Branch para sua Feature (`git checkout -b feature/AmazingFeature`)
3. Faça o Commit das suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Faça o Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## ✨ Autor

Seu Nome - [seu-email@exemplo.com](mailto:seu-email@exemplo.com)

## 🙏 Agradecimentos

- Qualyteam pelo desafio técnico
- Comunidade .NET
- Todos os contribuidores 