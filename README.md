# Rotas.API

Este projeto é uma API desenvolvida em **.NET Core**, utilizando o padrão de Use cases, com aplicação de princípios do Clean Architecture, Usa o Entity Framework In memory para persistência temporária de dados. O código foi estruturado para seguir boas práticas de design, incluindo **DRY (Don't Repeat Yourself)** , **KISS (Keep It Simple, Stupid)** e **Clean Code.**

## Requisitos para rodar o projeto

O projeto não tem nada fora do normal do desafio, porém é importante destacar para caso não tenha alguma das dependências ou algum problema para iniciar / consumir a aplicação. Seguem requisitos e links úteis :

### 1. **.NET Framework / SDK**
- **.NET 8.0 SDK** ou superior para o .NET.
- [Download do .NET SDK](https://dotnet.microsoft.com/download)

### 2. **IDE**
- **Visual Studio** (recomendado): Para uma experiência completa, incluindo Swagger e suporte de inicialização local do projeto.
- **Visual Studio Code**: Caso utilize o VS Code, certifique-se de ter a extensão **C#** instalada.

### 3. **Node.js**
- **Node.js**: Para a interface de front-end (Angular), será necessário ter o **Node.js** instalado.
- [Download do Node.js](https://nodejs.org/)

### 4. **Bibliotecas e Frameworks**
- **Entity Framework Core (In-Memory)**: Usado para persistência de dados temporária. Não é necessário um banco de dados real para rodar o projeto, pois ele utiliza um banco de dados em memória para prova de conceito.

### 5. **Navegadores e APIs**
- **Swagger**: O Swagger é configurado para fornecer uma interface visual para testar os endpoints da API.
- **Angular Front-End**: A aplicação front-end em Angular se comunica com a API para exibir e controlar informações.

## Como rodar o projeto

### Backend (.NET API Core)
1. Clona, e depois abra o projeto na IDE escolhida nos passos acima.
2. Certifique-se de que a versão do .net está instalada, e se certifique de marcar sim caso ele queira instalar certificados.
3. Execute a API pela IDE.
4. A API será inicializada na URL: `https://localhost:7028`.
5. Utilize o Swagger acessando: `https://localhost:7028/swagger`, ou pelo visual studio será levado automaticamente ao swagger.

### Frontend (Angular)
1. No diretório `Rotas.Angular/Rotas.Angular`, execute o comando `npm install` para instalar as dependências.
2. Inicie o servidor Angular com o comando `ng serve`.
3. A interface estará disponível em: `http://localhost:4200`.

Observações : 
1 - É de suma importância que essas portas descritas acimas não estejam sendo utilizadas por nenhum outro processo.
2 - A criação dos dados iniciais é feita usando o seed do EF In Memory, ou seja, não é necessário inserir esses dados toda vez que iniciar a aplicação.
3 - A Estrutura escolhida foi uma opção didática, para demonstrar conhecimentos de padrões escalaveis de tamanhos reais de mercado.
4 ( Final )  - Me propus a fazer o desafio em Angular por ser um foco da missão, me diverti desenvolvendo esta pequena prova de conceito, qualquer dúvida podem me contatar pelo email ou pelo whats app! Muito Obrigado!!!!!
