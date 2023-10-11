﻿using Assets.Script.Data;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Script.Views
{
    public class SearchOpponentView : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI playerName;
        [SerializeField] private TextMeshProUGUI balance;
        [SerializeField] private TextMeshProUGUI oppponentName;
        [SerializeField] private RawImage opponentAvatar;
        [SerializeField] private Button searchButton;
        [SerializeField] private Button battleButton;
        [SerializeField] private Image loadingScreen;

        private const string URL = "https://randomuser.me/api/";
        private string _imageUrl;
        private Texture2D _texture2D;
        OpponentResponseBody _opponentResponseBody;

        private void Start()
        {
            SearchForOpponent();
            playerName.text = playerData.PlayerName;
            balance.text = playerData.Balance.ToString();
            searchButton.onClick.AddListener(SearchForOpponent);
        }

        private async void SearchForOpponent()
        {
            loadingScreen.gameObject.SetActive(true);

            _opponentResponseBody = await GetOpponentDataAsync(URL);
            if (_opponentResponseBody != null)
            {
                oppponentName.text = _opponentResponseBody.OpponentData[0].Name.FirstName;
                _imageUrl = _opponentResponseBody.OpponentData[0].Picture.LargePictureUrl;
            }

            _texture2D = await DownloadImageAsync(_imageUrl);
            if (_texture2D != null)
            {
                opponentAvatar.texture = _texture2D;
            }

            loadingScreen.gameObject.SetActive(false);
        }

        private async Task<OpponentResponseBody> GetOpponentDataAsync(string url)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }

            if (request.result == UnityWebRequest.Result.Success)
            {
                OpponentResponseBody opponentDataResponse
                    = JsonConvert.DeserializeObject<OpponentResponseBody>(request.downloadHandler.text);

                return opponentDataResponse;                
            }

            Debug.Log("Error while getting opponent data. Error message: " + request.error);            
            return null;
        }

        private async Task<Texture2D> DownloadImageAsync(string imageUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }

            if (request.result == UnityWebRequest.Result.Success)
            {
                return ((DownloadHandlerTexture)request.downloadHandler).texture;
            }

            Debug.Log("Error while downloading image. Error message: " + request.error);            
            return null;
        }
    }
}