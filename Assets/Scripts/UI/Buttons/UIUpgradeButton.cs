using UnityEngine;


namespace UI
{
	public class UIUpgradeButton : UIButton
	{
		[SerializeField]
		private string id;

		public string Id { get { return id; } }
		public static UIUpgradeButton SelectedButton;


		public void Select()
		{
			if (SelectedButton != null)
				SelectedButton.DeSelect();

			foreach (var trigger in GetTriggers<UISelectionTrigger>())
				trigger.Activate ();

			SelectedButton = this;
		}

		public void DeSelect()
		{
			foreach (var trigger in GetTriggers<UISelectionTrigger>())
				trigger.Deactivate ();
		}

		public void NotEnoughPoints()
		{
			foreach (var trigger in GetTriggers<UISignalizeTrigger>())
				trigger.Activate ();
		}

		public void Upgrade()
		{
			foreach (var trigger in GetTriggers<UISwitchStateTrigger>())
				trigger.Activate ();
		}

		public void SetUpgrade(int lvl)
		{
			foreach (var trigger in GetTriggers<UISwitchStateTrigger>())
				((UISwitchStateTrigger)trigger).SetState (lvl);
		}
	}
}