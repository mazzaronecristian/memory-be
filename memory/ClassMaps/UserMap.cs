using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using memory.Entities;

namespace memory.ClassMaps
{
  public class UserMap : ClassMapping<User>
  {
    public UserMap()
    {
      Id(x => x.id, x =>
      {
        x.Generator(Generators.Identity);
        x.Type(NHibernateUtil.UInt32);
      });
      Property(x => x.username, x =>
      {
        x.Length(50);
        x.Type(NHibernateUtil.String);
        x.NotNullable(true);
      });
      Property(x => x.email, x =>
      {
        x.Length(100);
        x.Type(NHibernateUtil.String);
        x.NotNullable(true);
      });
      Property(x => x.password, x =>
      {
        x.Length(4000);
        x.Type(NHibernateUtil.String);
        x.NotNullable(true);
      });
      Table("users");
    }
  }

}