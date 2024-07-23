# Documentação da API

## Introdução

Bem-vindo à documentação da API do nosso projeto de análise de dados de saúde mental. Esta API foi cuidadosamente projetada para atender às necessidades específicas da Volkswagen, com o principal objetivo de processar e transmitir dados relacionados à saúde mental de forma segura e eficiente para o front-end, permitindo a visualização intuitiva por meio de gráficos interativos. Nossa solução enfatiza a privacidade e a segurança dos dados, incorporando sistemas de autenticação robustos e garantindo que as informações críticas sejam manuseadas com o máximo cuidado.

---

# Guia de Inicialização

Siga os passos abaixo para executar a aplicação .NET em seu ambiente de desenvolvimento.

## Como Rodar a Aplicação

1. **Abrir o Visual Studio**

   ![Abrir o Visual Studio](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/e0d7d571-481f-4e6b-a60d-e0e3f5503112)

2. **Clicar em abrir uma pasta Local e localizar o projeto**

   ![image](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/e63aec53-2bca-45dd-b4c9-f5c8c1ea12c2)

3. **Abrir o Projeto `Parati.Dashboard.WebApi`**
   
   ![image](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/d08acef1-2289-444d-b074-85c1270cadd1)


4. **Clicar para Rodar a aplicação no canto superior esquerdo**

   ![Clicar para Rodar](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/02f248d1-66be-412a-8a45-d139d9cf6596)

5. **Após o build do projeto, clicar no arquivo `Parati.Dashboard.WebApi.sln`**

   ![Abrir arquivo .sln](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/4f9146ae-22fc-40c3-abe8-edc4e9c763b5)

6. **Rodar Http**

   ![Rodar Http](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/76347aea-34ca-4f30-8157-6f9ff9fbf436)

7. **Testar o Método Get para ter um retorno do banco de dados**

   ![Testar Método Get](https://github.com/Inteli-College/2024-T0004-SI09-G03-API/assets/99211976/19bfc651-53f2-4b7d-9354-f53c810c13b4)


## Autenticação e Autorização

## Estrutura de Dados

### Requisições

#### Estrutura de Dados para Requisições GET

##### Formato esperado:
O formato esperado para a resposta é JSON, conforme o padrão para APIs RESTful em ASP.NET Core.

##### Descrição e tipo de dados de cada campo:
- `username`: Tipo `string`. Representa o nome de usuário e é o único campo visível na consulta SQL da rota `api/gptw`.

##### Regras de validação aplicáveis:
As regras específicas para o campo `username` não são mostradas. Regras comuns podem incluir:
- Não vazio: O campo deve ser preenchido.
- Comprimento do string: Pode ser definido um comprimento mínimo e máximo para o campo.
- Padrão específico: O campo pode precisar seguir um padrão específico validado por uma expressão regular.

##### Exemplos de corpo de requisição válidos:
Para requisições GET como a `GetGPTW()`, não há corpo de requisição. Um exemplo de resposta JSON para a rota `api/gptw` pode ser:

```json
{
  "username": "nomeDeUsuarioExemplo"
}
```
Parâmetros de consulta, se aplicáveis, são enviados na URL da requisição, como em api/gptw?id=2.

## Endpoints da API


### /api/gptw

#### Método HTTP
GET

#### Descrição
Este é o endpoint de teste inicial da nossa API, projetado para verificar a comunicação e o funcionamento básico do sistema. Quando acessado, ele retorna o nome de um usuário de teste do banco de dados "tbm".

#### Parâmetros de Entrada
Nenhum. Este endpoint não requer nenhum dado de entrada.

#### Resposta
A resposta será um objeto JSON contendo o nome do usuário de teste. 

```json
{
    "username": "nome_do_usuario"
}
``` 

## Gestão de Erros

### Controlador:
No controlador GPTWController, há um método GetGPTW() que é responsável por lidar com as requisições GET. Este método tenta obter dados chamando o serviço _gptwService.GetGPTW(). Se uma exceção ocorrer durante essa chamada de serviço, ela é capturada pelo bloco catch associado. Dentro desse bloco, retorna um código de status HTTP 500 (Internal Server Error) ao cliente, indicando que algo deu errado no servidor. A mensagem de erro "An error occurred while processing your request. Please try again later." é enviada de volta como parte da resposta, orientando o cliente a tentar novamente mais tarde.

### Serviço:
No nível do serviço, o método GetGPTW() do serviço também tem um bloco try-catch. Se ocorrer uma exceção ao buscar os dados no repositório _gptwRepository.GetGPTWs(), a exceção é capturada. Após o registro, uma ServiceException personalizada é lançada, com uma mensagem indicando que houve um problema ao recuperar os dados de GPTW, juntamente com a exceção original.

### Repositório:
Finalmente, na camada de acesso a dados, o método GetGPTWs() tenta buscar informações de um banco de dados PostgreSQL. Em seguida, a exceção é encapsulada e relançada, com uma mensagem que indica um erro durante a tentativa de buscar os dados de GPTW.

## Monitoramento e Logging

Descreva os mecanismos de monitoramento e logging, incluindo:

- Tipos de logs disponíveis.
- Como acessar e interpretar os logs.
- Métricas de desempenho monitoradas.

## Versionamento

### Formato das Versões

Nossos ambientes são divididos em:
- **Desenvolvimento:** Onde novas funcionalidades e correções são inicialmente implementadas e testadas.
- **Homologação:** Ambiente usado para testes mais rigorosos e simulação do ambiente de produção.
- **Produção:** Onde a versão estável e aprovada da aplicação está disponível para os usuários finais.

### Política para Lançamento de Novas Versões

O processo de lançamento de novas versões segue um fluxo que visa minimizar erros e garantir a qualidade da aplicação:

1. **Desenvolvimento:** Novas funcionalidades e correções são desenvolvidas e testadas inicialmente neste ambiente. Aqui, a ênfase está na implementação e nos testar.
2. **Homologação:** Após uma funcionalidade passar pelos testes iniciais no ambiente de desenvolvimento, ela é movida para o ambiente de homologação. Este ambiente simula o de produção, permitindo testes mais abrangentes e a validação da integração com outros sistemas.
3. **Produção:** Uma vez que a funcionalidade é aprovada em homologação, após um período de tempo em Homologação ela pode ser passada para Produção.

### Instruções para Usar Versões Anteriores

Para acessar versões anteriores da API, os usuários podem referenciar os commits específicos nos repositórios do Git correspondentes aos ambientes de desenvolvimento, homologação ou produção. Isso permite que desenvolvedores revisitem versões anteriores para análises, comparações ou para reverter a funcionalidades específicas caso necessário. A escolha do ambiente de referência (desenvolvimento, homologação ou produção) dependerá do escopo e do objetivo da revisão das versões anteriores.

