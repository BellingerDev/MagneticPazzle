using UnityEngine;


namespace Utils
{
    public class BackDecorationsGenerator : MonoBehaviour
    {
        [System.Serializable]
        private struct Primitive
        {
            public Vector3 minSize;
            public Vector3 maxSize;
            public Color color;
            public Material material;
        }

        [System.Serializable]
        private struct RandomData
        {
            public float minDistanceBetweenObjects;
            public float maxDistanceBetweenObjects;
        }

        [SerializeField]
        private RandomData randomData;

        [SerializeField]
        private Primitive[] primitives;

        [SerializeField]
        private int elementsCount;

        #region Unity Events

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }

        #endregion

        public void Generate()
        {
            Clear();

            for (int i = 0; i < elementsCount; i++)
            {
                GameObject instance = GeneratePrimitive(primitives[Random.Range(0, primitives.Length - 1)]);

                Vector3 pos = transform.position;
                Vector3 size = transform.localScale;

                instance.transform.position = pos + new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y), Random.Range(-size.z, size.z));
            }
        }

        private GameObject GeneratePrimitive(Primitive p)
        {
            GameObject instance = GameObject.CreatePrimitive(PrimitiveType.Cube);
            instance.GetComponent<Collider>().enabled = false;

            instance.transform.localScale = new Vector3(Random.Range(p.minSize.x, p.maxSize.x), Random.Range(p.minSize.y, p.maxSize.y), Random.Range(p.minSize.z, p.maxSize.z));
            instance.GetComponent<Renderer>().sharedMaterial = p.material;
            instance.GetComponent<Renderer>().sharedMaterial.color = p.color;
            instance.transform.SetParent(this.transform);
            instance.layer = gameObject.layer;
            instance.isStatic = gameObject.isStatic;

            return instance;
        }

        public void Clear()
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>(true);

            for (int i = 0; i < renderers.Length; i++)
            {
                DestroyImmediate(renderers[i].gameObject);
            }
        }
    }

}