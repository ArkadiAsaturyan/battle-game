using Assets.Script.Data;
using Assets.Script.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Controllers
{
    public class ViewsController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private RegistrationView registrationViewPrefab;
        [SerializeField] private SearchOpponentView searchOpponentViewPrefab;
        [SerializeField] private RectTransform canvas;

        private void Start()
        {
            if(string.IsNullOrEmpty(playerData.PlayerName)) 
            {
                ShowRegistrationView();
                return;
            }
            ShowSearchOpponentView();
            
        }

        private void SubscribeEvents()
        {
            
        }

        private void ShowRegistrationView()
        {
            RegistrationView registrationView = Instantiate(registrationViewPrefab, canvas);
            registrationView.ContinueButtonClicked += ShowSearchOpponentView;
        }

        private void ShowSearchOpponentView()
        {
            SearchOpponentView searchOpponentView = Instantiate(searchOpponentViewPrefab, canvas);
        }
    }
}
