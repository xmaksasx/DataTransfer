using System.Runtime.InteropServices;

namespace Pue.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CommandPue:Header
    {
        public CommandPue()
        {
            GetHeadDouble("Pue");
        }

       public int sps;
       public int channel;
    }
}
