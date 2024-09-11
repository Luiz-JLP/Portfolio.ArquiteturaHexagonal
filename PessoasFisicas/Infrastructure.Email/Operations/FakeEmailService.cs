using Domain.Ports;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Email.Operations
{
    public class FakeEmailService(ILogger<FakeEmailService> logger) : IEmailService
    {
        public void EnviarEmail(Domain.Entities.Email email)
        {
            var mensagem = $"E-mail Enviado - Rementente: {email.De} - Destinatario: {email.Para} - Assunto: {email.Assunto} - Mensagem: {email.Mensagem}";
            logger.LogInformation(mensagem);
        }
    }
}
