namespace Lab8.Model
{
    public class Role
    {
        public int Id { get; set; }
        public Roles MainRole { get; set; }
        public override string ToString()
        {
            return MainRole.ToString();
        }
    }

    public enum Roles
    {
        admin,
        user,
        manager,
        master
    }
}
