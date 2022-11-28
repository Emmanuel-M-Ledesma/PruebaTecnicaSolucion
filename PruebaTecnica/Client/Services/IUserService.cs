using PruebaTecnica.Shared.Models;

namespace PruebaTecnica.Server.Services
{
    public interface IUserService
    {
        public bool IsUser(string User, string Pass);

        public Usuario Obtain(string User);
    }
}
