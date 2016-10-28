using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private string format;

    private Text textField;
    private float delta;


    private void Awake()
    {
        textField = GetComponent<Text>();
    }

	private void Update ()
    {
        delta += (Time.deltaTime - delta) * 0.1f;
        textField.text = string.Format(format, (int)(1.0f / delta));
    }
}
