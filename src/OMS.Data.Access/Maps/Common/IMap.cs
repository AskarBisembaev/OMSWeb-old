using Microsoft.EntityFrameworkCore;
using OMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Data.Access.Maps
{
    public interface IMap
    {
        void Visit(ModelBuilder builder);
    }
}
