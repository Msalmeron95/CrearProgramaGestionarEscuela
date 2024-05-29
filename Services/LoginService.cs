using System.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Services
{
    public class LoginService
    {
        public LoginService()
        {
            Director.InitializeDirectores();
            Profesor.PopulateProfesors();
            Estudiante.PopulateEstudiantes();
        }

        public Usuario Autenticar(string email, string password)
        {
            var director = Director.directores.FirstOrDefault(d => d.Email == email && d.Password == password);
            if (director != null)
            {
                return director;
            }

            var profesor = Profesor.profesors.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (profesor != null)
            {
                return profesor;
            }

            var estudiante = Estudiante.estudiantes.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (estudiante != null)
            {
                return estudiante;
            }

            return null;
        }
    }
}