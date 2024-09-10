using Domain.Entities;

namespace Domain.Ports
{
    public interface IEmailService
    {
        void EnviarEmail(Email email);
    }
}
