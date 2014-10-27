using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.IO;
using System.Windows.Forms;


namespace DESERVE.Manager
{
	public class DESERVEManager
	{
		#region Fields
		private static DESERVEManager m_instance;
		#endregion

		#region Properties
		public static DESERVEManager Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new DESERVEManager();

				return m_instance;
			}
		}
		#endregion

		#region Constructor
		public DESERVEManager()
		{
			m_instance = this;
		}
		#endregion
	}
}
