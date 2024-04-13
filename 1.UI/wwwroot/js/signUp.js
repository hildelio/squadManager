$('form').on('submit', function(e) {
  
  e.preventDefault();

  if($("#senha").val().length < 6) {
    alert("A senha deve ter no mínimo 6 caracteres!");
    return;
  }

  if ($("#senha").val() !== $("#confirma-senha").val()) {
    alert("As senhas não conferem!");
    return;
  }

  var formData = {
    username: $("#username").val(),
    email: $("#email").val(),
    password: $("#senha").val(),
    confirmPassword: $("#confirma-senha").val()
  }

  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    data: JSON.stringify(formData),
    url: "http://localhost:5284/api/User/create",
    success: function (result) {
        if (result.response === 'OK') {
            alert("Usuário Cadastrado com Sucesso!");
            console.log(result);
        } else {
            alert("Erro ao criar usuário: " + result.response);
            console.log(result);
        }
    },
    error: function (xhr, textStatus, errorThrown) {
        console.log(xhr.responseText); // Exibe detalhes do erro no console
        alert("Erro ao enviar requisição: " + errorThrown);
    }
});
});