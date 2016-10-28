//------------------------------------------------------------------------------


namespace Utils.Events.Data
{
	public class OnUpdateCountersData
	{
		public string TargetId { get; private set; }
		public string CountText { get; set; }
		
		public OnUpdateCountersData(string id, string countText)
		{
			TargetId = id;
			CountText = countText;
		}
	}
}