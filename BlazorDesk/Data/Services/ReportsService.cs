using BlazorDesk.AppModels.Management.View;
using System.Collections.Generic;
using System.Linq;

namespace BlazorDesk.Data.Services
{
    public class ReportsService
    {
        private BlazorDeskDbContext context;

        public ReportsService(BlazorDeskDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ReportViewModel> GetMyRequestsData(string userId)
        {
            var requests = this.context.Requests.Where(r => r.RequesterId == userId).GroupBy(r => r.Status.Name).Select(g => new ReportViewModel
            {
                DimensionOne = g.Key,
                Quantity = g.Count()
            });

            return requests;

        }
    }
}
