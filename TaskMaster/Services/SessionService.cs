using TaskMaster.Models;

namespace TaskMaster.Services
{
    public interface ISessionService
    {
        Utilisateur? CurrentUser { get; }
        void SetCurrentUser(Utilisateur user);
        void ClearSession();
        bool IsAuthenticated { get; }
    }

    public class SessionService : ISessionService
    {
        private Utilisateur? _currentUser;

        public Utilisateur? CurrentUser => _currentUser;
        public bool IsAuthenticated => _currentUser != null;

        public void SetCurrentUser(Utilisateur user)
        {
            _currentUser = user;
        }

        public void ClearSession()
        {
            _currentUser = null;
        }
    }
}