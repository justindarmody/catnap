using Catnap.Maps;
using Catnap.Maps.Impl;
using Catnap.Tests.Core.Models;

namespace Catnap.Tests.Core
{
    public static class Bootstrapper
    {
        public static void ConfigureDomain()
        {
            Domain.Configure(d =>
            {
                d.IdConvention(new IdMappingConvention().Access(Access.Property));
                d.Entity<PersonGuid>(e => {
                    e.Id(x => x.Id).Access(Access.Property).Generator(Generator.GuidComb);
                    e.Property(x => x.FirstName);
                    e.Property(x => x.LastName);
                    e.Property(x => x.Active);
                    e.Property(x => x.MemberSince);
                });
                d.Entity<ForumGuid>( e => {
                    e.Id(x => x.Id).Access(Access.Property).Generator(Generator.GuidComb);
                    e.List(x => x.Posts);
                    e.Property(x => x.Name);
                    e.Property(x => x.TimeOfDayLastUpdated);
                });
                d.Entity<PostGuid>(e => {
                    e.Id(x => x.Id).Access(Access.Property).Generator(Generator.GuidComb);
                    e.Property(x => x.Title);
                    e.Property(x => x.Body);
                    e.Property(x => x.DatePosted);
                    e.BelongsTo(x => x.Poster).ColumnName("PosterId");
                })
                .ParentColumn("ForumId");

                d.Entity<Person>(e => {
                    e.Property(x => x.FirstName);
                    e.Property(x => x.LastName);
                    e.Property(x => x.Active);
                    e.Property(x => x.MemberSince);
                });
                d.Entity<Forum>(e => {
                    e.List(x => x.Posts);
                    e.Property(x => x.Name);
                    e.Property(x => x.TimeOfDayLastUpdated);
                });
                d.Entity<Post>(e => {
                    e.Property(x => x.Title);
                    e.Property(x => x.Body);
                    e.Property(x => x.DatePosted);
                    e.BelongsTo(x => x.Poster).ColumnName("PosterId");
                })
                .ParentColumn("ForumId");
            });
        }
    }
}