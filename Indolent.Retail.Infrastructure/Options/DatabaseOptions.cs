using System.Text;

namespace Indolent.Retail.Infrastructure.Options;

public class DatabaseOptions
{
    public const string Database = "Database";

    public string UserId { get; set; } = "postgres"; // Default postgres username for the docker image
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = "localhost"; // Host address. Can be both IP and DNS
    public string DatabaseName { get; set; } = "postgres"; // Default database name in the docker image

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append(nameof(UserId)).Append('=').Append(UserId).Append(';');
        builder.Append(nameof(Password)).Append('=').Append("********").Append(';');
        builder.Append(nameof(Host)).Append('=').Append(Host).Append(';');
        builder.Append(nameof(DatabaseName)).Append('=').Append(DatabaseName).Append(';');

        return builder.ToString();
    }
}