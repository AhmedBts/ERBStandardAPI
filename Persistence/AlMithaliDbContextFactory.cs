using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    class AlMithaliDbContextFactory : DesignTimeDbContextFactoryBase<HUB_Context>
    {
        protected override HUB_Context CreateNewInstance(DbContextOptions<HUB_Context> options)
        {
            return new HUB_Context(options);
        }
    }
}

