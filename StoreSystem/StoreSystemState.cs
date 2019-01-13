using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    public class StoreSystemState
    {
        public bool IsRunning { get; private set; } = true;

        // 内部の
        public void ExitSystem()
        {
            this.IsRunning = false;
        }

    }
}
