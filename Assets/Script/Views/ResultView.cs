using Assets.Script.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Views
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI battleDescription;
        [SerializeField] private TextMeshProUGUI reward;
        [SerializeField] private Button continueButton;
        [SerializeField] int rewardMin;
        [SerializeField] int rewardMax;

        public Action ContinueButtonClicked;

        private void Start()
        {
            continueButton.onClick.AddListener(() => ContinueButtonClicked.Invoke());
        }

        public void Initialize(string opponentName)
        {
            battleDescription.text = $"Бой с {opponentName}";
            int rewardAmount = UnityEngine.Random.Range(rewardMin, rewardMax);
            reward.text = rewardAmount.ToString();
            int currentBalance = PlayerPrefs.GetInt(PlayerConsts.Balance);
            currentBalance += rewardAmount;
            PlayerPrefs.SetInt(PlayerConsts.Balance, currentBalance);
        }
    }
}