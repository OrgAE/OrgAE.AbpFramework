﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace DashboardDemo.EntityFrameworkCore
{
    public class DashboardDemoMigrationsDbContext : AbpDbContext<DashboardDemoMigrationsDbContext>
    {
        public DashboardDemoMigrationsDbContext(DbContextOptions<DashboardDemoMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureTenantManagement();

            /* Configure customizations for entities from the modules included  */

            builder.Entity<IdentityUser>(b =>
            {
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureDashboardDemo method */

            builder.ConfigureDashboardDemo();
        }
    }
}