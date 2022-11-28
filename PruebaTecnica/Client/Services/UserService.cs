using PruebaTecnica.Shared.Data;
using PruebaTecnica.Shared.Models;

namespace PruebaTecnica.Server.Services
{
    public class UserService : IUserService
    {
        private DataContext _Context;
        public UserService(DataContext context)
        {
            _Context = context;
        }

        public bool IsUser(string User, string Pass) =>
                _Context.Usuarios.Where(d => d.User == User && d.Pass == Pass).Count() > 0;

        public Usuario Obtain(string User)
        {
            Usuario usr = new Usuario();
            return _Context.Usuarios.Where(d => d.User == User).FirstOrDefault();
        }
    }
}
