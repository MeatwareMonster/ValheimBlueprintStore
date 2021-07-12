using Microsoft.EntityFrameworkCore;

namespace ValheimBlueprintStore.Models
{
    public class ValheimBlueprintStoreContext : DbContext
    {
        public ValheimBlueprintStoreContext(DbContextOptions<ValheimBlueprintStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Blueprint> Blueprints { get; set; }
    }
}