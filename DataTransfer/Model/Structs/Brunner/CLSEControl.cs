using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Model.Structs.Brunner
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class CLSEControl
    {
        int Mode;          // текущий режим загрузки (см. enum CLSECtrlModes{} )
        double TrimPositionZ;   // заданное нейтральное положение пружинной загрузки по продольному каналу (0-1)
        double TrimPositionX;   // заданное нейтральное положение пружинной загрузки по поперечному каналу (0-1)

       public CLSEControl() {
            Mode = (int)CLSECtrlModes.CLSESTICK_TRIMMED;
            TrimPositionZ = 0.5;
            TrimPositionX = 0.5;
        }
    }

    enum CLSECtrlModes
    {
        CLSESTICK_FREE = 0, // ручка без пружинной загрузки
        CLSESTICK_TRIMMED = 1,  // ручка, мгновенно триммируемая заданной кнопкой по обоим каналам, с пружинной загрузкой относительно триммированного положения
        CLSESTICK_MOVABLE = 2   // ручка с пружинной загрузкой, без тримирования, нейтральное положение пружины задается через интрефейс
    };
}
