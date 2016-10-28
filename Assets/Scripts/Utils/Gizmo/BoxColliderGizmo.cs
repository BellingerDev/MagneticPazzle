using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class BoxColliderGizmo : MonoBehaviour 
{
	[SerializeField]
	private Color _color;


	void OnDrawGizmos()
	{
		Gizmos.color = _color;

		var collider = GetComponent<BoxCollider>();
		Gizmos.DrawCube(transform.position + collider.center, collider.size + transform.localScale);
	}

	void OnVisible(bool isVisible)
	{
		if (isVisible)
			_color = new Color(0, 1, 0, 0.5f);
		else
			_color = new Color(1, 0, 0, 0.5f);
	}
}
