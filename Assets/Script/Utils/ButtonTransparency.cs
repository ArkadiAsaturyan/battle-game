using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class ButtonTransparency : MonoBehaviour
    {
        [SerializeField] private Image btnImage;

        private void Start()
        {
            btnImage.alphaHitTestMinimumThreshold = 1;
        }
    }
}