                                                                                                            using System;
using Spectre.Console;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;

namespace SchoolManagementSystem.Views
{
    public class SessionManager
    {
        private readonly LoginService _loginService;

        public SessionManager()
        {
            _loginService = new LoginService();
        }

        public void IniciarPrograma()
        {
            bool salir = false;
            while (!salir)
            {
                AnsiConsole.Clear();
                ShowWelcomeMessage();

                var initialSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción:")
                        .PageSize(10)
                        .AddChoices(new[] {
                            "Iniciar sesión",
                            "Salir"
                        }));

                switch (initialSelection)
                {
                    case "Iniciar sesión":
                        IniciarSesion();
                        break;
                    case "Salir":
                        AnsiConsole.Clear();
                        salir = true;
                        break;
                }
            }
        }

        private void ShowWelcomeMessage()
        {
            var panel = new Panel("[bold]Bienvenido al Sistema de Gestión Escolar de UNIVO[/]")
                .Border(BoxBorder.Rounded)
                .BorderStyle(Style.Parse("blue"))
                .Header("UNIVO School Management System", Justify.Center);

            AnsiConsole.Write(panel);
        }

        private void IniciarSesion()
        {
            AnsiConsole.Clear();
            Console.WriteLine("Por favor ingrese sus credenciales.");

            Console.Write("Email: ");
            string? email = Console.ReadLine();

            Console.Write("Password: ");
            string password = ReadPassword();

            Usuario usuario = _loginService.Autenticar(email, password);

            if (usuario != null)
            {
                AnsiConsole.MarkupLine($"[bold]Bienvenido {usuario.Name} ({usuario.Email})[/]");
                MostrarMenuUsuario(usuario);
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Credenciales incorrectas. Intente de nuevo.[/]");
                Pause();
            }
        }

        private void MostrarMenuUsuario(Usuario usuario)
        {
            bool salir = false;
            while (!salir)
            {
                AnsiConsole.Clear();
                string selection = usuario.VerMenu();
                switch (selection)
                {
                    case "Ver Listado de Profesores":
                        if (usuario is Director director)
                        {
                            AnsiConsole.MarkupLine("[bold yellow]Mostrando listado de profesores...[/]");
                            director.VerListadoProfesores();
                            Pause();
                            GC.Collect();
                        }
                        else if (usuario is Estudiante est)
                        {
                            AnsiConsole.MarkupLine("[bold yellow]Mostrando listado de profesores enseñando activamente...[/]");
                            est.VerListadoProfesoresTeaching();
                            Pause();
                            GC.Collect();
                        }
                        break;
                    case "Ver Listado de Alumnos por Grado":
                        if (usuario is Director dir)
                        {
                            AnsiConsole.MarkupLine("[bold yellow]Mostrando listado de alumnos por grado...[/]");
                            dir.VerListadoEstudiantesPorGrado();
                            Pause();
                            GC.Collect();
                        }
                        else if (usuario is Profesor profesor)
                        {
                            AnsiConsole.MarkupLine("[bold yellow]Mostrando listado de mis alumnos por grado...[/]");
                            //Estudiante.ProfesorNombre();
                            profesor.VerListadoMisAlumnosPorGrado();
                            Pause();
                            GC.Collect();
                        }
                        break;
                    case "Agregar Contenido de Clase":
                        if (usuario is Profesor prof)
                        {
                            AnsiConsole.MarkupLine("[bold yellow]Agregando contenido de clase...[/]");
                            var data = new Data();
                            Data.VercontenidoClases();
                            Console.WriteLine("");
                            Data.AgregarActulizarContenido();
                            Console.WriteLine("");
                            Data.VercontenidoClases();
                            Pause();
                            GC.Collect();
                        }
                        break;
                    case "Ver Contenidos de la Clase":
                        if (usuario is Estudiante estudiante)
                        {
                            AnsiConsole.MarkupLine("[bold yellow]Mostrando contenidos de las clases...[/]");
                            var data = new Data(); 
                            Data.VercontenidoClases(); 
                            Pause();
                            GC.Collect();
                        }
                        break;
                    case "Salir":
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("[bold yellow]Saliendo del menú...[/]");
                        GC.Collect();
                        salir = true;
                        break;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Opción no válida. Intente de nuevo.[/]");
                        Pause();
                        GC.Collect();
                        break;
                }
            }
        }

        private static void Pause()
        {
            Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey(true);
        }

        private static string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}