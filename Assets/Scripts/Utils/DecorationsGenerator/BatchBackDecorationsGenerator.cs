using UnityEngine;


namespace Utils
{
    public class BatchBackDecorationsGenerator : MonoBehaviour
    {
        [SerializeField]
        private bool generateOnAwake;


        private void Awake()
        {
            if (generateOnAwake)
                Generate();
        }

        public void Generate()
        {
            BackDecorationsGenerator[] generators = GetComponentsInChildren<BackDecorationsGenerator>(true);

            foreach (var gen in generators)
                gen.Generate();
        }

        public void Clear()
        {
            BackDecorationsGenerator[] generators = GetComponentsInChildren<BackDecorationsGenerator>(true);

            foreach (var gen in generators)
                gen.Clear();
        }
    }
}
