using UnityEngine;


namespace Utils.Decorations
{
	public class PoolableDynamicArea : MonoBehaviour
	{
		[System.Serializable]
		private class Target
		{
			public Vector3 position;
			public float radius;
		}

		[SerializeField]
		private Target startTarget;

		[SerializeField]
		private Target endTarget;

		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private float spawnFrequency;

		[SerializeField]
		private int minElementsCount;

		[SerializeField]
		private int maxElementsCount;

		[SerializeField]
		private float minDuration;

		[SerializeField]
		private float maxDuration;

		[SerializeField]
		private float minScaleFactor;

		[SerializeField]
		private float maxScaleFactor;

		[SerializeField]
		private LeanTweenType tween;

		private float nextSpawnTime;


		private void Update()
		{
			if (Time.time > nextSpawnTime)
			{
				GenerateWave ();
				nextSpawnTime = Time.time + spawnFrequency;
			}
		}

		private void GenerateWave()
		{
			int count = Random.Range (minElementsCount, maxElementsCount);
			Vector3 position = transform.position;

			for (int i = 0; i < count; i++)
			{
				GameObject instance = PoolController.Instance.Get (prefab);

				Vector3 startPos = transform.TransformPoint(new Vector3(
					startTarget.position.x + Random.Range (-startTarget.radius, startTarget.radius),
					startTarget.position.y + Random.Range (-startTarget.radius, startTarget.radius),
					startTarget.position.z + Random.Range (-startTarget.radius, startTarget.radius)
				));
				
				Vector3 endPos = transform.TransformPoint(new Vector3(
					endTarget.position.x + Random.Range (-endTarget.radius, endTarget.radius),
					endTarget.position.y + Random.Range (-endTarget.radius, endTarget.radius),
					endTarget.position.z + Random.Range (-endTarget.radius, endTarget.radius)
				));

				Vector3 angle = new Vector3 (
					Random.Range (0, 360), 
					Random.Range (0, 360), 
					Random.Range (0, 360)
				);

				Vector3 scale = instance.transform.localScale;

				instance.transform.position = startPos;
				instance.transform.localEulerAngles = angle;
				instance.transform.localScale *= Random.Range (minScaleFactor, maxScaleFactor);

				LeanTween.move (instance, endPos, Random.Range(minDuration, maxDuration))
					.setEase (tween)
					.setOnComplete (() => {
						PoolController.Instance.Retrieve (instance); 
						instance.transform.localScale = scale; 
					});

				instance.SetActive (true);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere (transform.TransformPoint (startTarget.position), startTarget.radius);
			Gizmos.DrawLine (transform.TransformPoint (startTarget.position), transform.TransformPoint (endTarget.position));
			Gizmos.DrawWireSphere (transform.TransformPoint (endTarget.position), endTarget.radius);
		}
	}
}

