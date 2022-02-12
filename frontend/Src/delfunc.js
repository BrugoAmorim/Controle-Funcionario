
let aviso = document.getElementById('Aviso');

// dados temporarios, serão excluidos assim que o usuario sair desta tela
let id = localStorage.getItem('id');
console.log(id);

let nm = document.getElementById('nm');
let rgfunc = document.getElementById('rg');  
let cpfunc = document.getElementById('cpf');  
let cg = document.getElementById('cg');  
let est = document.getElementById('est'); 
let tel = document.getElementById('tel');  
let cel = document.getElementById('cel'); 

// eventos do sistema
let btn1 = document.getElementById("Confirmar");
let btn2 = document.getElementById("Voltar");

// quando a página carregar o navegador mostrará informações do funcionario
window.onload = () =>{   

    aviso.appendChild(
        document.createTextNode('Voce tem certeza que deseja excluir o(a) ' + localStorage.getItem('nome') + '? Todos os dados serão apagados. A ação é permanente e não será possível recuperar nenhuma informação.'));

    nm.appendChild(document.createTextNode(localStorage.getItem('nome')));
    rgfunc.value = localStorage.getItem('rg');
    cpfunc.value = localStorage.getItem('cpf');
    cg.value = localStorage.getItem('cargo');
    est.value = localStorage.getItem('estado');
    tel.value = localStorage.getItem('telefone');
    cel.value = localStorage.getItem('celular');
    
}

// funcao que realiza o evento de apagar registro
btn1.onclick = async () => {

    let url = "http://localhost:5000/Funcionario/del-func/" + id;

    const api = await fetch(url,{
        mode:'cors',
        method: 'DELETE'
    }); 

    window.location.href = "../../Pages/Home/registrosfunc.html";
}

// funcao que apaga esses dados temporarios
btn2.onclick = () => {

    localStorage.removeItem('id');    
    localStorage.removeItem('nome');
    localStorage.removeItem('rg');
    localStorage.removeItem('cpf');
    localStorage.removeItem('cargo');
    localStorage.removeItem('estado');
    localStorage.removeItem('celular');

    window.location.href = "../../Pages/Home/registrosfunc.html";
}