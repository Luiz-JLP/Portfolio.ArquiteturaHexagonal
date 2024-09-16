using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Domain.Result
{
    [ExcludeFromCodeCoverage]
    public sealed record Error(string Code, string? Message = null)
    {
        public string ToJson()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
        }
    }
}
