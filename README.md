# CRUD

Implementação de API REST com banco de dados em MySQL voltada para consulta e manipulação de dados, objetivando atender aos requisitos propostos no processo seletivo [Desafio Backend Júnio Automatiza](https://github.com/devfabricioalmeida/backend-csharp-automatiza/blob/main/README.md)

### 📋 Pré-requisitos

* [SDK .NET 8.0](https://dotnet.microsoft.com/en-us/download)
* Obter IDE de sua preferência - sugestão: [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) 
* Mecanismo de banco de dados [MySQL na versão (5.6.15)](https://drive.google.com/file/d/1q8n2wMvh1y_3-rXSQ1yDMLTyhDSwgL5D/view?usp=sharing)
* CLI [Dotnet EF](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install) 
 
 
 
### 🔧 Instalação

Após a instalação dos pré-requisitos será necessário configurar a aplicação para testes:

* MECANISMO DE BANCO DE DADOS
    
1. Durante a instalação do mecanismo de banco de dados é definida uma senha para o usuário root. Esta senha deverá ser setada no projeto em um arquivo de configuração .JSON para que a Aplicação e o Entity consigam se conectar com a base de dados local.

2. O aquivo de configuração .JSON está localizado no diretório {Projeto}\src\crud.API\appsettings.json
    ![alt text](backend-csharp-automatiza/assets/readmeAssets/configBD1.png)
    
    Bastando inserir a senha que foi previamente setada na instalação.

    
3. Acessar o mecanismo de banco de dados e executar as seguinte querys para disponibilizar os privilégios necessários ao root:

```
UPDATE mysql.user SET Grant_priv='Y', Super_priv='Y' WHERE User='root';

FLUSH PRIVILEGES;
```  
    A execução destas querys garatirá que o "root" terá a permissão necessária para manipular o Data Base.


* ENTITY FRAMEWORK

1. Será necessário instalar a CLI do EntityFramework no seu sistema operacional via CMD ou PowerShell. 
adendo: Executar o cmd ou PowerShell com privilégios de administrador

    ```
    dotnet tool install --global dotnet-ef
    ```  
2. para garantir que o pacote "CLI dotnet EF" está instalado você pode executar o seguinte comando:

    ```
    dotnet ef
    ```  
3. E em seguida reber o seguinte retorno:
![alt text](\assets\readmeAssets\dotnetEF.png)

4. Verificar SDK's instalados via cmd:

    ```
    dotnet --list-sdks
    ```  
5. Deverá receber o seguinte retorno:

    ```
    8.0.200 [C:\Program Files\dotnet\sdk]
    8.0.201 [C:\Program Files\dotnet\sdk]
    ``` 
6. O minnor[X.X.minnor] da versão não precisa ser específico contanto que o major[major.X.X] esteja 8 e já será sufiente para execução da API.

 
 
 
 
### ⚙️ Executando do projeto

Após cumprir os pré-requisitos e realizar as configurações podemos iniciar o processo de excução e teste da API: 

* Migration Entity Framework
    
2. Será necessário implementar uma migration que está previamente populada na camada "DAL" do projeto, para isso iremos utilizar o CLI .NET.

3. Acesse o CMD ou PowerShell na sua IDE. Inicialmente iremos nos deslocar via linha de comando para a camada(diretório) de inicialização da API e somente após estar neste diretório e que poderemos iniciar o processo da Migration.

```
    cd {projeto}\src\crud.API
``` 
Após estar no diretório iremos fazer o upload da migration que está previamente populada e estruturada para o banco de dados do projeto

```
    dotnet ef database update "MigrationPopulada" --project "../crud.DAL"
``` 
[Documentação oficial de consulta](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)

Após o procedimento ser executado com êxito receberemos uma informação na CLI e podemos consultar a estrutura implementada no nosso mecanismo de banco de dados.

 
 
 
 
### ⚙️ Execução de Testes

1. Swagger - Foi implementado no projeto uma funcionalidade do .NET chamada Swagger que facilita o processo de testes da API. Ele está implementado na paipline do projeto no arquivo "crud.API/Configuration/ApiConf" e pode ser desativado via comentário caso haja necessidade.

2. Com o mecanismo de banco de dados ativo, a migration implementada e os Pré-requisitos atendidos já podemos executar testes nos endpoints da aplicação.

3. Clicando no botão de RUN na inteface do Visual Studio o Swagger será chamado automaticamente exibindo os end-points do projeto:
![alt text](\assets\readmeAssets\runAPI.png)

4. Segue o exemplo do retorno que será exibido no browser padrão:
![alt text](\assets\readmeAssets\swagger.png)


5. Agora a aplicação está ponta para receber os testes de validação dos requisitos propostos pelo processo seletivo [DEV Junior Automatiza](https://github.com/devfabricioalmeida/backend-csharp-automatiza/blob/main/README.md)
 
 
 
 
 
### 🔩 EndPoints

EndPoint da API:

1. Marcas

``` html
POST /api/marcas: cadastrar uma nova marca.
GET /api/marcas: listar todas as marcas.
GET /api/marcas/{id}: Retorna os detalhes de uma marca específica pelo id.
PUT /api/marcas/{id}: Atualiza os dados de uma marca existente.
DELETE /api/marcas/{id}: SoftRemove de uma marca.
```

2. Produtos

``` html
POST /api/produtos: cadastrar um novo produto.
GET /api/produtos: listar todos os produtos.
GET /api/produtos/{id}: Retorna os detalhes de um produto específico pelo id.
PUT /api/produtos/{id}: Atualiza os dados de um produto existente.
DELETE /api/produtos/{id}: SoftRemove de um produto do sistema.
```

3. API Externa

``` html
GET /api/catalogo/{ean}/imagens: retorna URL's de acesso às imagens da API através da inserção do EAN.
```
 
 
 
 
 
### 🖇️ Decisões do Projeto

1. Arquitetura: Separei o projeto em camadas denominadas "crud.API","crud.BLL" e "crud.DAL" visando o desacoplamento das responsabilidades, buscando também a escalabilidade do projeto e atender os princípios de SOLID.


2. Classes: uma parcela das classes implementadas são estruturadas para herdarem de uma classe genérica e depois implementarem as suas especificidades na classe respectiva, visando evitar repetição de código e facilitar eventuais manutenções.


3. Banco de dados e Entidades do Banco - Na implementação da migration não realizei o relacinamento entre as tabelas, buscando me aproximar do modelo adotado atualmente pela automatiza onde não são utilizadas "foreign keys" para relacionamento mas sim as próprias chaves primárias.

    Utilizei também como tipo para chaves primárias o "GUID" e não o "INT" buscando um padrão mais aproximado do que é implementado em API's.


4. Migrations - Decidi já popular a migration com produtos e marcas afim de facilitar os testes e não haver a necessidade inputs prévidos por parde dos avaliadores.


5. Camada crud.API - No diretório "crud.API/Configuration/ApiConf" exitem métodos de extensão para a "program.cs". Isto foi feito para que o arquivo de inicialização do programa esteja limpo e de fácil leitura, trazendo apenas o que é necessário e implementando estas configurações.


6. Camada crud.BLL - Realizei a separação das interfaces em Services e Repositorys. Isso foi feito para distinguir os métodos que apenas realizam consultas no banco e os métodos que de fato realizam alterações. Esta separação é um princípio organizacional que facilita a manutenção do código.


7. Camada crud.DAL - Todas as classes de consulta e interação com o banco foram mantidas nesta camada para garantir o desacoplamento.
 
 
 
 
 
### 🛠️ Pacotes (NuGet) Utilizados no projeto

* Camada de API:

    1. EntityFrameworkCore (8.0.2)
        - ORM - Mapeia objetos relacionais
    2. AutoMapper (13.0.1)
        - Serve como um conversor de entidades
    3. NewtonSoft.Json (13.0.3)
        - Biblioteca para trabalhar com arquivos .JSON
    4. Pomelo.EntityFramworkCore.MySQL (8.0.0)
        - Biblioteca do Entity para implementar bancos MySQL
    5. SwashBuckler.AspNetCore (6.4.0)
        - Swagger - Maneira padronizada de representar API's

* Camada de BLL(Regras de Negócios):
     
    1. FluentValidation (11.9.0)
        - Validação de Entidades

* Camada de DAL(Acesso à Dados):

    1. EntityFrameworkCore (8.0.2)
        - ORM - Mapeia objetos Relacionais


* comando utilizado via CLI para inclusão dos pacotes:
    ```
        dotnet add package
    ```

[documentação](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)





### ✒️ Referências para criação do projeto

1. Curso realizado em 2023 do [Desenvolvedor.IO](https://desenvolvedor.io/)
2. Curso realizado em 2022/2023 do [Balta.IO](https://balta.io/)
3. [Documentação Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
4. Repositórios do meu GitHub





---
Desenvolvido por [Lucas Lacerda](https://github.com/LucasLacerda95) 😊
