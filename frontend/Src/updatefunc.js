
import { ConversorData, ApagarElementosAlterar } from '../Src/otimizacao.js'

// campos que mostrarão as informações do empregado
let nm = document.getElementById('nomecompleto');
let rg = document.getElementById('rgempregado');
let cpf = document.getElementById('cpfempregado');
let tel = document.getElementById('telempregado');
let cel = document.getElementById('celempregado');
let dt = document.getElementById('dtcontratado');

// eventos da página
let bttn1 = document.getElementById("Confirmar");
let bttn2 = document.getElementById("Voltar");
let select1 = document.getElementById("mudarestado");
let select2 = document.getElementById("mudarcargo");

let optest = document.getElementById("preselecionado");
let optcargo = document.getElementById("preselecionado2");

// quando a página carregar serão mostradas as informações do empregado
window.onload = async () => {

    let Nome = localStorage.getItem('nome');
    let Data = localStorage.getItem('datacontratado');
    let Cpf = localStorage.getItem('cpf');
    let Rg = localStorage.getItem('rg');
    let Tel = localStorage.getItem('telefone');
    let Cel = localStorage.getItem('celular');
    let estado = localStorage.getItem('estadonasc');
    let cg = localStorage.getItem('cargo');

    nm.value = Nome;
    rg.value = Rg;
    cpf.value = Cpf;
    tel.value = Tel;
    cel.value = Cel;
    optcargo.appendChild(document.createTextNode(cg));
    optest.appendChild(document.createTextNode(estado));

    let obj = ConversorData(new Date(Data));
    dt.appendChild(document.createTextNode('Data de Contratação: ' + obj));

    // funcao para chamar os registros de cargos no banco
    let url = "http://localhost:5000/Cargos/buscar-cg";

    const api = await fetch(url,{
        method:'GET',
        mode:'cors'
    });

    let res = api.json();
    res.then(res => {
        modelocargos = res;

        for(let i = 0; i < res.length; i++){
            
            let obj = res[i];

            let opt = document.createElement('option');
            opt.appendChild(document.createTextNode(obj.cargo));

            select2.appendChild(opt);
        }
    })
    
    // funcao para chamar os registros dos estados no banco
    let url2 = "http://localhost:5000/Estados/buscar-est";

    const API = await fetch(url2, {
        method:'GET',
        mode:'cors'
    });

    let mod = API.json();
    mod.then(mod => {
        modeloestados = mod;

        for(let i = 0; i < mod.length; i++){
            
            let obj = mod[i];

            let opt = document.createElement('option');
            opt.appendChild(document.createTextNode(obj.estado));

            select1.appendChild(opt);
        }
    })
}

// essas duas variaveis carregam uma lista de modelos, uma com informacoes dos estados e outras dos cargos
let modelocargos;
let modeloestados;

// esta funcao busca o modelo de um cargo atraves de seu nome
function BuscarJsonCargo(param){

    let modlst = modelocargos;
    let objetocargo;

    for(let i = 0; i < modlst.length; i++){

        let ctx = modlst[i];
        if(ctx.cargo == param)
            objetocargo = ctx;
    }

    return objetocargo;
}

// funcao para buscar um modelo de estado atraves do nome
function BuscarJsonEstado(nmest){

    let lstestados = modeloestados;
    let objestado;

    for(let i = 0; i < lstestados.length; i++){

        let mod = lstestados[i];

        if(mod.estado == nmest)
            objestado = mod;
    }

    return objestado;
}


// este evento realiza a atualizacao de todas as informações do empregado selecionado
bttn1.onclick = async () => {


    let cmp1 = BuscarJsonCargo(select2.value);
    let cmp2 = BuscarJsonEstado(select1.value);

    let Id = localStorage.getItem('id');
    let url = "http://localhost:5000/Funcionario/info-func/" + Id;

    var mod = {
        idest:cmp2.idestado,
        idcg:cmp1.idcargo,    
        nome: nm.value,
        rg: rg.value,
        cpf: cpf.value,
        telefone: tel.value,
        celular: cel.value
    };

    const api = await fetch(url, {
        mode:'cors',
        method: 'PUT',
        headers:{
            'Content-Type':'application/json'
        },
        
        body: JSON.stringify(mod)
    });

    let res = api.json();
    res.then(res => {
        if(res.codigo == 400)
            swal("Ops, Algo deu Errado!", res.motivo, "error");
        else
            swal("Alterações feitas!", "Tudo nos conformes ;)", "success");
    })
}

// evento que apaga os dados do localstorage
bttn2.addEventListener("click", function(){
    ApagarElementosAlterar();
});