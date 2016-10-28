using UnityEngine;
using Player;


namespace Environment
{
	public class SpeedAreaController : MonoBehaviour 
	{
		[SerializeField]
		private string playerTag;

		[SerializeField]
		private Vector3 maxSpeed;

		[SerializeField]
		private string AffectableTypeName;

		[SerializeField]
		private GameObject speedIndicator;

		[SerializeField]
		private Vector3 indicatorOffset;


		private void OnTriggerStay(Collider col)
		{
			if (col.tag == playerTag)
			{
				speedIndicator.SetActive (true);
				Rigidbody rb = col.GetComponent<Rigidbody> ();

				speedIndicator.transform.position = col.transform.position + indicatorOffset;

				if (maxSpeed.x != 0 && rb.velocity.x > maxSpeed.x ||
					maxSpeed.y != 0 && rb.velocity.y > maxSpeed.y ||
					maxSpeed.z != 0 && rb.velocity.z > maxSpeed.z)
				{
					Affectable a = GetComponent(AffectableTypeName) as Affectable;
					if (a == null)
						a = col.transform.parent.GetComponent(AffectableTypeName) as Affectable;

					if (a != null)
						a.Activate();

					if (PlayerController.OnPlayerDied != null)
						PlayerController.OnPlayerDied();
				}
			}
			else
				speedIndicator.SetActive (false);
		}
	}
}
