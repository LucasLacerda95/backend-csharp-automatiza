# CRUD

Implementação de API REST com banco de dados em MySQL voltada para consulta e manipulação de dados, objetivando atender aos requisitos propostos no processo seletivo [Desafio Backend Júnio Automatiza](https://github.com/devfabricioalmeida/backend-csharp-automatiza/blob/main/README.md)

### 📋 Pré-requisitos

* [SDK .NET 8.0](https://dotnet.microsoft.com/en-us/download)
* Obter IDE de sua preferência - [sujestão: Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) 
* Mecanismo de banco de dados [MySQL na versão (5.6.15)}()--
* CLI [Dotnet EF](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install) 


### 🔧 Instalação

Após a instalação dos pré-requisitos será necessário configurar a aplicação para testes:

    # Mecanismo de banco de dados
    
        * Durante a instalação do mecanismo de banco de dados é definida uma senha para o usuário root. Esta senha deverá ser setada no projeto em um arquivo de configuração .JSON, para que a Aplicação e o Entity consigam se conectar com a base de dados local.

            * O aquivo de configuração .JSON está localizado no diretório {Projeto}\src\crud.API\appsettings.json
            ![alt text](\assets\readmeAssets\configBD1.png)
            
            Bastando inserir a senha que foi previamente setada na instalação.

            
            * Acessar o mecanismo de banco de dados e executar as seguinte querys para liberar a permissão acesso ao usuário root:

            ```
            UPDATE mysql.user SET Grant_priv='Y', Super_priv='Y' WHERE User='root';

            FLUSH PRIVILEGES;
            ```  
            A execução destas querys garatirá que o "root" terá a permissão necessária para manipular o Data Base.


    # Entity Framework
    
        *Será necessário instalar a CLI do EntityFramework no seu sistema operacional via CMD. 
        adendo: Executar o cmd com privilégios de administrador

            ```
            dotnet tool install --global dotnet-ef
            ```  
        após aguardar a finalização do download e para garantir que o pacote está instalado você pode executar o seguinte comando:

            ```
            dotnet ef
            ```  
        E em seguida reber o seguinte retorno:
        ![alt text](\assets\readmeAssets\dotnetEF.png)

    #Verificar SDK's instalados via cmd:

            ```
            dotnet --list-sdks
            ```  
        Devertá receber o seguinte retorno:

            ```
            8.0.200 [C:\Program Files\dotnet\sdk]
            8.0.201 [C:\Program Files\dotnet\sdk]
            ``` 
        O minnor[X.X.minnor] da versão não precisa ser específico contanto que o major[8.X.X] esteja 8 e já será sufiente para execução da API.



## ⚙️ Executando do projeto

Após cumprir os pré-requisitos e realizar as configurações podemos iniciar o processo de excução e teste da API: 

# Migration Entity Framework
    
    *Será necessário implementar uma migration que está previamente populada na camada "DAL" do projeto, para isso iremos utilizar o CLI .NET.
    
        * Acesse o CMD ou PowerShell do desenvolvedor na sua IDE, inicialmente iremos nos deslocar via linha de comando para a camada de inicialização da API e somente após estar nesta camada que poderemos iniciar o processo da Migration.

        ```
            cd {projeto}\src\crud.API
        ``` 
        Após estar no diretório iremos fazer o upload da migration que está previamente populada e estruturada para o banco de dados do projeto

        ```
            dotnet ef database update "MigrationPopulada" --project "../crud.DAL"
        ``` 
        [Documentação oficial de consulta](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations)

        Após o procedimento ser executado com êxito receberemos uma informação na CLI e podemos consultar a estrutura implementada no nosso mecanismo de banco de dados.


# Execução de Testes

    * Swaager - Foi implementado no projeto uma funcionalidade do .NET chamada Swaagger que facilita o processo de testes da API. Ele está implementado na paipline do projeto no arquivo "crud.API/Configuration/ApiConf" e pode ser desativado caso haja necessidade.

    * Com o mecanismo de banco de dados ativo, a migration implementada e os Pré-requisitos atendidos já podemos executar testes nos endpoints da aplicação.

    * Clicando no botão de RUN na inteface do Visual Studio o Swaager será chamado automaticamente exibindo os end-points do projeto:
    ![alt text](\assets\readmeAssets\runAPI.png)

    * Segue o exemplo do retorno que será exibido no browser padrão:
    ![alt text](\assets\readmeAssets\swagger.png)


    Agora a aplicação está ponta para receber os testes de validação dos requisitos propostos pelo processo seletivo [DEV Junior Automatiza](https://github.com/devfabricioalmeida/backend-csharp-automatiza/blob/main/README.md)



### 🔩 EndPoints

    # EndPoint da API:

        *Marcas

        ``` html
        POST /api/marcas: cadastrar uma nova marca.
        GET /api/marcas: listar todas as marcas.
        GET /api/marcas/{id}: Retorna os detalhes de uma marca específica pelo id.
        PUT /api/marcas/{id}: Atualiza os dados de uma marca existente.
        DELETE /api/marcas/{id}: SoftRemove de uma marca.
        ```

        *Produtos

        ``` html
        POST /api/produtos: cadastrar um novo produto.
        GET /api/produtos: listar todos os produtos.
        GET /api/produtos/{id}: Retorna os detalhes de um produto específico pelo id.
        PUT /api/produtos/{id}: Atualiza os dados de um produto existente.
        DELETE /api/produtos/{id}: SoftRemove de um produto do sistema.
        ```



## 🖇️ Decisões do Projeto

    * Arquitetura: Separei o projeto em camadas denominadas "crud.API","crud.BLL" e "crud.DAL" visando o desacoplamento das responsabilidades, buscando também a escalabilidade do projeto e atender os princípios de SOLID.
    

    * Classes: uma parcela das classes implementadas são estruturadas para herdarem de uma classe genérica e depois implementarem as suas especificidades na classe respectiva, visando evitar repetição de código e facilitar eventuais manutenções.


    * Banco de dados e Entidades do Banco - Na implementação da migration não realizei o relacinamento entre as tabelas, buscando me aproximar do modelo adotado atualmente pela automatiza onde não são utilizadas "foreign keys" para relacionamento mas sim as próprias chaves primárias.

        Utilizei também como tipo para chaves primária o "GUID" e não o "INT" buscando um padrão mais aproximado do que é implementado em API's.


    * Migrations - Decidi já popular a migration com produtos e marcas afim de facilitar os testes e não haver a necessidade inputs prévidos por parde dos avaliadores.


    * Camada crud.API - No diretório "crud.API/Configuration/ApiConf" exitem métodos de extensão para a "program.cs". Isto foi feito para que o arquivo de inicialização do programa esteja limpo e de fácil leitura, trazendo apenas o que é necessário e implementando esta configuração.


    * Camada crud.BLL - Realizei a separação das interfaces em Services e Repository. Isso foi feito para distinguir os métodos que apenas realizam consultas no banco e os métodos que de fato realizam alterações. Esta separação é um princípio organizacional que facilita a manutenção do código.


    * Camada crud.DAL - Todas as classes de consulta e interação com o banco foram mantidas nesta camada para garantir o desacoplamento.



## 🛠️ Pacotes (NuGet) Utilizados no projeto

Camada de API:

    * EntityFrameworkCore (8.0.2)
    * AutoMapper (13.0.1)
    * NewtonSoft.Json (13.0.3)
    * Pomelo.EntityFramworkCore.MySQL (8.0.0)
    * SwashBuckler.AspNetCore (6.4.0)

Camada de BLL(Regras de Negócios):
     
    * FluentValidation (11.9.0)

Camada de DAL(Acesso à Dados):

    * EntityFrameworkCore (8.0.2)

comando utilizado via CLI para inclusão dos pacotes:
    ```
        dotnet add package
    ```
[documentação](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)



## ✒️ Referências para criação do projeto

    * Curso realizado em 2023 do [Desenvolvedor.IO](https://desenvolvedor.io/)
    * Curso realizado em 2022/2023 do [Balta.IO](https://balta.io/)
    * [Documentação Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
    * Projetos do meu GitHub





---
Desenvolvido por [Lucas Lacerda](https://github.com/LucasLacerda95) 😊