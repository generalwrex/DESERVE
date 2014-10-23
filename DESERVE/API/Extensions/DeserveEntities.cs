using DESERVE.ReflectionWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VRageMath;

namespace DESERVE.API
{
	public class DeserveEntities : ReflectionClassWrapper, IMyEntities
	{
		#region Fields
		private const String Class = "";
		#endregion

		#region Events
		#endregion

		#region Properties
		public override String ClassName { get { return ""; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }
		#endregion

		#region Methods
		public DeserveEntities(String Namespace)
			: base(SandboxGameWrapper.Assembly, Namespace, Class)
		{
		}
		#endregion

		#region Interface Implimentation
		public event Action<IMyEntity> OnEntityRemove;

		public event Action OnCloseAll;

		public event Action<IMyEntity, string, string> OnEntityNameSet;

		public bool TryGetEntityById(long id, out IMyEntity entity) { throw new NotImplementedException(); }

		public bool TryGetEntityByName(string name, out IMyEntity entity) { throw new NotImplementedException(); }

		public bool EntityExists(string name) { throw new NotImplementedException(); }

		public void AddEntity(IMyEntity entity, bool insertIntoScene = true) { throw new NotImplementedException(); }

		public IMyEntity CreateFromObjectBuilder(MyObjectBuilder_EntityBase objectBuilder) { throw new NotImplementedException(); }

		public IMyEntity CreateFromObjectBuilderAndAdd(MyObjectBuilder_EntityBase objectBuilder) { throw new NotImplementedException(); }

		public void RemoveEntity(IMyEntity entity) { throw new NotImplementedException(); }

		public bool IsSpherePenetrating(ref BoundingSphere bs) { throw new NotImplementedException(); }

		public Vector3D? FindFreePlace(Vector3D basePos, float radius, int maxTestCount = 20, int testsPerDistance = 5, float stepSize = 1f) { throw new NotImplementedException(); }

		public void GetInflatedPlayerBoundingBox(ref BoundingBox playerBox, float inflation) { throw new NotImplementedException(); }

		public bool IsInsideVoxel(Vector3 pos, Vector3 hintPosition, out Vector3 lastOutsidePos) { throw new NotImplementedException(); }

		public bool IsWorldLimited() { throw new NotImplementedException(); }

		public float WorldHalfExtent() { throw new NotImplementedException(); }

		public float WorldSafeHalfExtent() { throw new NotImplementedException(); }

		public bool IsInsideWorld(Vector3D pos) { throw new NotImplementedException(); }

		public bool IsRaycastBlocked(Vector3 pos, Vector3 target) { throw new NotImplementedException(); }

		public void SetEntityName(IMyEntity IMyEntity, bool possibleRename = true) { throw new NotImplementedException(); }

		public bool IsNameExists(IMyEntity entity, string name) { throw new NotImplementedException(); }

		public void RemoveFromClosedEntities(IMyEntity entity) { throw new NotImplementedException(); }

		public void RemoveName(IMyEntity entity) { throw new NotImplementedException(); }

		public bool Exist(IMyEntity entity) { throw new NotImplementedException(); }

		public void MarkForClose(IMyEntity entity) { throw new NotImplementedException(); }

		public void RegisterForUpdate(IMyEntity entity) { throw new NotImplementedException(); }

		public void RegisterForDraw(IMyEntity entity) { throw new NotImplementedException(); }

		public void UnregisterForUpdate(IMyEntity entity, bool immediate = false) { throw new NotImplementedException(); }

		public void UnregisterForDraw(IMyEntity entity) { throw new NotImplementedException(); }

		public IMyEntity GetIntersectionWithSphere(ref BoundingSphere sphere) { throw new NotImplementedException(); }

		public IMyEntity GetIntersectionWithSphere(ref BoundingSphere sphere, IMyEntity ignoreEntity0, IMyEntity ignoeEntity1) { throw new NotImplementedException(); }

		public IMyEntity GetIntersectionWithSphere(ref BoundingSphere sphere, IMyEntity ignoreEntity0, IMyEntity ignoreEntity1, bool ignoreVoxelMaps, bool volumetricTest, bool excludeEntitiesWithDisabledPhysics = false, bool ignoreFloatingObjects = true, bool ignoreHandWeapons = true) { throw new NotImplementedException(); }

		public IMyEntity GetEntityById(long entityId) { throw new NotImplementedException(); }

		public bool ExistsById(long entityId) { throw new NotImplementedException(); }

		public IMyEntity GetEntityByName(string name) { throw new NotImplementedException(); }

		public void SetTypeSelectable(Type type, bool selectable) { throw new NotImplementedException(); }

		public bool IsTypeSelectable(Type type) { throw new NotImplementedException(); }

		public bool IsSelectable(IMyEntity entity) { throw new NotImplementedException(); }

		public void SetTypeHidden(Type type, bool hidden) { throw new NotImplementedException(); }

		public bool IsTypeHidden(Type type) { throw new NotImplementedException(); }

		public bool IsVisible(IMyEntity entity) { throw new NotImplementedException(); }

		public void UnhideAllTypes() { throw new NotImplementedException(); }

		public void RemapObjectBuilderCollection(IEnumerable<MyObjectBuilder_EntityBase> objectBuilders) { throw new NotImplementedException(); }

		public void RemapObjectBuilder(MyObjectBuilder_EntityBase objectBuilder) { throw new NotImplementedException(); }

		public IMyEntity CreateFromObjectBuilderNoinit(MyObjectBuilder_EntityBase objectBuilder) { throw new NotImplementedException(); }

		public void EnableEntityBoundingBoxDraw(IMyEntity entity, bool enable, Vector4? color = null, float lineWidth = 0.01f, Vector3? inflateAmount = null) { throw new NotImplementedException(); }

		public IMyEntity GetEntity(Func<IMyEntity, bool> match) { throw new NotImplementedException(); }

		public void GetEntities(HashSet<IMyEntity> entities, Func<IMyEntity, bool> collect = null) { throw new NotImplementedException(); }

		public List<IMyEntity> GetIntersectionWithSphere(ref BoundingSphere sphere, IMyEntity ignoreEntity0, IMyEntity ignoreEntity1, bool ignoreVoxelMaps, bool volumetricTest) { throw new NotImplementedException(); }

		public List<IMyEntity> GetEntitiesInAABB(ref BoundingBox boundingBox) { throw new NotImplementedException(); }

		public List<IMyEntity> GetEntitiesInSphere(ref BoundingSphere boundingSphere) { throw new NotImplementedException(); }

		public List<IMyEntity> GetElementsInBox(ref BoundingBox boundingBox) { throw new NotImplementedException(); }
		#endregion
	}
}
