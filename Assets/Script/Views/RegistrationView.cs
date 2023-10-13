using Assets.Script.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationView : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button continueButton;
    [SerializeField] private PlayerData playerData;

    public event Action ContinueButtonClicked;
    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnContinueButtonClick()
    {
        if (!string.IsNullOrWhiteSpace(nameInputField.text))
        {
            playerData.SetPlayerName(nameInputField.text);
            Destroy(gameObject);
            ContinueButtonClicked?.Invoke();
        }
    }
}