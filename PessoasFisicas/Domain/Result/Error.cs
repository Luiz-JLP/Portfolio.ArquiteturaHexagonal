using System.Text.Json;

namespace Domain.Result
{
    public sealed record Error(string Code, string? Message = null)
    {
        public string ToJson()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
        }
    }
}
