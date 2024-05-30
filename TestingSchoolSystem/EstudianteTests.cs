using Xunit;
using SchoolManagementSystem.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Tests
{
    public class EstudianteTests
    {
        private Estudiante _estudiante;

        public EstudianteTests()
        {
            Estudiante.estudiantes = new List<Estudiante>();
            _estudiante = new Estudiante("Juancho Reyes", "Jreyes@example.com", "password123", "Primero", "Maria Lopez");
        }

        [Fact]
        public void PopulateEstudiantes_CorrectlyPopulatesStudents()
        {
            Estudiante.PopulateEstudiantes();
            Assert.Equal(8, Estudiante.estudiantes.Count);
        }

        [Fact]
        public void VerMenu_ReturnsCorrectMenuOptions()
        {
            string result = _estudiante.VerMenu();
            Assert.Contains(result, new List<string> { "Ver Contenidos de la Clase", "Ver Listado de Profesores", "Salir" });
        }
    }
}
