
// informacoes para inserir o novo empregado
let nmcompleto = document.getElementById("nomefuncionario");
let rgfunc = document.getElementById("rgfuncionario");
let cpfunc = document.getElementById("cpffuncionario");
let tel = document.getElementById("telfuncionario");
let cel = document.getElementById("celfuncionario");

// inputs select
let cargo = document.getElementById("selecionarcargo");
let est = document.getElementById("selecionarestado");

// funcao para buscar os estados e os cargos cadastrados
window.onload = async function buscarEstados(){

    // nesse trecho do codigo ele fará uma busca dos estados do banco
    let url = "http://localhost:5000/Estados/buscar-est";

    const api = await fetch(url,{
        mode:'cors',
        method:'GET'
    });

    let cxt = api.json();
    cxt.then(cxt => {
        for(let i = 0; i < cxt.length; i++){

            let mod = cxt[i];

            let opcao = document.createElement('option');
            opcao.appendChild(document.createTextNode(mod.estado));

            est.appendChild(opcao);
        }
    });

    // ja nesse trecho sera uma consulta de todos os cargos
    let url2 = "http://localhost:5000/Cargos/buscar-cg";

    const chama = await fetch(url2, {
        mode:'cors',
        method:'GET'
    });

    let mod = chama.json();
    mod.then(mod => {
        for(let i = 0; i < mod.length; i++){

            let caixote = mod[i];

            let escolha = document.createElement('option');
            escolha.appendChild(document.createTextNode(caixote.cargo));

            cargo.appendChild(escolha);
        }
    });
}

// botao que realiza o evento de cadastro
let Registrar = document.getElementById("Confirmar");

//funcao para realizar o cadastro do empregado
Registrar.onclick = async function cadastrarFuncionario(){

    let ulrpost = "http://localhost:5000/Funcionario/reg-func";

    let obj = {
        nome: nmcompleto.value,
        rg: rgfunc.value,
        cpf: cpfunc.value,
        cargo: cargo.value,
        estadonasc: est.value,
        telefone: tel.value,
        celular: cel.value
    };

    const api = await fetch(ulrpost, {
        mode:'cors',
        method:'POST',
        headers:{
            'Content-Type': 'application/json'
        },

        body: JSON.stringify(obj)
    });

    let res = api.json();
    res.then(res => {
        if(res.codigo == 400)
            swal("Ops, algo de errado!", res.motivo, "error");
        else
            swal("Registro feito!", "Funcionário cadastrado no sistema.", "success");
    });

}