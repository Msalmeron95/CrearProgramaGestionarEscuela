using Spectre.Console;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public class Director : Usuario
    {
        public static List<Director> directores = new List<Director>();

        public Director() : base() { }

        public Director(string aName, string aEmail, string aPassword)
            : base(aName, aEmail, aPassword) { }

        public static void InitializeDirectores()
        {
            directores.Add(new Director("Juan Pérez", "juan@example.com", "contraseña1"));
            directores.Add(new Director("María García", "maria@example.com", "contraseña2"));
        }

        public override string VerMenu()
        {
            var panel = new Panel("[bold]Director[/]")
                .Border(BoxBorder.Double)
                .BorderStyle(Style.Parse("green"))
                .Header("Usuario", Justify.Center);

            AnsiConsole.Write(panel);

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione una opción:")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Ver Listado de Profesores",
                        "Ver Listado de Alumnos por Grado",
                        "Salir"
                    }));

            return selection;
        }

        public void VerListadoProfesores()
        {
            var table = new Table();
            table.AddColumn("[bold blue]Nombre[/]");
            table.AddColumn("[bold blue]Estado[/]");

            foreach (var profesor in Profesor.profesors)
            {
                string estado = profesor.ProfessorStatus ? "Activo" : "Inactivo";
                table.AddRow(profesor.Name, estado);
            }

            AnsiConsole.Write(table);
        }

        public void VerListadoEstudiantesPorGrado()
        {
            var table = new Table();

            table.AddColumn(new TableColumn("[bold blue]Nombre[/]").Centered());
            table.AddColumn(new TableColumn("[bold blue]Clase[/]").Centered());

            var estudiantesPorClase = Estudiante.estudiantes.OrderBy(e => e.Grado).ThenBy(e => e.Name);

            foreach (var estudiante in estudiantesPorClase)
            {
                table.AddRow(estudiante.Name, estudiante.Grado);
            }

            AnsiConsole.Write(table);
        }


    }
}
