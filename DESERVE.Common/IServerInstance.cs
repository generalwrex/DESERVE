using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace DESERVE.Common
{
	public interface IServerInstance
	{
		#region Properties
		String Name { get; }
		Boolean IsRunning { get; }
		#endregion
	}

	public delegate void ServerStateEvent();

	[ServiceContract(SessionMode = SessionMode.Required,
	CallbackContract = typeof(IWCFClient))]
	public interface IWCFService
	{
		/// <summary>
		/// Starts the process of stopping the server.
		/// </summary>
		[OperationContract]
		void Stop();

		/// <summary>
		/// Used to make the server save the game.
		/// </summary>
		[OperationContract]
		void Save();

		/// <summary>
		/// Used to request server information from the server.
		/// </summary>
		[OperationContract]
		void RequestUpdate();


	}

	public interface IWCFClient
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="serverInfo"></param>
		[OperationContract(IsOneWay = true)]
		void ServerUpdate(IServerInstance serverInfo);
	}
}
