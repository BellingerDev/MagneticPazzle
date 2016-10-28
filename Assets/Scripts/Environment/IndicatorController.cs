using UnityEngine;
using UnityEngine.UI;


namespace Environment
{
    public class IndicatorController : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToIndicate;

        [SerializeField]
        private string format;

        private TextMesh mesh;
        private Text uiText;
        private IIndicatable indicatable;


        private void SetText(string text)
        {
            if (mesh != null)
                mesh.text = string.Format(format, text);

            if (uiText != null)
                uiText.text = string.Format(format, text);
        }

        private void OnEnable()
        {
            mesh = GetComponent<TextMesh>();
            uiText = GetComponent<Text>();
            indicatable = objectToIndicate.GetComponent(typeof(IIndicatable)) as IIndicatable;
        }

        private void OnDisable()
        {
            mesh = null;
            uiText = null;
            indicatable = null;
        }

        private void Update()
        {
            if (indicatable != null)
                SetText(indicatable.ElementsCount.ToString());
        }
    }
}
