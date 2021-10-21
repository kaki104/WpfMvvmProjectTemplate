using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
    /// <summary>
    /// IApplicationService
    /// </summary>
    public interface IApplicationService
    {
        bool IsSignin { get; }

        Person SigninUser { get; }

        void SetSigninUser(Person user);
    }
}
