using UnityEngine;
using Player;
using Player.Properties;
using System;


namespace UI
{
	public class UIUpgradeMenu : UIMenuBase 
	{
		private UIUpgradeButton[] buttons;

		public override void Show ()
		{
			buttons = GetComponentsInChildren<UIUpgradeButton> (true);
			foreach (var button in buttons)
				button.Init ();

			base.Show ();

			LoadButtonsUpgrade ();
		}

		private void LoadButtonsUpgrade()
		{
			Array.FindLast (buttons, b => b.Id == "Magnetic").SetUpgrade(2);
			Array.FindLast (buttons, b => b.Id == "Explode").SetUpgrade(1);
			Array.FindLast (buttons, b => b.Id == "Jump").SetUpgrade(2);
		}

		public void CloseClicked()
		{
			GameManager.Instance.SwitchMechanics<GameMechanicsCollectItems>();
		}

//		private void OnButtonClicked(string propertiesProfile)
//		{
//			PlayerPropertiesBase props = PlayerController.Instance.GetComponent (propertiesProfile) as PlayerPropertiesBase;
//			GameScoreController score = GameManager.Instance.ControllerAt<GameScoreController> ();
//
//			if (props.GetUpgradeCost () > score.GetCount ())
//			{
//				buttons.Single (b => b.PropertiesType == propertiesProfile)
//					.UpdateData (0, 0, Color.black, UIUpgradeButton.UpdateStatus.NotEnoughMoney);
//				return;
//			}
//
//			if (props.CurrentLevel < props.GetMaxLevel())
//			{
//				buttons.Single (b => b.PropertiesType == propertiesProfile)
//					.UpdateData (0, 0, Color.black, UIUpgradeButton.UpdateStatus.MaxLevel);
//				return;
//			}
//
//			ConfirmDialog.Title = propertiesProfile;
//			ConfirmDialog.Desc = propertiesProfile;
//			ConfirmDialog.OnClickedCallback += OnUpgradeClicked;
//
//			UIController.Instance.ShowDialog<ConfirmDialog> ();
//		}
	}
}

