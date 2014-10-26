using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DESERVE.Manager
{
	public class ServerList<T> : ObservableCollection<T> where T: INotifyPropertyChanged
	{

		public ServerList()
		{
			this.CollectionChanged += ServerList_CollectionChanged;
		}

		public ServerList(IEnumerable<T> collection)
			:base(collection)
		{
			this.CollectionChanged += ServerList_CollectionChanged;
			foreach (INotifyPropertyChanged item in collection)
				item.PropertyChanged += item_PropertyChanged;
		}

		private void ServerList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e != null)
			{
				if (e.OldItems != null)
					foreach (INotifyPropertyChanged item in e.OldItems)
						item.PropertyChanged -= item_PropertyChanged;

				if (e.NewItems != null)
					foreach (INotifyPropertyChanged item in e.NewItems)
						item.PropertyChanged += item_PropertyChanged;
			}
		}

		private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var reset = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
			this.OnCollectionChanged(reset);
		}
	}
}
