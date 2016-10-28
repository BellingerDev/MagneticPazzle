using UnityEngine;


namespace UI
{
	public abstract class UITrigger : MonoBehaviour
	{
		public abstract void Init();
		public abstract void DeInit();

		public abstract void Activate();
		public abstract void Deactivate();
	}
}