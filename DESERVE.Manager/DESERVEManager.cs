using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.IO;
using System.Windows.Forms;
using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{
	public class DESERVEManager
	{

		private static DESERVEManager m_instance;

		public static DESERVEManager Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new DESERVEManager();

				return m_instance;
			}
		}
		
		public DESERVEManager()
		{
			m_instance = this;
		}
	}
}
