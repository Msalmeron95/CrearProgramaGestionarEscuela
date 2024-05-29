using Spectre.Console;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public class Profesor : Usuario
    {
        public bool ProfessorStatus { get; set; }


        public Profesor() : base() { }

        public Profesor(string aName, string aEmail, string aPassword, bool aProfessorStatus)
            : base(aName, aEmail, aPassword)
        {
            ProfessorStatus = aProfessorStatus;
        }

        public static List<Profesor> profesors = new List<Profesor>();
        public static void PopulateProfesors()
        {
            profesors.Add(new Profesor("Maria Lopez", "maria.lopez@example.com", "password456", false));
            profesors.Add(new Profesor("Carlos Martinez", "carlos.martinez@example.com", "password789", true));
            profesors.Add(new Profesor("Ana Torres", "ana.torres@example.com", "password321", false));
            profesors.Add(new Profesor("Lucia Herrera", "lucia.herrera@example.com", "password222", true));
        }

        public override string VerMenu()
        {
            var panel = new Panel("[bold]Profesor[/]")
                .Border(BoxBorder.Double)
                .BorderStyle(Style.Parse("green"))
                .Header("Usuario", Justify.Center);

            AnsiConsole.Write(panel);

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione una opción:")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Ver Listado de Alumnos por Grado",
                        "Agregar Contenido de Clase",
                        "Salir"
                    }));

            return selection;
        }

        public void VerListadoMisAlumnosPorGrado()
        {
            AnsiConsole.MarkupLine("[bold]Listado de Alumnos por Grado:[/]");

            var misEstudiantes = Estudiante.estudiantes.Where(e => e.ProfesorName == this.Name);

            var estudiantesPorGrado = misEstudiantes.GroupBy(e => e.Grado);

            foreach (var grupo in estudiantesPorGrado)
            {
                AnsiConsole.MarkupLine($"Grado {grupo.Key}: {string.Join(", ", grupo.Select(e => e.Name))}");
            }
        }

    }
}