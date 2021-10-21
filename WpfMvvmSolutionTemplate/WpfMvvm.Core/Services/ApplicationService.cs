using $safeprojectname$.Interfaces;

namespace $safeprojectname$.Services
{
    /// <summary>
    /// ApplicationService
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        public bool IsSignin => SigninUser != null;

        public Person SigninUser { get; private set; }

        public void SetSigninUser(Person user)
        {
            if (user == null) return;
            SigninUser = user;
        }
    }
}
