using Xunit;
using SchoolManagementSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagementSystem.Tests
{
    public class DataTests
    {
        private Data _data;

        public DataTests()
        {
            _data = new Data();
        }

        [Fact]
        public void AgregarElemento_AgregaElementoCorrectamente()
        {
            _data.AgregarElemento("Test", "Esto es una prueba");

            string resultado = _data.BuscarDefinicion("Test");
            Assert.Equal("Esto es una prueba", resultado);
        }

        [Fact]
        public void BuscarDefinicion_EncuentraDefinicionExistente()
        {
            string resultado = _data.BuscarDefinicion("Matemáticas");

            Assert.Equal("La ciencia que se ocupa del estudio de los números, las formas, las estructuras y los cambios.", resultado);
        }

        [Fact]
        public void BuscarDefinicion_NoEncuentraDefinicionInexistente()
        {
            string resultado = _data.BuscarDefinicion("Química");

            Assert.Equal("La palabra o materia no se encuentra en el diccionario.", resultado);
        }

        [Fact]
        public void AgregarElemento_ActualizaElementoExistente()
        {
            _data.AgregarElemento("Matemáticas", "Definición actualizada");

            string resultado = _data.BuscarDefinicion("Matemáticas");
            Assert.Equal("Definición actualizada", resultado);
        }
    }
}
