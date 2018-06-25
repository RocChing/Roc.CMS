using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roc.CMS.MultiTenancy.HostDashboard.Dto;

namespace Roc.CMS.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}