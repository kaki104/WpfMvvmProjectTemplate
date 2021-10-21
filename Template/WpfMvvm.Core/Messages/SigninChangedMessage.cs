using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace $safeprojectname$.Messages
{
    /// <summary>
    /// 사인인 변경 메시지
    /// </summary>
    public class SigninChangedMessage : ValueChangedMessage<Person>
    {
        public SigninChangedMessage(Person value) : base(value)
        {
        }
    }
}
