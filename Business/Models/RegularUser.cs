namespace Business.Models
{
    public class RegularUser : UserBase
    {
        public override string GetRole()
        {
            return "Regular";
        }
    }
}
