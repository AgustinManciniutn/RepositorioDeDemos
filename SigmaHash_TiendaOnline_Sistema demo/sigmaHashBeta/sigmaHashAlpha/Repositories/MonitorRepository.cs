﻿using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class MonitorRepository : GenericRepository<GMonitor>, IMonitorRepository
    {
        public MonitorRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
