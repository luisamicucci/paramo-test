using Domain.Entities;
using Domain.Enums;

public class UserModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int Type { get; set; }
    public decimal Money { get; set; }

    public static User operator +(User left, UserModel right)
    {
        left.Name = right.Name;
        left.Email = right.Email;
        left.Address = right.Address;
        left.Phone = right.Phone;
        left.Type = (UserType)right.Type;
        left.Money = right.Money;

        return left;
    }
}