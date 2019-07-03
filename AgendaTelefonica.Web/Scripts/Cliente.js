function EnviaCadastro() {
    if (document.getElementById("clienteNome").value == "") {
        alert("Por favor preencha o nome");
    }
    else if (document.getElementById("clienteEmail").value == "")
    {
        alert("Por favor preencha o email");
    }
    else if (document.getElementById("calendario").value == "")
    {
        alert("Por favor preencha o data de nascimento");
    }
    else if (document.getElementById("Celular").value == "" && document.getElementById("Casa").value == "" && document.getElementById("Trabalho"))
    {
        alert("Por favor preencha pelo menos um telefone para contato");
    }
    else {
        let dados = {
            Nome: document.getElementById("clienteNome").value,
            Email: document.getElementById("clienteEmail").value,
            DataNascimento: document.getElementById("calendario").value,
            Celular: document.getElementById("Celular").value,
            Casa: document.getElementById("Casa").value,
            Trabalho: document.getElementById("Trabalho").value
        }
        let xhr = new XMLHttpRequest();
        let url = "http://localhost:49805/Home/GravarClientes";
        xhr.open("POST", url, true);
        xhr.addEventListener("load", function () {
            if (xhr.status == 200) {
                var jsonResult = JSON.parse(xhr.responseText);
                var msgErro = jsonResult.msgErro;
                if (msgErro == "1") {
                    alert("Cliente cadastrado com sucesso");
                    window.location.reload();
                }
                else {
                    alert("Não foi possível cadastrar esse Cliente.");
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
function FechaCadastro() {
    window.location.reload()
}
function VerTodos() {
    window.location.href = "/Home/Index";
}