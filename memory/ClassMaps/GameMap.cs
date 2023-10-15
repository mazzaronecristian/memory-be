using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using memory.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace memory.ClassMaps
{
    public class GameMap : ClassMapping<Game>
    {
        public GameMap()
        {
            Id(x => x.id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.UInt32);
            });
            Property(x => x.misses, x =>
            {
                x.Type(NHibernateUtil.UInt32);
                x.NotNullable(true);
            });
            Property(x => x.moves, x =>
            {
                x.Type(NHibernateUtil.UInt32);
                x.NotNullable(true);
            });
            ManyToOne(x => x.relatedUser, x =>
            {
                x.Column("user_id");
                x.NotNullable(true);
            });
            ManyToOne(x => x.relatedDifficulty, x =>
            {
                x.Column("difficulty_id");
                x.NotNullable(true);
            });
            Table("games");
        }
    }
}
