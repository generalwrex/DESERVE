using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESERVE.API
{
	class APIGateway
	{
		#region Fields
		public static DeserveSession Session;
		public static DeserveEntities Entities;
		public static DeservePlayerCollection Players;
		public static DeserveCubeBuilder CubeBuilder;
		public static DeserveTerminalActionsHelper TerminalActionsHelper;
		public static DeserveUtilities Utilities;
		public static DeserveMultiplayer Multiplayer;
		#endregion

		#region Methods
		public APIGateway()
		{
			/*
			Session = new DeserveSession();
			Entities = new DeserveEntities();
			Players = new DeservePlayerCollection();
			CubeBuilder = new DeserveCubeBuilder();
			TerminalActionsHelper = new DeserveTerminalActionsHelper();
			Utilities = new DeserveUtilities();
			Multiplayer = new DeserveMultiplayer();'
			*/
		}
		#endregion
	}
}
