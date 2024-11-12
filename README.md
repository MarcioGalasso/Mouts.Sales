# 

# Mouts.Sales

Projeto crud de vendas. Projeto conta com banco em memoria que iria disponibilizar alguns produtos externos junto com uma venda ja cadastrada.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos

Donet 6
RabbitMq
Docker
### 🔧 Instalação

RabbitMq
Utilizaremos Docker para subir uma imagem do RabbitMq para utilizarmos na configuração da  aplicação

[Instalar Docker](https://www.docker.com/products/docker-desktop/). 

docker run -d --hostname my-rabbit --name rabbit -b 15672:15672 -p 5672:5672 rabbitmq:3-management

Ajustar Appsetings do projeto Mouts.Sale.Api 

"MessageBus": {
    "host": "localhost",
    "username": "guest",
    "password": "guest" 
  }

Na raiz pasta do projeto  projeto Mouts.Sale.Api e execute o comando no prompt

dotnet run

## ⚙️ Executando os testes

Na raiz pasta do projeto  projeto Mouts.Sale.Tests e execute o comando no prompt
dotnet test


## 🛠️ Construído com

Frameworks/lib 

EntityFramework
Dapper
Swagger
MessageBus como provider do Rabbit
Moq para testes
xunit
FluentAsserts 

## 🎁 Expressões de gratidão

Obrigado desde ja pela oportunidade.

