using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using memory.Entities;

namespace memory.ClassMaps
{
    public class DifficultyMap : ClassMapping<Difficulty>
    {
        public DifficultyMap()
        {
            Id(x => x.id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.UInt32);
            });
            Property(x => x.note, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(x => x.totTime, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Property(x => x.flipTime, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Table("difficulties");

        }
    }
}