namespace Business.Models
{
    public class AdminUser : UserBase
    {
        public override string GetRole()
        {
            return "Admin";
        }
    }
}