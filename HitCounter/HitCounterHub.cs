using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HitCounter
{
    [HubName("hitCounter")]
    public class HitCounterHub : Hub
    {
        //dont want to use stacic var in web code, but you knew that
        static int _hitCount = 0;

        public void RecordHit()
        {
            _hitCount++;

            Clients.All.onRecodHit(_hitCount);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _hitCount--;

            Clients.All.onRecodHit(_hitCount);
            return base.OnDisconnected(stopCalled);
        }

    }
}