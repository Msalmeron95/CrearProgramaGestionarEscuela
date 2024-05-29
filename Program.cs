using SchoolManagementSystem.Views;

namespace SchoolManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionManager sessionManager = new SessionManager();
            sessionManager.IniciarPrograma();
            GC.Collect();
        }
    }
}