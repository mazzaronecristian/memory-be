namespace memory.Entities
{
  public class User
  {
    public virtual uint id { get; set; }
    public virtual string username { get; set; }
    public virtual string email { get; set; }
    public virtual string password { get; set; }
    public virtual string role { get; set; }
  }
}