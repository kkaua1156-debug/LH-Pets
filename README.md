# LH-Pets — Web API

Web API em ASP.NET Core MVC para cadastrar e consultar clientes e pets. Os dados ficam em listas em memória e são apagados quando a aplicação é encerrada.

## Requisitos

- .NET 10 SDK
- Visual Studio Code ou Visual Studio

## Executar

No terminal, dentro da pasta do projeto:

```bash
dotnet restore
dotnet run
```

Abra o endereço HTTPS informado no terminal e acrescente `/swagger` para acessar a interface de testes.

## Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/api/clientes` | Lista todos os clientes |
| POST | `/api/clientes` | Cadastra um cliente |
| GET | `/api/pets` | Lista todos os pets |
| POST | `/api/pets` | Cadastra pet vinculado a um cliente existente |
| GET | `/api/pets/cliente/{clienteId}` | Lista os pets de um cliente |

### Exemplos de corpo para POST

`POST /api/clientes`

```json
{
  "nome": "Ana Souza",
  "cpf": "12345678900",
  "email": "ana@example.com"
}
```

`POST /api/pets` (use um `clienteId` já retornado pelo cadastro de cliente)

```json
{
  "nome": "Luna",
  "especie": "Cachorro",
  "raca": "Labrador",
  "clienteId": 1
}
```

Os IDs são gerados automaticamente. Campos obrigatórios e formato do e-mail são validados; o cadastro de pet retorna erro quando o cliente informado não existe.

