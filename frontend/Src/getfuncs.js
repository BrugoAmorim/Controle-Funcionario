
// importa as funções de criar elementos
import { CriarElementosAlterar, CriarElementosExcluir } from '../Src/otimizacao.js'

let bdy = document.getElementById("informacoes");
let opcao = document.getElementById("selecionado");

window.onload = async function carregarRegistros(){

    let url = "http://localhost:5000/Funcionario/filtrar-func?contratado=";

    // esta linha de codigo é executada assim que carrega a pagina
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

            let btn = document.createElement('button');
            let img = new Image(45,45);
        
            cp1.appendChild(document.createTextNode(obj.nome));
            cp2.appendChild(document.createTextNode("| Na Empresa a " + anos));
            img.alt = ('na');
            img.src = ('../Img/lixeira-semfundo.png');

            info.appendChild(cp1);
            info.appendChild(cp2);
            btn.appendChild(img);
            info.appendChild(btn);
            bdy.appendChild(info);

            if(btn.addEventListener("click", function(){
                CriarElementosExcluir(obj);
            }));

            if(cp1.addEventListener("click", function(){
                CriarElementosAlterar(obj);
            }));
            if(cp2.addEventListener("click", function(){
                CriarElementosAlterar(obj);
            }));
        }
        
    })  

    // se o usuario decidir ordernar os funcionarios, esta linha de codigo será executada
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

                let btn = document.createElement('button');
                let img = new Image(45,45);
            
                cp1.appendChild(document.createTextNode(obj.nome));
                cp2.appendChild(document.createTextNode("| Na Empresa a " + anos));
                img.alt = ('na');
                img.src = ('../Img/lixeira-semfundo.png');

                info.appendChild(cp1);
                info.appendChild(cp2);
                btn.appendChild(img);
                info.appendChild(btn);
                bdy.appendChild(info);
    
                if(btn.addEventListener("click", function(){
                    CriarElementosExcluir(obj);
                }));
    
                if(cp1.addEventListener("click", function(){
                    CriarElementosAlterar(obj);
                }));
                if(cp2.addEventListener("click", function(){
                    CriarElementosAlterar(obj);
                }));
            }
        })      

    });
}
