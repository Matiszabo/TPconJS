function VerificoCaracterEspecial()
{
    // Verifico que tenga un carater especial: Me fijo que tenga un caracter especial: pongo una lista de caracteres especiales y puedo poner un convert string to varchar y con un for
    // me fijo que tenga uno de los de la lista.

}

function cantCaracteres()
{
    
//cuento con el varchar los lugares, si son menos de 8 hay un error
}


/*funcion para validar el submit del form*/
function ValidarSubmit()
{
    evt.preventDefault();
    alert(1);
}

const formRegistro = document.getElementById('formRegistro');
const contraseña = document.getElementById('Contraseña');

/*esto mne permite ir verificar todos los datos una vez que se hace submit del form*/
formRegistro.addEventListener('submit', function(evt){
    evt.preventDefault();
    error=false;
    /* todas las condiciones que quieras*/
    if (contraseña.value.length<8) 
    {
        contraseña.focus();
        error=true;

    }
    if (error==false)
    {
        formRegistro.submit();
    }
});

/*esto mne permite ir verificando la contraseña a medida que se escribe*/
contraseña.addEventListener('keyup', function(){
   console.log(contraseña.value)
});

