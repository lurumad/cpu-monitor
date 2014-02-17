using CpuMonitor.Web.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CpuMonitor.Web.Hubs
{
    [HubName("cpu")]
    public class CpuHub : Hub
    {
        private readonly CpuSupervisor _cpuSupervisor;

        public CpuHub() : this(CpuSupervisor.Instance)
        {
            
        }

        public CpuHub(CpuSupervisor cpuSupervisor)
        {
            _cpuSupervisor = cpuSupervisor;
        }
    }
}