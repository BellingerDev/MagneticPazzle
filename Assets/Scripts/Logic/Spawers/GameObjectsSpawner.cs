using UnityEngine;


public class GameObjectsSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject _prototype;
	
	[SerializeField]
	public Vector3 _forceDirection;

	[SerializeField]
	private float _instanceMinSize;

	[SerializeField]
	private float _instanceMaxSize;

	[SerializeField]
	private Transform _instancesParent;

	[SerializeField]
	private float _timeDelay;

	[SerializeField]
	private float _duration;

	private float nextSpawnTime;
	private bool isInit;


	public void Start()
	{
		if (ValidateProperties())
		{
			isInit = true;

			nextSpawnTime = Time.time + _timeDelay;
		}
	}

	public void Update()
	{
		if (isInit)
		{
			if (Time.time < _duration)
			{
				if (Time.time > nextSpawnTime)
				{
					nextSpawnTime = Time.time + _timeDelay;

					GameObject instance = Instantiate(_prototype, transform.position, Quaternion.identity) as GameObject;

					instance.transform.SetParent(_instancesParent != null ? _instancesParent : transform);


					float newSize = Random.Range(_instanceMinSize, _instanceMaxSize);
					instance.transform.localScale = new Vector3(newSize, newSize, newSize);

					if (_forceDirection.magnitude == Vector3.zero.magnitude)
					{
						Rigidbody rb = instance.GetComponent<Rigidbody>();
						if (rb != null)
						{
							rb.AddRelativeTorque(_forceDirection);
							rb.AddRelativeForce(_forceDirection);
							rb.velocity = _forceDirection;
						}
					}
				}
			}
		}
	}

	private bool ValidateProperties()
	{
		if (_prototype == null)
		{
			Debug.Log("Error !!! Prototype is null !!!");
			return false;
		}

		if (_duration <= 0)
		{
			Debug.Log("Error !!! Spawn Duration < 0 or = 0 !!!");
			return false;
		}

		if (_timeDelay < 0)
		{
			Debug.Log("Error !!! Time Delay < 0 !!!");
			return false;
		}

		return true;
	}
}