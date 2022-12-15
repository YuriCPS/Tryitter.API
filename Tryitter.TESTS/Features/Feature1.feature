Funcionalidade: Account controller

@Register
Cenário: Registrar um novo usuário com sucesso
Dado que um novo usuário está se registrando com os seguintes dados
	| userName | password | email          | fistName | lastName | bio         | imageUrl    | moduleId |
	| joaozin  | joao123  | joao@email.com | joao     | silva    | Bio do joao | urldaImagem | 1        |
Então deve retornar o http status code 200

Cenário: Registrar um novo usuário com o email já existente
Dado que um novo usuário está se registrando com os seguintes dados
	| userName   | password | email          | fistName | lastName | bio         | imageUrl    | moduleId |
	| joaozinho  | joao123  | joao@email.com | joao     | silva    | Bio do joao | urldaImagem | 1        |
E que já existe um usuário com o email informado
Então deve retornar o http status code 400

Cenário: Registrar um novo usuário com o userName já existente
Dado que um novo usuário está se registrando com os seguintes dados
	| userName | password | email             | fistName | lastName | bio         | imageUrl    | moduleId |
	| joaozin  | joao123  | joaozin@email.com | joao     | silva    | Bio do joao | urldaImagem | 1        |
E que já existe um usuário com o userName informado
Então deve retornar o http status code 400

@Login
Cenário: Logar com sucesso
Dado que um usuário está logando com os seguintes dados
	| userName | password |
	| joaozin  | joao123  |
Então deve retornar o http status code 200

Cenário: Logar com usuário não existente
Dado que um usuário está logando com os seguintes dados
	| userName | password    |
	| joaoz1m  | joao123  |
E que não existe um usuário com o userName informado
Então deve retornar o http status code 401