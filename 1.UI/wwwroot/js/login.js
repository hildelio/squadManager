$('form').on('submit', function(e) {
  
    e.preventDefault();
  
    var formData = {
      email: $("#email").val(),
      password: $("#password").val()
    }
  
    $.ajax({
      type: "POST",
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      data: JSON.stringify(formData),
      url: "http://localhost:5284/api/User",
      success: function (result) {
        if(result.response == 'OK') {
          alert("Login Successful");
          console.log(result);
        } else {
          alert("Login Failed");
          console.log(result);
        }
      },
      error: function (err) {
        console.log(err);
      }
    });
});