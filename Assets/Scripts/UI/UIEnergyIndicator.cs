using Player;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    public class UIEnergyIndicator : MonoBehaviour
    {
        [SerializeField]
        private float fullLeftPos;

        [SerializeField]
        private float emptyLeftPos;

        [SerializeField]
        private Color fullColor;

        [SerializeField]
        private Color emptyColor;

        [SerializeField]
        private Image progessImage;

        [SerializeField]
        private Text countText;


        private void OnEnable()
        {
            PlayerController.OnEnergyChanged += OnEnergyChanged;
        }

        private void OnDisable()
        {
            PlayerController.OnEnergyChanged -= OnEnergyChanged;
        }

        private void OnEnergyChanged(int current, int max)
        {
            if (current == -1 && max == -1)
            {
                progessImage.color = emptyColor;
                progessImage.color = fullColor;
                progessImage.color = emptyColor;

                return;
            }

            countText.text = string.Format("{0} / {1}", current, max);
            //progessImage.rectTransform.right = ((float)current / (float)max) * (fullLeftPos / emptyLeftPos);

            if (progessImage.fillAmount > 0.7f)
                progessImage.color = fullColor;

            if (progessImage.fillAmount < 0.4f)
                progessImage.color = emptyColor;
        }
    }
}
