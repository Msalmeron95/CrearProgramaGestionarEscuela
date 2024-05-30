using Xunit;
using SchoolManagementSystem.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Tests
{
    public class ProfesorTests
    {
        private Profesor _profesor;

        public ProfesorTests()
        {
            Profesor.profesors = new List<Profesor>();
            _profesor = new Profesor("Carlos Martinez", "carlos.martinez@example.com", "password789", true);
        }

        [Fact]
        public void PopulateProfesors_CorrectlyPopulatesProfessors()
        {
            Profesor.PopulateProfesors();
            Assert.Equal(4, Profesor.profesors.Count);
        }

        [Fact]
        public void VerMenu_ReturnsCorrectMenuOptions()
        {
            string result = _profesor.VerMenu();
            Assert.Contains(result, new List<string> { "Ver Listado de Alumnos por Grado", "Agregar Contenido de Clase", "Salir" });
        }
    }
}
