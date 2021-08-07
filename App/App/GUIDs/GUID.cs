
namespace App.GUIDs
{
	public struct GUID
	{
		private static uint _NextID = 0;

		public uint ID { get; private set; }

		public static GUID New_GUID()
		{
			return new(++_NextID);
		}

		public GUID(uint ID)
		{
			this.ID = ID;
		}

		public static uint Get_Count()
		{
			return _NextID;
		}

		public override bool Equals(object obj) 
		{
			if (!(obj is GUID))
				return false;
			
			return ID == ((GUID)obj).ID;
		}

		public override int GetHashCode() => ID.GetHashCode();
	}
}
