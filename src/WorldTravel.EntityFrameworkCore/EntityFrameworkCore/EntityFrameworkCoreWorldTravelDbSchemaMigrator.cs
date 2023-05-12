using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldTravel.Data;
using Volo.Abp.DependencyInjection;

namespace WorldTravel.EntityFrameworkCore
{
    public class EntityFrameworkCoreWorldTravelDbSchemaMigrator
        : IWorldTravelDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreWorldTravelDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the WorldTravelDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<WorldTravelDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
