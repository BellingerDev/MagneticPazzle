using System;
using UnityEngine;


public class WaterNoise : MonoBehaviour
{
    [Serializable]
    private struct PrimitiveMeta
    {
        public int scaleX;
        public int scaleY;
        public int scaleZ;

        public Material material;
    }

    [SerializeField]
    private PrimitiveMeta primitive;

    [SerializeField]
    private int xSize;

    [SerializeField]
    private int ySize;

    [SerializeField]
    private int offset;

    [SerializeField]
    private int noiseHeightMul;

    [SerializeField]
    private int noizeScaleMul;

    [SerializeField]
    private float noizeScaleRand;

    [SerializeField]
    private float animScale;

    private GameObject[,] elements;


    public void Create()
    {
        elements = new GameObject[xSize, ySize];

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                elements[i, j] = CreatePrimitive(i * offset, j * offset);
            }
        }

        this.gameObject.name += string.Format("({0} Elements)", elements.Length);
    }
    private void Awake()
    {
        Create();
    }

    public void Update()
    {
        UpdateElements();
    }

    public void UpdateElements()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                Vector3 pos = elements[i, j].transform.localPosition;

                float perlinShift = (noizeScaleMul + UnityEngine.Random.Range(0, noizeScaleRand)) + (Time.time / animScale);
                pos.z = Mathf.PerlinNoise(i + perlinShift, j + perlinShift) * noiseHeightMul;

                elements[i, j].transform.localPosition = pos;
            }
        }
    }

    private GameObject CreatePrimitive(int posX, int posY)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);

        go.transform.SetParent(this.transform);
        go.transform.localPosition = new Vector3(posX * primitive.scaleX, posY * primitive.scaleY, 0);
        go.transform.localScale = new Vector3(primitive.scaleX, primitive.scaleY, primitive.scaleZ);
        go.transform.eulerAngles = transform.eulerAngles;

        go.layer = this.gameObject.layer;

        go.GetComponent<Renderer>().sharedMaterial = primitive.material;
        go.GetComponent<Collider>().enabled = false;

        return go;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                Gizmos.DrawWireCube(transform.position + new Vector3(i * primitive.scaleX, j * primitive.scaleY, 0), new Vector3(primitive.scaleX, primitive.scaleY, primitive.scaleZ));
            }
        }
    }
}
