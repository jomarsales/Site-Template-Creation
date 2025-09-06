using System;
using System.Net.Mail;

namespace J3d.Domain.Service
{
    public class MailAssertionConcern
    {
        public static void AssertArgumentValid(string address, string message)
        {
            try
            {
                var m = new MailAddress(address);
            }
            catch (FormatException)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentRegular(string address, string message)
        {
            AssertionConcern.AssertArgumentMatches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", address, message);
        }
    }
}
