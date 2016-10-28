using UnityEngine;
using Environment;


namespace Game.Activators
{
    public class PoolItemSpawner : MonoBehaviour, IActivatable
    {
        [SerializeField]
		private GameObject prefab;

        [SerializeField]
        private float duration;

        [SerializeField]
		private float frequency;
		
		[SerializeField]
		private bool isActivated = false;

        private float spawnEnd;
        private float nextSpawnTime;

        private void Start()
        {
            spawnEnd = Time.time + duration;
            nextSpawnTime = Time.time + frequency;
        }

        private void FixedUpdate()
        {
			if (!isActivated)
				return;

            if (Time.time < spawnEnd)
            {
                if (Time.time > nextSpawnTime)
                {
                    nextSpawnTime = Time.time + frequency;

					GameObject itemGO = PoolController.Instance.Get(prefab);

                    itemGO.transform.position = this.transform.position;
                    itemGO.SetActive(true);
                }
            }
        }

		public void SetElementsCountFactor(float factor)
		{
			duration *= factor;
		}

		public void SetFrequencyFactor(float factor)
		{
			frequency *= factor;
		}

		#region Activatable

		public void Activate ()
		{
			if (!isActivated)
			{
				isActivated = true;
				
				spawnEnd = Time.time + duration;
				nextSpawnTime = Time.time + frequency;
			}
		}

		public void Deactivate()
		{
            isActivated = false;
		}

		#endregion
    }
}