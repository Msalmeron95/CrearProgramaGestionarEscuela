using Spectre.Console;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    class Data
    {
        private static Dictionary<string, string> contenido;

        public Data()
        {
            contenido = new Dictionary<string, string>();
            DataDictionary();
        }

        public void DataDictionary()
        {
            AgregarElemento("Matemáticas", "La ciencia que se ocupa del estudio de los números, las formas, las estructuras y los cambios.");
            AgregarElemento("Ciencias Sociales", "El estudio de la sociedad y las relaciones sociales, que incluye disciplinas como la sociología, la antropología, la economía, la geografía, entre otras.");
            AgregarElemento("Lenguaje", "El conjunto de sistemas y reglas que permiten la comunicación verbal y escrita entre los seres humanos.");
            AgregarElemento("Ciencias Naturales", "El estudio de los fenómenos naturales y las leyes que los rigen, abarcando disciplinas como la biología, la física, la química, entre otras.");
            AgregarElemento("Historia", "La disciplina que estudia los acontecimientos del pasado de la humanidad y su evolución a lo largo del tiempo.");
            AgregarElemento("Literatura", "El estudio de textos escritos y obras literarias, así como la comprensión de su contexto cultural y su impacto en la sociedad.");
            AgregarElemento("Educación Física", "El área de la educación que se enfoca en el desarrollo físico, motor y saludable de los individuos a través del ejercicio y la actividad física.");
            AgregarElemento("Artes", "La expresión creativa de ideas, emociones y experiencias a través de diversas formas como la música, la pintura, la escultura, el teatro, entre otras.");
            AgregarElemento("Informática", "El estudio de la computación y la tecnología de la información, que incluye la programación, la informática, la ingeniería de software, entre otros aspectos.");
        }


        public void AgregarElemento(string clave, string valor)
        {
            contenido[clave] = valor;
        }

        public string BuscarDefinicion(string palabra)
        {
            if (contenido.ContainsKey(palabra))
            {
                return contenido[palabra];
            }
            else
            {
                return "La palabra o materia no se encuentra en el diccionario.";
            }
        }


        public static void VercontenidoClases()
        {
            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.AddColumn("Asignatura/Materia");
            table.AddColumn("Contenido");

            foreach (var item in contenido)
            {
                table.AddRow(item.Key, item.Value);
            }

            AnsiConsole.Write(table);
        }


        public static void AgregarActulizarContenido()
        {
            var materias = new List<string>(contenido.Keys);
            var selectedMateria = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione una materia:")
                    .PageSize(10)
                    .MoreChoicesText("[more choices]")
                    .AddChoices(materias)
            );

            if (contenido.ContainsKey(selectedMateria))
            {
                var newContent = AnsiConsole.Ask<string>("Ingrese el nuevo contenido para " + selectedMateria + ": ");
                contenido[selectedMateria] = newContent;
                Console.WriteLine("El contenido de " + selectedMateria + " ha sido actualizado.");
            }
            else
            {
                var newContent = AnsiConsole.Ask<string>("Ingrese el contenido para " + selectedMateria + ": ");
                contenido[selectedMateria] = newContent;
                Console.WriteLine("Se ha agregado nuevo contenido para " + selectedMateria + ".");
            }
        }



    }
}
