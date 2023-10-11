// site.js
function ValidarSubmit(evt) {
    evt.preventDefault();
    const formRegistro = document.getElementById('formRegistro');
    const contraseña = document.getElementById('Contraseña');
    const contraseña2 = document.getElementById('Contraseña2');
    error = false;

    // Verifica que la contraseña contenga al menos un carácter especial
    if (!/[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]/.test(contraseña.value)) {
        error = true;
        alert('La contraseña debe contener al menos un carácter especial.');
    }

    // Verifica que la contraseña contenga al menos una letra en mayúscula
    if (!/[A-Z]/.test(contraseña.value)) {
        error = true;
        alert('La contraseña debe contener al menos una letra en mayúscula.');
    }

    // Verifica que la contraseña tenga al menos 8 caracteres
    if (contraseña.value.length < 8) {
        error = true;
        alert('La contraseña debe tener al menos 8 caracteres.');
    }

    // Verifica que las contraseñas coincidan
    if (contraseña.value !== contraseña2.value) {
        error = true;
        alert('Las contraseñas no coinciden.');
    }

    if (!error) {
        formRegistro.submit();
    }
}

const formRegistro = document.getElementById('formRegistro');
formRegistro.addEventListener('submit', ValidarSubmit);

// Event listener para verificar la contraseña a medida que se escribe
const contraseña = document.getElementById('Contraseña');
contraseña.addEventListener('keyup', function () {
    // Llamar a las funciones que verifican las condiciones a medida que se escribe la contraseña
    VerificoCaracterEspecial(contraseña.value);
    cantCaracteres(contraseña.value);
});