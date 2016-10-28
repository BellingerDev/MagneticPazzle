

namespace Utils.Events.Data
{
	public class OnCountChangedData
	{
		public string TargetId { get; private set; }
		public int Count { get; set; }

		public OnCountChangedData(string id, int count)
		{
			TargetId = id;
			Count = count;
		}
	}
}