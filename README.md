# Password Validator API

## Descrição

API REST desenvolvida em ASP.NET Core 8 que valida senhas de acordo com um conjunto configurável de regras de segurança.

---

## 💻  Execução da aplicação

### Opção 1: Clone do GitHub + Execução Local

#### 📋 Pré-requisitos
- .NET 8 SDK instalado

#### Passos

```powershell
# 1. Clonar o repositório
git clone https://github.com/StephanieGdSantos/password-validator.git
cd password-validator

# 2. Restaurar dependências
dotnet restore

# 3. Executar a aplicação
dotnet run --project password-validator/password-validator.csproj
```

**Aplicação disponível em:**
- 🔗 HTTP: `http://localhost:5113`
- 🔒 HTTPS: `https://localhost:7147`
- 📚 Swagger: `http://localhost:5113/swagger`

---

### Opção 2: Pull do Docker Hub + Execução em Container

#### 📋 Pré-requisitos
- Docker instalado e em execução

#### Passos

```powershell
# 1. Puxar a imagem do Docker Hub
docker pull stephaniegomes/password-validator:latest

# 2. Executar o container
docker run -d -p 8080:8080 -p 8081:8081 stephaniegomes/password-validator:latest
```

**Aplicação disponível em:**
- 🔗 HTTP: `http://localhost:8080`
- 🔒 HTTPS: `https://localhost:8081`
- 📚 Swagger: `http://localhost:8080/swagger`

---

## 📚 Documentação da API

### Endpoint: Validar Senha

**POST** `/validate-password`

**Request:**
```json
{
  "password": "SenhaValida123!"
}
```

**Response (Sucesso - 200 OK):**
```json
true
```

**Response (Falha - 200 OK):**
```json
false
```

**Response (Erro - 400 Bad Request):**
```json
{
  "errors": {
    "password": ["The password field is required."]
  }
}
```

---

## 🏗️ Arquitetura da Solução

### Estrutura de Camadas

```
password-validator/
├── API/
│   └── Controllers/
├── Application/
│   ├── Adapters/
│   └── DTOs/
├── Domain/
│   ├── Validators/
│   └── Specifications/
└── Configurations/
```

---

## 🎯 Detalhes Sobre a Solução

#### Design Patterns Utilizados

1. **Strategy Pattern** </br>
O uso do Strategy Pattern foi pensado visando reduzir acoplamento e facilitar a manutenibilidade devido às regras serem independentes entre si. Desta forma, é possível inserir e excluir regras de validação de senha sem necessidade de mexer em outras partes do código.

2. **Specification Pattern** </br>
Dado o cenário em que a senha deve passar por diversas regras para garantir a validade no negócio, optei pelo uso de Specification Pattern para centralizar os filtros.

3. **Adapter Pattern** </br>
O Adapter foi utilizado para converter o booleano em um DTO retornado ao usuário da API. Apesar de ser um simples booleano, entendo que o uso de DTOs facilite a manutenibilidade quando houver necessidade de mudanças no contrato. A escolha foi feita majoritariamente pensando em organização da aplicação.

4. **Dependency Injection** </br>
A técnica de injeção de dependência para inversão de controle foi aplicada para reduzir o acoplamento/responsabilidade entre as classes e facilitar testes na aplicação.

5. **Options Pattern** </br>
Optei pelo uso da interface IOptions para injetar valores mutáveis e externos a aplicação (quantidade máxima de caracteres) para promover tanto a separação de responsabilidades quanto testabilidade da aplicação.

#### Fluxo de Validação

```
[Requisição HTTP]
         ↓
[ValidatePasswordController]
         ↓
[ValidateResponseAdapter]
         ↓
[PasswordSpecification]
         ↓
[Executar todas as estratégias de validação]
         ↓
[Retornar resultado boolean]
```

---

## 💡 Premissas e Decisões Assumidas

#### Premissa 1: Devo me preocupar com mudanças a longo prazo?

Apesar de entender que a API foi desenvolvida para fins de processo seletivo, acredito que seja importante pensar nas melhores práticas quando possível para garantir a recorrência do pensamento. Visto que o objetivo seria trazer o repertório técnico, escolhi implementar o ponto de configuração apresentado pelo 12 factors por meio da interface IOptions, para prevenir futuras mudanças no requisito de tamanho mínimo de senha.

---

#### Premissa 2: Ordem das regras

Como as regras são majoritariamente independentes entre si, assumi que não seria necessária uma ordem de validação fixa. Assim, usei LINQ para aplicar as validações conforme a atribuição da lista (sem fluxo fixo).

## 📦 Dependências Principais

| Pacote | Versão | Propósito |
|--------|--------|----------|
| ASP.NET Core | 8.0 | Framework web |
| Swashbuckle.AspNetCore | 6.6.2 | Documentação Swagger |
| xUnit | 2.5.3 | Framework de testes |
| Microsoft.AspNetCore.Mvc.Testing | 8.0.26 | Testes de integração |

---

## 🔧 Configuração

### appsettings.json

```json
{
  "LengthPasswordValidators": {
    "MinimumLength": [seu_valor_aqui]
  }
}
```