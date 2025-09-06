using System;

namespace J3d.Domain.Service
{
    public class UrlAssertionConcern
    {
        public static void AssertArgumentValid(string address, string message)
        {
            if (!Uri.IsWellFormedUriString(address, UriKind.RelativeOrAbsolute))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentRegular(string address, string message)
        {
            AssertionConcern.AssertArgumentMatches(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$", address, "Informe um E-mail válido!");
        }
    }
}
