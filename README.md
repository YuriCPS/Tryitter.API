# Tryitter.API

# [📌Deploy na Azure](https://tryitterapi-yuricps.azurewebsites.net/swagger/index.html)
### Usuários Cadastrados
| userName | password |
| -------- | -------- |
| admin    | admin123 |
| yuri     | yuri123  |

* Todas as rotas GET são rotas anônimas(públicas), não precisa de autenticação;
* Lembre-se de adicinar "Bearer " antes de colocar o token para autenticar todas as rotas no Swagger. Ex: "Bearer fdsfKrkdf448asdfdsKDSHEdj";
* Fique a vontade pra cadastrar seu usuário.
* Já existem tweets, antes de criar um novo confira as rotas GET para tweets e valide com os já existentes.

---

## 🎯 Objetivos do projeto

Construir uma API em que as pessoas estudantes devem conseguir se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar. Deve ser possível também alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

Uma pessoa estudante deve poder também publicar posts em seu perfil, que poderão conter texto com até 300 caracteres e arquivos de imagem, além de conseguir pesquisar outras contas por nome e optar por listar todos seus posts ou apenas o último.

## 🔧 Funcionalidades

1. Implementar um C.R.U.D. para as contas de pessoas estudantes; ✅
2. Implementar um C.R.U.D. para um post de uma pessoa estudante; ✅
3. Alterar um post depois de publicado. ✅

### 🌟 Extras:
4. Implementar três endpoints referentes à publicação de posts:
    * Inserir um post; ✅
    * Listar todos os seus posts; ✅
    * Listar o último post. ✅

5. Implementar dois endpoints referentes à procura de posts em outras contas:
    * Listar todos os posts de uma conta x; ✅
    * Listar o último post de uma conta x. ✅

## 🚀 Tecnologias

As seguintes ferramentas foram usadas no desenvolvimento do projeto:

- SDK .NET Core 6.0
- Microsoft SQL Server
- Entity Framework Core
- JWToken
- Swagger
- Data Transfer Object (DTO)
- SpecFlow
- xUnit
- FluentAssertions
- Azure

## 📝Requisitos
* Endpoints funcionando; ✅
* Ter rotas autenticadas e rotas anônimas; ✅
* Deploy na Azure; ✅
* 30%, no mínimo, de cobertura de testes; ❌
* Arquivo README bem estruturado; ✅
* Domínio das habilidades em C#; ✅
* Boas práticas de desenvolvimento; ✅

Obs: Não foi possível finalizar os testes a tempo, a idéia era utilizar o SpecFlow com xUnit e FluentAssertions.
