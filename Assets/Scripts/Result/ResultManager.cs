using System;
using CoinCollect2.Network;
using CoinCollect2.Player;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Json;
using Unity.Mathematics;

namespace CoinCollect2.Result
{
    public class ResultManager : MonoBehaviour
    {
        [SerializeField]private ResultView _resultView;
        private int score = 0;
        [SerializeField] private GameObject showScoreObject;
        [SerializeField] private GameObject inputUserNameObject;
        [SerializeField] private GameObject showRankingObject;
        [SerializeField] private TMP_InputField userNameInput;

        [SerializeField] private Transform rankingContentParent;
        [SerializeField] private GameObject rankingOnelineObject;
        
        
        public void GotoInputUserName()
        {
            showScoreObject.SetActive(false);
            inputUserNameObject.SetActive(true);
        }

        public async void GotoRanking()
        {
           
            var ranking =await SetScore();
            if (ranking == "out")
            {
                Debug.Log("out!!");
                return;
            }
            inputUserNameObject.SetActive(false);
            showRankingObject.SetActive(true);

            var jsonObject = JsonHelper.FromJson<ScoreData>(ranking);
            for(int i=0;i<jsonObject.Length;i++)
            {
                var scoreData = jsonObject[i];
                // Debug.Log("score"+scoreData.score+" name"+scoreData.userName);
                var oneline=Instantiate(rankingOnelineObject, Vector3.zero, quaternion.identity, rankingContentParent);
                oneline.GetComponent<RankingOneLine>().SetData(i,scoreData.score,scoreData.userName);
            }
         
            
        }

        public async UniTask<string> SetScore()
        {
            var username = userNameInput.text;
            if (username.Length >8)
            {
                Debug.Log("8文字以下にしてください");
                return "out";
            }

            var json =await PostScore(this.score, username);

            return json;


        }
        public async UniTask startResult(CoinCollector coinCollector,ScoreCalucurator scoreCalucurator,string name)
        {
            _resultView.ShowResul(coinCollector,scoreCalucurator);
            this.score = (int)scoreCalucurator.GetScore();
            // await PostScore((int)scoreCalucurator.GetScore(),name);
            showScoreObject.SetActive(true);
        }
        public async UniTask<string> PostScore(int score, string name)
        {
            var scoredata = new ScoreData(name, score);
            var json = ScoreData.Serialize(scoredata);
            var result = await HttpClient.PostMethod("", json);
            return result;
        }
    }

}