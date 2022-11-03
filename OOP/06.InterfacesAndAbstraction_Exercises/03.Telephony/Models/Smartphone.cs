
namespace Telephony.Models
{
    using Contracts;
    public class Smartphone : ISmartPhone, IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }
    }
}
