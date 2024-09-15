﻿namespace Domain.Result
{
    public sealed record Error(string Code, string? Message = null)
    {
    }
}
