
let bdy = document.getElementById("informacoes");
let opcao = document.getElementById("selecionado");

window.onload = async function carregarRegistros(){

    let url = "http://localhost:5000/Funcionario/filtrar-func?contratado=";

    const api = await fetch(url, {

        method:'GET',
        mode:'cors'
    });

    let res = api.json();
    res.then(res => {
        for(let i = 0; i < res.length; i++){

            let obj = res[i];
            let dtcontratacao = new Date(obj.datacontratado);

            let dt = new Date();
            let anos = dt.getFullYear() - dtcontratacao.getFullYear();

            if(dtcontratacao.getMonth() > dt.getMonth())
                    anos = anos - 1 + " ano(s)"

            else if(dtcontratacao.getMonth() >= dt.getMonth() && dtcontratacao.getDate() > dt.getDate() && anos != 0)
                anos = anos + " ano(s)";

            else
                anos = "menos de 1 ano"
                
            let info = document.createElement('tr');
            let cp1 = document.createElement('td');
            let cp2 = document.createElement('td');
        
            cp1.appendChild(document.createTextNode(obj.nome));
            cp2.appendChild(document.createTextNode("Na Empresa a " + anos));

            info.appendChild(cp1);
            info.appendChild(cp2);
            bdy.appendChild(info);
        }
    })  

    if(opcao.onclick = async function(){

        while (bdy.firstChild) {
            bdy.removeChild(bdy.firstChild);
        }

        let url = "http://localhost:5000/Funcionario/filtrar-func?contratado=" + opcao.value;

        const api = await fetch(url, {
    
            method:'GET',
            mode:'cors'
        });
    
        let res = api.json();
        res.then(res => {
            for(let i = 0; i < res.length; i++){
    
                let obj = res[i];
                let dtcontratacao = new Date(obj.datacontratado);

                let dt = new Date();
                let anos = dt.getFullYear() - dtcontratacao.getFullYear();

                if(dtcontratacao.getMonth() > dt.getMonth())
                    anos = anos - 1 + " ano(s)"

                else if(dtcontratacao.getMonth() >= dt.getMonth() && dtcontratacao.getDate() > dt.getDate() && anos != 0)
                    anos = anos + " ano(s)";

                else
                    anos = "menos de 1 ano"
                    
                let info = document.createElement('tr');
                let cp1 = document.createElement('td');
                let cp2 = document.createElement('td');
            
                cp1.appendChild(document.createTextNode(obj.nome));
                cp2.appendChild(document.createTextNode("Na Empresa a " + anos));

                info.appendChild(cp1);
                info.appendChild(cp2);
                bdy.appendChild(info);
            }
        })      

    });
}
