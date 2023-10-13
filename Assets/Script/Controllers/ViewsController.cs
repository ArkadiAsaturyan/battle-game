using Assets.Script.Data;
using Assets.Script.Views;
using UnityEngine;

namespace Assets.Script.Controllers
{
    public class ViewsController : MonoBehaviour
    {
        [SerializeField] private RectTransform canvas;
        [SerializeField] private RegistrationView registrationViewPrefab;
        [SerializeField] private SearchOpponentView searchOpponentViewPrefab;
        [SerializeField] private BattleView battleViewPrefab;
        [SerializeField] private ResultView resultViewPrefab;

        private GameObject _currentView;

        private void Start()
        {
            if(string.IsNullOrEmpty(PlayerPrefs.GetString(PlayerConsts.PlayerName))) 
            {
                ShowRegistrationView();
                return;
            }
            ShowSearchOpponentView();            
        }

        private void ShowRegistrationView()
        {
            RegistrationView registrationView = Instantiate(registrationViewPrefab, canvas);
            registrationView.ContinueButtonClicked += ShowSearchOpponentView;
            _currentView = registrationView.gameObject;
        }

        private void ShowSearchOpponentView()
        {
            SearchOpponentView searchOpponentView = Instantiate(searchOpponentViewPrefab, canvas);
            searchOpponentView.StartBattleButtonClicked += ShowBattleView;
            if(_currentView != null)
            {
                Destroy(_currentView);
            }
            _currentView = searchOpponentView.gameObject;
        }

        private void ShowBattleView(string opponentName)
        {
            BattleView battleView = Instantiate(battleViewPrefab, canvas);
            battleView.Initialize(opponentName);
            battleView.OnEndBattle += ShowResultView;
            Destroy(_currentView);
            _currentView = battleView.gameObject;
        }

        private void ShowResultView(string opponentName)
        {
            ResultView resultView = Instantiate(resultViewPrefab, canvas);
            resultView.Initialize(opponentName);
            resultView.ContinueButtonClicked += ShowSearchOpponentView;
            Destroy(_currentView);
            _currentView = resultView.gameObject;
        }
    }
}