using Microsoft.EntityFrameworkCore;
using OMS.Data.Access.Maps;
using OMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Data.Access.Main
{
    public class CategoryMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .ToTable("Category")
                .HasKey(x => x.CategoryId);
        }
    }
}
