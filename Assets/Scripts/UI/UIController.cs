using UnityEngine;
using System;


public class UIController : MonoBehaviour
{
	public static UIController Instance { get; private set; }
    
	private UIMenuBase[] menus;
    private UIDialogBase[] dialogs;


	public void Awake() 
	{
		Instance = this;

		menus = GetComponentsInChildren<UIMenuBase> (true);
        foreach (var m in menus)
            m.Hide();

        dialogs = GetComponentsInChildren<UIDialogBase> (true);
        foreach (var d in dialogs)
            d.Hide();
	}

	public void ShowMenu<T>()
    {
        UIMenuBase menu = (UIMenuBase)Array.FindLast(menus, d => d is T);
        if (menu != null)
        {
            menu.Show();
        }
        else
            Debug.Log("Error menu is Missing");
	}

    public void HideMenu<T>()
    {
        UIMenuBase menu = (UIMenuBase)Array.FindLast(menus, d => d is T);
        if (menu != null)
        {
            menu.Hide();
        }
        else
            Debug.Log("Error menu is Missing");
    }

    public void ShowDialog<T>()
    {
        UIDialogBase dialog = (UIDialogBase)Array.FindLast(dialogs, d => d.GetType() == typeof(T));

        foreach (var d in dialogs)
            if (d.Active)
                d.Hide();

        if (dialog != null)
            dialog.Show();
    }
}

