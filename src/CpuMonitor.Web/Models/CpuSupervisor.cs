using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Web;
using CpuMonitor.Web.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CpuMonitor.Web.Models
{
    public class CpuSupervisor
    {
        private readonly IHubConnectionContext _clients;

        private readonly static Lazy<CpuSupervisor> _instance =
            new Lazy<CpuSupervisor>(() => 
                new CpuSupervisor(GlobalHost.ConnectionManager.GetHubContext<CpuHub>().Clients));

        private readonly Timer _timer;

        private readonly PerformanceCounter _performanceCounter;

        private CpuSupervisor(IHubConnectionContext clients)
        {
            _clients = clients;

            _performanceCounter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };

            _timer = new Timer
            {
                Interval = 1000
            };
            _timer.Elapsed += TimerOnElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            BroadCastCpu();
        }

        private void BroadCastCpu()
        {
            var cpuUtilization = Math.Floor(_performanceCounter.NextValue());
            _clients.All.updateCpuUtilization(cpuUtilization);
        }

        public static CpuSupervisor Instance
        {
            get { return _instance.Value; } 
        }
    }
}