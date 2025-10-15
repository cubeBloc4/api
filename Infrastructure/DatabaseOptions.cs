using System;

namespace Infrastructure;

public class DatabaseOptions
{
    public string? Server { get; set; }
    public string? Port { get; set; }
    public string? Name { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }
    public bool TrustServerCertificate { get; set; } = false;
}
