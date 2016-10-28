using UnityEngine;


public class RigidbodyCacher : MonoBehaviour
{
    public float cacheTime = 10;


    private float timer;

    public static bool Ready { get; private set; }

    void Awake()
    {
        Ready = false;
        timer = Time.time + cacheTime;
    }

    void Update()
    {
        if (Time.time < timer && !Ready)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Rigidbody>();
            }
        }
        else
            Ready = true;

    }
}