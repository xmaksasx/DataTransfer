using HxModel.Models;
using StructHxModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxModel.FdmManager
{
	class RecordFlight
	{
        private readonly FileStream _fs;
        private readonly BinaryWriter _bw;

        public RecordFlight()
        {
            try
            {
                _fs = new FileStream("FlyHxModel.bin", FileMode.Create, FileAccess.Write);
                _bw = new BinaryWriter(_fs);

            }
            catch (Exception ex)
            {
				Console.WriteLine("Файл для записи не был создан!");
            }
        }

        public void RecordData(DataOut dataOut, KinematicsState kinematicsState)
        {
            if (!_fs.CanWrite) return;
      
            _bw.Write(ConvertHelper.ObjectToByte(dataOut));
            _bw.Write(ConvertHelper.ObjectToByte(kinematicsState));
        }


        public void Stop()
        {
            _bw?.Close();
            _fs?.Close();
        }

    }
}
