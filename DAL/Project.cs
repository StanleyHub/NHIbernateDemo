using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace DAL
{
    public class Project
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
//        public virtual List<Member> Members { get; set; } 
    }

    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(o => o.Id).GeneratedBy.Assigned();
            Map(o => o.Name);
        }
    }


    public class Member
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Role { get; set; }
    }

    public class MemberMap: ClassMap<Member>
    {
        public MemberMap()
        {
            Id(o => o.Id).GeneratedBy.Assigned();
            Map(o => o.Name);
            Map(o => o.Role);
        }
    }
}