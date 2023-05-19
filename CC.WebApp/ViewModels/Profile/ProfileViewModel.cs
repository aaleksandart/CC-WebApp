using CC.Data.Entities;
using CC.Data.Models;

namespace CC.WebApp.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<RentDataModel> CurrentRentals { get; set; } = new List<RentDataModel>();
        public IEnumerable<RentDataModel> RentHistory { get; set; } = new List<RentDataModel>();
    }
}
