$('form').on('submit', function(e) {
  
  e.preventDefault();

  var formData = {
    email: $("#email").val(),
  }

  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    data: JSON.stringify(formData),
    url: "http://localhost:5284/api/User/forgot-password",
    success: function (result) {
        if (result.response === 'OK') {
            alert("Email de Recuperação  de Senha enviado!");
            console.log(result);
        } else {
            alert("Erro ao Enviar Email de Recuperação: " + result.response);
            console.log(result);
        }
    },
    error: function (xhr, textStatus, errorThrown) {
        console.log(xhr.responseText); // Exibe detalhes do erro no console
        alert("Erro ao enviar requisição: " + errorThrown);
    }
});
});