
/* Este Arquivo tem como objetivo otimizar algumas tarefas, como criar 
uma funcionalidade que instancie automaticamente o localstorage, ou 
um conversor de data */

export function ConversorData(data){
    
    let number = "";

    if(data.getMonth() == 0) // Janeiro
        number = "01"
    
    else if(data.getMonth() == 1) // Fevereiro
        number = "02"
    
    else if(data.getMonth() == 2) // Março
        number = "03"
    
    else if(data.getMonth() == 3) // Abril
        number = "04"
    
    else if(data.getMonth() == 4) // Maio
        number = "05"
    
    else if(data.getMonth() == 5) // Junho
        number = "06"
    
    else if(data.getMonth() == 6) // Julho
        number = "07"
    
    else if(data.getMonth() == 7) // Agosto
        number = "08"
    
    else if(data.getMonth() == 8) // Setembro
        number = "09"
    
    else if(data.getMonth() == 9) // Outubro
        number = "10"
    
    else if(data.getMonth() == 10) // Novembro
        number = "11"
    
    else if(data.getMonth() == 11) // Dezembro
        number = "12"


    let obj = data.getDate() + "/" + number + "/" + data.getFullYear();
    return obj;
}

// função que cria dados temporarios para a tela de del-func
export function CriarElementosExcluir(obj){
                
    localStorage.setItem('id', obj.idfunc);
    localStorage.setItem('nome', obj.nome);
    localStorage.setItem('rg', obj.rg);
    localStorage.setItem('cpf',obj.cpf);
    localStorage.setItem('cargo', obj.cargo);
    localStorage.setItem('estado', obj.estadonasc);
    localStorage.setItem('telefone', obj.telefone);
    localStorage.setItem('celular', obj.celular);

    window.location.href = "../DelFunc/deletefunc.html";
}

// função para apagar dados temporarios da tela del-func
export function ApagarElementosExlcuir(){
    
    localStorage.removeItem('id');
    localStorage.removeItem('nome');
    localStorage.removeItem('rg');
    localStorage.removeItem('cpf');
    localStorage.removeItem('cargo');
    localStorage.removeItem('estado');
    localStorage.removeItem('telefone');
    localStorage.removeItem('celular');

    window.location.href = "../Home/registrosfunc.html";
}

//  função que cria dados temporarios para a tela update-func
export function CriarElementosAlterar(obj){
      
    localStorage.setItem('id', obj.idfunc);
    localStorage.setItem('nome', obj.nome);
    localStorage.setItem('rg', obj.rg);
    localStorage.setItem('cpf',obj.cpf);
    localStorage.setItem('cargo', obj.cargo);
    localStorage.setItem('estadonasc', obj.estadonasc);
    localStorage.setItem('telefone', obj.telefone);
    localStorage.setItem('celular', obj.celular);
    localStorage.setItem('datacontratado', obj.datacontratado);

    window.location.href = "../UpFunc/editfunc.html";
}

// função para apagar dados temporarios da tela update-func
export function ApagarElementosAlterar(){

    localStorage.removeItem('idest');
    localStorage.removeItem('idcg');
    localStorage.removeItem('id');
    localStorage.removeItem('nome');
    localStorage.removeItem('rg');
    localStorage.removeItem('cpf');
    localStorage.removeItem('cargo');
    localStorage.removeItem('estado');
    localStorage.removeItem('telefone');
    localStorage.removeItem('celular');
    localStorage.removeItem('datacontratado');

    window.location.href = "../Home/registrosfunc.html";
}