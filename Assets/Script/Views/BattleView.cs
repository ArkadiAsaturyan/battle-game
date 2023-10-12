using Assets.Script.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Views
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI opponentName;
        [SerializeField] private Button attackOpponentButton;
        [SerializeField] private Image healthProgress;

        private void Start()
        {
            
        }

        public void Initialize(string opponentName)
        {
            this.opponentName.text = opponentName;
        }
    }
}
