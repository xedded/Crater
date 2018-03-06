using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Crater.Models.Entities
{
    public partial class CraterContext : DbContext
    {

        public CraterContext(DbContextOptions<CraterContext> options) : base(options)
        {
        }
        
    }
}
