using Xunit;
using SchoolManagementSystem.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Tests
{
    public class DirectorTests
    {
        private Director _director;

        public DirectorTests()
        {
            Director.directores = new List<Director>();
            _director = new Director("Juan Pérez", "juan@example.com", "contraseña1");
        }

        [Fact]
        public void InitializeDirectores_CorrectlyInitializesDirectors()
        {
            Director.InitializeDirectores();
            Assert.Equal(2, Director.directores.Count);
        }

        [Fact]
        public void VerMenu_ReturnsCorrectMenuOptions()
        {
            string result = _director.VerMenu();
            Assert.Contains(result, new List<string> { "Ver Listado de Profesores", "Ver Listado de Alumnos por Grado", "Salir" });
        }
    }
}
