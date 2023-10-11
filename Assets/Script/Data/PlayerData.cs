using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private string playerName;
        [SerializeField] private int balance;
        public string PlayerName => playerName;
        public int Balance => balance;

        public void ChangeBalance(int amount)
        {
            balance += amount;
        }

        public void SetPlayerName(string name) 
        {
            playerName = name;
        }
    }
}
