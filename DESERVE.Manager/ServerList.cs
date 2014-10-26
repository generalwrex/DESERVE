using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESERVE.Manager
{
	public delegate void ChangedEventHandler(object sender, EventArgs e);

	class ServerList // list for servers to handle events...
	{
		public event ChangedEventHandler Changed;

		protected virtual void OnChanged(EventArgs e)
		{
			if (Changed != null)
				Changed(this, e);
		}

	}
}
