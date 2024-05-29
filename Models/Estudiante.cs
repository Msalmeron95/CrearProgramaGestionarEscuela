using Spectre.Console;
using System.Collections.Generic;
using System.Linq;


namespace SchoolManagementSystem.Models
{
    public class Estudiante : Usuario
    {
        public string ProfesorName { get; set; }
        public string Grado { get; set; }


        public static List<Estudiante> estudiantes = new List<Estudiante>();

        public Estudiante() : base() { }

        public Estudiante(string aName, string aEmail, string aPassword,  string aGrado, string aProfesorName)
            : base(aName, aEmail, aPassword)
        {
            Grado = aGrado;
            ProfesorName = aProfesorName;
        }
        public static void PopulateEstudiantes()
        {
  

            estudiantes.Add(new Estudiante("Juancho Reyes", "Jreyes@example.com", "password123", "Primero", "Maria Lopez"));
            estudiantes.Add(new Estudiante("Ana Torres", "ATorrez@example.com", "password321", "Cuarto", "Carlos Martinez"));
            estudiantes.Add(new Estudiante("Luis Fernandez", "luis.fernandez@example.com", "password654", "Septimo", "Ana Torres"));
            estudiantes.Add(new Estudiante("Elena Ramirez", "elena.ramirez@example.com", "password987", "Primero", "Lucia Herrera"));
            estudiantes.Add(new Estudiante("Pedro Gonzalez", "pedro.gonzalez@example.com", "password111", "Segundo", "Maria Lopez"));
            estudiantes.Add(new Estudiante("Miguel Soto", "miguel.soto@example.com", "password333", "Tercero", "Carlos Martinez"));
            estudiantes.Add(new Estudiante("Sofia Diaz", "sofia.diaz@example.com", "password444", "segundo", "Carlos Martinez"));
            estudiantes.Add(new Estudiante("Jorge Rios", "jorge.rios@example.com", "password555", "Primero", "Carlos Martinez"));

        }

        public override string VerMenu()
        {
            var panel = new Panel("[bold]Estudiante[/]")
                .Border(BoxBorder.Double)
                .BorderStyle(Style.Parse("green"))
                .Header("Usuario", Justify.Center);

            AnsiConsole.Write(panel);

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione una opción:")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Ver Contenidos de la Clase",
                        "Ver Listado de Profesores",
                        "Salir"
                    }));

            return selection;
        }


        public void VerListadoProfesoresTeaching()
        {
            var table = new Table();
            table.AddColumn("[bold blue]Nombre[/]");
            table.AddColumn("[bold blue]Estado[/]");

            foreach (var profesor in Profesor.profesors)
            {
                if (profesor.ProfessorStatus)
                {
                    table.AddRow(profesor.Name, "Activo");
                }
            }

            AnsiConsole.Write(table);
        }

        //Testing to see the content of Profesor
        public static void ProfesorNombre()
        {
            AnsiConsole.MarkupLine("[bold blue]Prueva de profesor[/]");
            foreach (var estudiante in estudiantes)
            {
                AnsiConsole.MarkupLine($"[bold yellow]Nombre del Profesor:[/] {estudiante.ProfesorName}");  
            }
        }



    }
}