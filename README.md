# Controle-Funcionario
Um projeto que fará CRUD em um banco de dados relacional.

Este projeto tem como objetivo apenas praticar os meus conhecimentos na programação, aprender novos métodos e experimentar coisas novas . Este sistema seria
um gerenciador/controlador de funcionários, o usuário seria capaz de fazer consultas, inserções, alterações ou deletações.

## Home

O usuário quando entrasse no sistema seria levado para essa tela, ela mostraria informações simples, como o nome do funcionário e a
quanto tempo ele está na empresa, nesta mesma tela o usuário poderia fazer um filtro, buscando os funcionários tanto pelos mais antigos
quanto pelos mais novos. Nela também o usuário poderia ir para uma outra página fazer o registro de um novo funcionário ou poderia deletar
os dados de um.

![home-pag1](https://user-images.githubusercontent.com/87936511/154603971-cbf35caf-002c-4489-b74c-2f13663fabf3.png)

## Cadastrar Funcionário

Nesta tela seriam preenchidas informações do funcionário, como seu nome, informações para contato, qual seria o seu cargo na empresa, etc. Aqui seria a tela "principal"
para o gerenciador de funcionários. Ao clicar no botão de registrar, os dados dos campos preenchidos seriam salvos no banco e o novo funcionário estaria registrado na empresa,
haveria também que, o próprio sistema salvaria a data desse registro, para assim saber quando que o registro foi feito e a quanto tempo o funcionário está cadastrado nessa empresa.

![reg-func-pag](https://user-images.githubusercontent.com/87936511/154781378-dd3477e8-2bea-4b86-829b-a8e22b57e415.png)

<strong>Após ter preenchido todos os campos, uma mensagem de confirmação avisaria ao usuário que o registro foi feito.</strong>
 
![suc-reg-func](https://user-images.githubusercontent.com/87936511/154604690-587f6dc2-e1f8-4bc5-879f-d5990cad43e4.png)

## Tratamento de Erro

Se o usuário acabar esquecendo de preencher algum campo, um alerta será emitido ao mesmo, para avisar aonde ele esqueceu de preencher, o sistema não cobra que seja obrigado a 
preencher os campos de "N° Telefone" e "N° Celular", caso o usuário queira adicionar seus números para contato, o mesmo deverá ser feito na tela de editar as informações do empregado.

<strong>Os Motivos Podem Variar.</strong>

![tratamento-erro](https://user-images.githubusercontent.com/87936511/154817338-7e765b26-2ace-4d0d-bc57-95a6e30e4645.png)

## Informações do Empregado

Está tela possui todas as informações de um funcionário cadastrado, caso o usuário quisesse alterar algo, seria feito por aqui. Vale ressaltar que, como falado anteriormente,
o sistema salvaria a data de inserção do registro, quando o usuário fosse ver as informações do empregado está mesma tela teria a data de quando o funcionário foi registrado na empresa(data de contratação).

![info-func-pag](https://user-images.githubusercontent.com/87936511/154781529-a489dfc0-7427-4e9d-bbf0-ee8342074438.png)

<strong> Ao clicar em "Salvar", as informações registradas anteriormente seriam substituidas pelas novas(ou continuariam as mesmas) e um aviso de que as alterações foram feitas seria mostrado.</strong>

![info-slv](https://user-images.githubusercontent.com/87936511/154781777-a774a212-de28-48dc-936c-316734ed4508.png)

## Deletar Registro

Se o usuário quiser, ele pode apagar um registro de um funcionário da empresa(os motivos podem variar). Para fazer isso é bem simples, basta clicar na lixeira que se encontra ao lado de cada nome na tela <strong>Home</strong>, ele será mandando para está tela que você está vendo, ela contêm todas as informações do funcionário e mostra um aviso antes
de confirmar este excluimento.

![del-func](https://user-images.githubusercontent.com/87936511/154781917-056289fe-dc97-4ee6-9963-248cdfb761e3.png)

<strong>Se o usuário tiver certeza do que está fazendo e quiser excluir o registro do empregado, basta aguardar alguns segundos(ou até menos) que um aviso será emitido ao usuário confirmando que os registros foram excluídos.</strong>

![del-slv](https://user-images.githubusercontent.com/87936511/154782222-7f9ba62b-de78-4aec-910f-903669f129e6.png)

## Tela Bônus

Está tela apenas faz uma consulta no banco e retorna as informações dos cargos existentes na empresa, aqui seria apenas uma consulta e se alguêm quissese inserir mais cargos,
seria necessário fazer isso diretamente no banco de dados.

![bonus](https://user-images.githubusercontent.com/87936511/154782369-020dd942-943b-4872-8108-6384351f5343.png)

## Protótipo

Isto é uma visão geral do sistema, o protótipo das telas básicas/essenciais, não teria um login e senha, pois seria um sistema interno da empresa. Como
é um protótipo a versão final pode estar diferente dessa.

![visao-geral](https://user-images.githubusercontent.com/87936511/154603028-833c86d6-1a7e-4453-b73a-f0caeabcb0dd.png)

## MER

Imagem de como foi organizado as tabelas do banco de dados

![banco-dados](https://user-images.githubusercontent.com/87936511/154782506-7b6ca7b1-1b33-4bf9-8fc7-27b071144c23.png)

## Informações Adicionais

- Utilizando C#/.Net Core 5 para backend
- Utilizando linguagem JavaScript para frontend
- Utilizando Html5 e Css3
- Usando Banco de Dados Mysql
- Usando o SweatAlert(https://sweetalert.js.org/guides/)
