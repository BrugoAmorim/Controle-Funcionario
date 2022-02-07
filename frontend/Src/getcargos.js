
let corpo = document.getElementById("inseriinfo");

window.onload = async function buscarcargos(){

    let url = "http://localhost:5000/Cargos/buscar-cg";

    const api = await fetch(url, {
        mode:'cors',
        method:'GET'
    })

    let res = api.json();
    res.then(res => {
    
        for(let i = 0; i < res.length; i++){

            let obj = res[i];

            let bloco = document.createElement('div');
            
            let cargo = document.createElement('strong');
            let salario = document.createElement('span');
            let hrentrada = document.createElement('span');
            let hrsaida = document.createElement('span');

            cargo.appendChild(document.createTextNode("Cargo: " + obj.cargo));
            salario.appendChild(document.createTextNode("Salário: " + obj.salario));
            hrentrada.appendChild(document.createTextNode("Horário de Entrada: " + obj.horarioentrada));
            hrsaida.appendChild(document.createTextNode("Horário de Saída: " + obj.horariosaida));

            bloco.appendChild(cargo);
            bloco.appendChild(salario);
            bloco.appendChild(hrentrada);
            bloco.appendChild(hrsaida);

            corpo.appendChild(bloco);
        }
    });
}