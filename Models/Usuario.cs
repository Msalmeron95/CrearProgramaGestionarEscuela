namespace SchoolManagementSystem.Models
{
    public abstract class Usuario
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Usuario() { }

        public Usuario(string aName, string aEmail, string aPassword)
        {
            Name = aName;
            Email = aEmail;
            Password = aPassword;
        }

        public abstract string VerMenu();
    }
}