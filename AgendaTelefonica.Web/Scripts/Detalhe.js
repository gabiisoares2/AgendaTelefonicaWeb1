function alterarCliente(idCliente) {
    let xhr = new XMLHttpRequest();
    let url = "http://localhost:49805/Home/AlterarClientes/" + idCliente.id;
    xhr.open("GET", url);
    xhr.addEventListener("load", function () {
        if (xhr.status == 200) {
            preencheCampos(JSON.parse(xhr.responseText));
        }
        else {
            console.log(xhr.status);
            console.log(xhr.responseText);
        }
    });
    xhr.send();
}
function preencheCampos(json) {
        document.getElementById("clienteNome").value = json.clienteNome,
        document.getElementById("clienteEmail").value = json.clienteEmail,
        document.getElementById("calendario").value = json.calendario,
        document.getElementById("Celular").value = json.Celular,
        document.getElementById("Casa").value = json.Casa,
        document.getElementById("Trabalho").value = json.Trabalho,
        document.getElementById("IdCel").value = json.idCel,
        document.getElementById("IdCasa").value = json.idCasa,
        document.getElementById("IdTrab").value = json.idTrab
}
function EnviaAtualizacao() {
    if (document.getElementById("clienteNome").value == "") {
        alert("Por favor preencha o nome");
    }
    else if (document.getElementById("clienteEmail").value == "") {
        alert("Por favor preencha o email");
    }
    else if (document.getElementById("calendario").value == "") {
        alert("Por favor preencha o data de nascimento");
    }
    else if (document.getElementById("Celular").value == "" && document.getElementById("Casa").value == "" && document.getElementById("Trabalho")) {
        alert("Por favor preencha pelo menos um telefone para contato");
    }
    else {
        let dados = {
            Id: document.getElementById("Id").value,
            Nome: document.getElementById("clienteNome").value,
            Email: document.getElementById("clienteEmail").value,
            DataNascimento: document.getElementById("calendario").value,
            Celular: document.getElementById("Celular").value,
            Casa: document.getElementById("Casa").value,
            Trabalho: document.getElementById("Trabalho").value,
            IdCel: document.getElementById("IdCel").value,
            IdCasa: document.getElementById("IdCasa").value,
            IdTrab: document.getElementById("IdTrab").value
        }
        let xhr = new XMLHttpRequest();
        let url = "http://localhost:49805/Home/AlterarClientes";
        xhr.open("POST", url, true);
        xhr.addEventListener("load", function () {
            if (xhr.status == 200) {
                var jsonResult = JSON.parse(xhr.responseText);
                if (jsonResult.msgErro == "1") {
                    alert("Dados alterados com sucesso");
                    window.location.reload();
                }
                else {
                    alert("Não foi possível alterar os dados desse cliente.");
                    window.location.reload();
                }
            }
            else {
                console.log(xhr.status);
                console.log(xhr.responseText);
            }
        });
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.send(JSON.stringify(dados));
    }
}
function FechaAtualizacao() {
    window.location.reload()
}
function AcaoDeletar(Id) {
    document.getElementById("IdDeletado").innerHTML = Id.id;
}
function DeletarTelefone() {
    let x = document.getElementById("IdDeletado").innerHTML;
    let xhr = new XMLHttpRequest();
    let url = "http://localhost:49805/Home/DeletarNumero/" + x;
    // abre a requisição
    xhr.open("GET", url);
    // escuta o evento
    xhr.addEventListener("load", function () {
        // testando se a requisição está funcionando.
        if (xhr.status == 200) {
            var jsonResult = JSON.parse(xhr.responseText);
            var msgErro = jsonResult.msgErro;
            if (msgErro == "1") {
                alert("Número deletado com sucesso");
                window.location.reload();
            }
            else {
                alert("Não foi possível deletar esse número.");
                window.location.reload();
            }
        }
        else {
            console.log(xhr.status);
            console.log(xhr.responseText);
        }
    });
    // envia
    xhr.send();
}
function DeletarCliente() {
    let x = document.getElementById("IdDeletado").innerHTML;
    let xhr = new XMLHttpRequest();
    let url = "http://localhost:49805/Home/DeletarCliente/" + x;
    // abre a requisição
    xhr.open("GET", url);
    // escuta o evento
    xhr.addEventListener("load", function () {
        // testando se a requisição está funcionando.
        if (xhr.status == 200) {
            var jsonResult = JSON.parse(xhr.responseText);
            var msgErro = jsonResult.msgErro;
            if (msgErro == "1") {
                alert("Cliente deletado com sucesso");
                window.location.href = "/Home/Index/";
            }
            else {
                alert("Não foi possível deletar esse Cliente.");
                window.location.reload();
            }
        }
        else {
            console.log(xhr.status);
            console.log(xhr.responseText);
        }
    });
    // envia
    xhr.send();
}