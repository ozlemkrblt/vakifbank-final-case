using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class UserRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public int RoleId { get; set; }

}

public class UserResponse
{

    public int Id { get; set; } 
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public string RoleName { get; set; }

    public virtual List<Address> Addresses { get; set; }
}