using Domain.Ports;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Email.Operations
{
    public class FakeEmailService(ILogger<FakeEmailService> logger) : IEmailService
    {
        public void EnviarEmail(Domain.Entities.Email email)
        {
            logger.LogInformation("E-mail Enviado - Rementente: {De} - Destinatario: {Para} - Assunto: {Assunto} - Mensagem: {Mensagem}", email.De, email.Para, email.Assunto, email.Mensagem);
        }
    }
}
