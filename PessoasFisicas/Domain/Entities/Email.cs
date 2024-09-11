namespace Domain.Entities
{
    public class Email
    {
        public string De { get; set; } = "remetente@email.com";

        public string Para { get; set; } = "destinatario@email.com";

        public string Assunto { get; set; } = "Confirmação de Email";

        public string Mensagem { get; set; } = "A pessoa foi incluída com sucesso.";
    }
}
