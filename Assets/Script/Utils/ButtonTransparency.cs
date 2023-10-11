using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
