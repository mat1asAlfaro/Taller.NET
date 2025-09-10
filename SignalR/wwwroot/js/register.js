// SignalR
const connection = new signalR.HubConnectionBuilder()
  .withUrl("/AuthHub")
  .build();

// Obtener referencias a todos los elementos HTML
const registerButton = document.getElementById("register-button");
const firstNameInput = document.getElementById("first_name");
const lastNameInput = document.getElementById("last_name");
const emailInput = document.getElementById("email");
const passwordInput = document.getElementById("password");
const messageElement = document.getElementById("message");
const togglePassword = document.getElementById("togglePassword");
const loadingSpinner = document.getElementById("loading-spinner");

// Función para mostrar mensajes al usuario
function showMessage(text, type) {
  messageElement.textContent = text;
  messageElement.className = "";
  messageElement.classList.add(type);
  messageElement.classList.remove("hidden");
}

// Event listener para el botón de register
registerButton.addEventListener("click", function (e) {
  e.preventDefault();

  const firstName = firstNameInput.value;
  const lastName = lastNameInput.value;
  const email = emailInput.value;
  const password = passwordInput.value;

  if (!firstName || !lastName || !email || !password) {
    showMessage("Por favor, ingresa todos los datos.", "error");
    return;
  }

  // Deshabilitar el botón y mostrar el spinner
  registerButton.disabled = true;
  loadingSpinner.classList.remove("hidden"); // Mostrar el spinner
  showMessage("Enviando credenciales al servidor...", "info");

  console.info("Sending message to the Hub");
  connection
    .invoke("Register", firstName, lastName, email, password)
    .catch(function (err) {
      console.error(err.toString());
      showMessage("Error al conectar con el servidor.", "error");
      registerButton.disabled = false;
      loadingSpinner.classList.add("hidden"); // Ocultar el spinner
    });
});

// Listener para el mensaje "VerificationOk" del servidor
connection.on("VerificationOk", function (usuario) {
  console.info("Server invoked 'VerificationOk' for user: " + usuario);
  showMessage(
    "¡Verificación exitosa! Redirigiendo en 3 segundos...",
    "success"
  );

  // Ocultar el spinner y habilitar el botón
  registerButton.disabled = false;
  loadingSpinner.classList.add("hidden"); // Ocultar el spinner

  setTimeout(function () {
    window.location.href = "https://localhost:7090/Welcome";
  }, 3000);
});

// Listener para un mensaje de fallo de registro
connection.on("RegistroFallido", function (message) {
  console.info("Register failed: " + message);
  showMessage(message, "error");

  // Ocultar el spinner y habilitar el botón
  registerButton.disabled = false;
  loadingSpinner.classList.add("hidden"); // Ocultar el spinner
});

// Iniciar la conexión de SignalR
connection
  .start()
  .then(function () {
    console.log("Conectado a SignalR.");
    registerButton.disabled = false;
    loadingSpinner.classList.add("hidden"); // Ocultar el spinner al cargar la página
  })
  .catch(function (err) {
    console.error("Error al conectar con SignalR:", err.toString());
    showMessage("Error de conexión. Intente recargar la página.", "error");
    registerButton.disabled = true;
    loadingSpinner.classList.add("hidden"); // Ocultar el spinner si hay un error
  });

// Lógica para alternar la visibilidad de la contraseña
togglePassword.addEventListener("click", function () {
  const type =
    passwordInput.getAttribute("type") === "password" ? "text" : "password";
  passwordInput.setAttribute("type", type);
  this.classList.toggle("fa-eye");
  this.classList.toggle("fa-eye-slash");
});
