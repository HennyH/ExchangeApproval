using System;
using System.Linq;

namespace ExchangeApproval.Data
{
    public static class DatabaseUrlHelpers
    {
        public static (string Scheme, string ConnectionString) ParseDatabaseUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri)) {
                throw new ArgumentException($"Invalid DATABASE_URL: {url}");
            }
            var host = uri.Host;
            var username = uri.UserInfo.Split(":").First();
            var password = uri.UserInfo.Split(":").Last();
            var port = uri.Port;
            var db = uri.LocalPath.TrimStart('/');
            var scheme = uri.Scheme;
            if (scheme == "mysql") {
                return (scheme, $"Server={host};Database={db};User={username};Password={password}");
            }
            throw new ArgumentOutOfRangeException($"Unkown scheme type {scheme}");
        }
    }
}