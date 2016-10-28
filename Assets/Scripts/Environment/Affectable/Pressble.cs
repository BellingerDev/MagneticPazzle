using UnityEngine;


public class Pressble : Affectable
{
	[SerializeField]
	private GameObject origin;

	[SerializeField]
	private GameObject fractured;

	private GameObject fracturedInstance;


	public override void Activate ()
	{
		base.Activate ();

		//origin.SetActive (false);
		CreateFractured ();
	}

	public override void Deactivate()
	{
		base.Deactivate ();

		//fractured.SetActive (false);
		fractured = null;

		//origin.SetActive (true);
	}

	private GameObject CreateFractured()
	{
		fracturedInstance = Instantiate<GameObject> (fractured);
        fracturedInstance.transform.position = origin.transform.position + new Vector3(0, 10, 0);

		return fracturedInstance;
	}
}
