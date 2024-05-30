using Xunit;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;

namespace SchoolManagementSystem.Tests
{
    public class LoginServiceTests
    {
        private LoginService _loginService;

        public LoginServiceTests()
        {
            _loginService = new LoginService();
        }

        [Fact]
        public void Autenticar_DirectorAutenticacionCorrecta()
        {
            var usuario = _loginService.Autenticar("juan@example.com", "contraseña1");
            Assert.IsType<Director>(usuario);
            Assert.Equal("Juan Pérez", usuario.Name);
        }

        [Fact]
        public void Autenticar_ProfesorAutenticacionCorrecta()
        {
            var usuario = _loginService.Autenticar("carlos.martinez@example.com", "password789");
            Assert.IsType<Profesor>(usuario);
            Assert.Equal("Carlos Martinez", usuario.Name);
        }

        [Fact]
        public void Autenticar_EstudianteAutenticacionCorrecta()
        {
            var usuario = _loginService.Autenticar("Jreyes@example.com", "password123");
            Assert.IsType<Estudiante>(usuario);
            Assert.Equal("Juancho Reyes", usuario.Name);
        }

        [Fact]
        public void Autenticar_UsuarioNoEncontrado()
        {
            var usuario = _loginService.Autenticar("noexiste@example.com", "password");
            Assert.Null(usuario);
        }
    }
}
