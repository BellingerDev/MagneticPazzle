using UnityEngine;
using System;
using UnityEngine.UI;


public class ConfirmDialog : UIDialogBase
{
	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text descText;

	public static string Title { get; set; }
	public static string Desc { get; set; }
	public static Action<bool> OnClickedCallback;


	public override void Show ()
	{
		titleText.text = Title;
		descText.text = Desc;

		base.Show ();
	}

	public void OnClicked(bool state)
	{
		Hide ();

		if (OnClickedCallback != null)
			OnClickedCallback (state);
	}
}

