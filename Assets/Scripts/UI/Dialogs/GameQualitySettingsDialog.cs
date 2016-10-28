using UnityEngine;
using Utils.Decorations;
using Utils;


public class GameQualitySettingsDialog : UIDialogBase
{
	private PoolableDynamicArea[] dynamicAreas;
	private BatchBackDecorationsGenerator[] staticDecorations;

    public void OnTextureChanged(int value)
    {
        switch(value)
        {
            case 1:
                QualitySettings.masterTextureLimit = 0;
                break;

            case 2:
                QualitySettings.masterTextureLimit = 1;
                break;

            case 3:
                QualitySettings.masterTextureLimit = 2;
                break;
        }
    }

    public void OnShadowsChanged(bool enabled)
    {
        if (!enabled)
            QualitySettings.shadowDistance = 0;
        else
            QualitySettings.shadowDistance = 200;
    }

    public void OnHDRChanged(bool enabled)
    {
        GameObject.FindObjectOfType<Camera>().hdr = enabled;
    }

    public void OnRenderModeChanged(int index)
    {
        switch (index)
        {
            case 1:
                GameObject.FindObjectOfType<Camera>().renderingPath = RenderingPath.Forward;
                break;

            case 2:
                GameObject.FindObjectOfType<Camera>().renderingPath = RenderingPath.DeferredShading;
                break;

            case 3:
                GameObject.FindObjectOfType<Camera>().renderingPath = RenderingPath.VertexLit;
                break;
        }
    }

	public void OnStaticDecorationsChanged(bool state)
	{
		if (staticDecorations == null)
			staticDecorations = FindObjectsOfType<BatchBackDecorationsGenerator> ();

		foreach (var d in staticDecorations)
			d.gameObject.SetActive (state);
	}

	public void OnDynamicDecorationsChanged(bool state)
	{
		if (dynamicAreas == null)
			dynamicAreas = FindObjectsOfType<PoolableDynamicArea> ();

		foreach (var d in dynamicAreas)
			d.gameObject.SetActive (state);
	}

    public void OnBackClicked()
    {
        Hide();
    }
}