using UnityEngine;


public class LevelData : MonoBehaviour
{
    [SerializeField]
    private Color globalColor;

    [SerializeField]
    private float colorizationTime;

	[SerializeField]
	private Vector3 cameraPreviewPosition;

    [SerializeField]
    private Vector3 startPoint;

    public Vector3 StartPoint
    {
        get
        {
            return startPoint;
        }

        set
        {
            startPoint = value;
        }
    }

    private void Awake()
    {
        ApplyColor();
    }

    public void ApplyColor()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        foreach (var r in renderers)
        {
            LeanTween.color(r.gameObject, globalColor, colorizationTime)
                .setOnUpdateColor(c => r.sharedMaterial.color = c);
        }
    }

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.TransformPoint(cameraPreviewPosition), 0.5f);
	}
}
