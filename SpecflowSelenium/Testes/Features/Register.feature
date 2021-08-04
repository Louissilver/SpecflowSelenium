Funcionalidade: Register
	Sendo um usuário do sistema
	Posso acessar a tela de registro
	Para cadastrar um usuário

Cenário: Preencher os campos de registro
	Dado que o usuário preenche os campos do registro com os seguintes valores
		| Campo            | Valor              |
		| First Name       | Luís               |
		| Last Name        | Silveira           |
		| Address          | Rua do teste, 151  |
		| Email address    | teste@teste.com.br |
		| Phone            | 5512345621         |
		| Gender           | Male               |
		| Hobbies          | Movies, Hockey     |
		| Languages        | Portuguese         |
		| Skills           | Software           |
		| Country          | Brazil             |
		| Select Country   | India              |
		| Date Of Birth    | 1999/March/19      |
		| Password         | Lol12345           |
		| Confirm Password | Lol12345           |
	Quando o usuário solicita para enviar o formulário
	Então visualiza a tela de registro com o título "Register"