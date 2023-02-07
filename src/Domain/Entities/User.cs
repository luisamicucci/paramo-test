using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType Type { get; set; }
        public decimal Money { get; set; }

        public bool IsDuplicated(User user)
        {
            return Name == user.Name || Email == user.Email || Address == user.Address || Phone == user.Phone;
        }
    }
}
