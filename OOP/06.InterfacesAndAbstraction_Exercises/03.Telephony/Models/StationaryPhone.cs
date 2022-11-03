
namespace Telephony.Models
{
    using Contracts;
    public class StationaryPhone : IStationaryPhone
    {
        
        public string Call(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
