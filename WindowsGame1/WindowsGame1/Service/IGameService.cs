using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Service
{
    public interface IGameService
    {
        void registerEntityIfNeeded();
        void unregisterEntity();
    }
}
