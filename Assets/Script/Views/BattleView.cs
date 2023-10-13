using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Views
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI opponentName;
        [SerializeField] private Button attackOpponentButton;
        [SerializeField] private Image healthBar;
        [SerializeField] int opponentHealthMin;
        [SerializeField] int opponentHealthMax;
        [SerializeField] int damageMin;
        [SerializeField] int damageMax;

        public Action<string> OnEndBattle;

        private int _initialOpponentHealth;
        private int _currentOpponentHealth;
        private int _damagePerAttack;

        private void Start()
        {
            _initialOpponentHealth = UnityEngine.Random.Range(opponentHealthMin, opponentHealthMax);
            _currentOpponentHealth = _initialOpponentHealth;
            attackOpponentButton.onClick.AddListener(DamageOpponent);
        }

        private void DamageOpponent()
        {
            _damagePerAttack = UnityEngine.Random.Range(damageMin, damageMax);
            _currentOpponentHealth -= _damagePerAttack;

            float healthBarDamage = (float)_damagePerAttack / _initialOpponentHealth;
            healthBar.fillAmount -= healthBarDamage;      

            if (_currentOpponentHealth <= 0)
            {
                OnEndBattle.Invoke(opponentName.text);
            }
        }

        public void Initialize(string opponentName)
        {
            this.opponentName.text = opponentName;
        }
    }
}