using DataTransfer.Model.Component.BaseComponent;
using System.Runtime.InteropServices;


namespace DataTransfer.Model.Structs.Pue
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CommandPue : Base
    {

        double Channel;
    }
}
