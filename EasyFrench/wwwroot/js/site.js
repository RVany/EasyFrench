// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    function radioValidation(){

        var answer = document.getElementsByName('answer');
        var ansValue = false;

        for(var i=0; i<answer.length; i++){
            if(answer[i].checked === true){
        ansValue = true;
            }
            }
        if (!ansValue) {
            var msg = '<span style="color:red; font-size:20px;">"Please Choose the Answer!"</span><br /><br />';
            document.getElementById('msg').innerHTML = msg;
           
        return false;
        }

    }
