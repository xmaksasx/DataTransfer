using DataTransfer.Model.Component.BaseComponent;
using System.Runtime.InteropServices;

namespace DataTransfer.Model.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CommandPue : Base
    {
        public CommandPue()
        {
            GetHeadDouble("Pue");
        }

        public int sps;
        public int channel;
    }
}
