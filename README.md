<p align="center">
  <a href="https://dev.wirecard.com.br/v2.0/">
    <img src="https://raw.githubusercontent.com/matmiranda/pagbank-dotnet/main/Images/pagbank-dotnet.png" alt="Wirecard logo" width=400>
  </a>
</p>

## Como usar

Pacote Nuget [pagbank-dotnet](https://www.nuget.org/packages/pagbank-dotnet) ou execute o comando abaixo:

>dotnet add package pagbank-dotnet --version

Documentação Oficial da PagBank [api reference](https://dev.pagbank.uol.com.br/reference/introducao)

#### 1- Exemplo básico

```C#
using PagBank.Client;
using PagBank.Enum;

var token = "123";
var endpoint = "{coloca_seu_endpoint}";
var client = new PagBankClient(BaseUrl.Sandbox, token);
var response = await client.GetAsync(endpoint);
```

#### 2 - Passando parâmetro header

```C#
var header = new Dictionary<string, string>();
header.Add("accept", "application/json");
var endpoint = "{coloca_seu_endpoint}";
var response = await client.GetAsync(endpoint, header);
```

#### 3 - Exemplo de como listar assinauras

```C#
var token = "123";
var endpoint = "payments";
var client = new PagBankClient(BaseUrl.SandboxSignature, token);
var response = await client.GetAsync(endpoint);
```