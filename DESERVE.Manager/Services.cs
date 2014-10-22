using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DESERVE.Manager.ServerMarshalClient;

namespace DESERVE.Manager
{
	internal static class Services
	{
		#region "Fields"
		private static ServerMarshallClient m_marshallClient;
		#endregion

		#region "Properties"
		public static ServerMarshallClient ServerInstance
		{
			get
			{
				if (m_marshallClient == null)
					m_marshallClient = new ServerMarshallClient();

				return m_marshallClient;

			}
		}
		#endregion

		#region "Methods"
		#endregion
	}
}
