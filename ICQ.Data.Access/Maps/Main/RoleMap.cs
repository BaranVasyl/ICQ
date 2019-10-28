using System;
using System.Collections.Generic;
using System.Text;
using ICQ.Data.Access.Maps.Common;
using ICQ.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ICQ.Data.Access.Maps.Main
{
    public class RoleMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(x => x.Id);
        }
    }
}
