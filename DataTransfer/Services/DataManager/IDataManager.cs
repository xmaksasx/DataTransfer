﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Services.DataManager
{
	interface IDataManager
	{
		void Notify(string header, byte[] dgram);
	}
}
