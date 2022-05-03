using CoinCollect2.Items.Coins;
using CoinCollect2.Player;
using TMPro;
using UnityEngine;

namespace CoinCollect2.Result
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private GameObject ResultCanvas;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject inGameCanvas;
        
        
        private CoinCollector CoinCollector;

        
        public void ShowResul(CoinCollector coinCollector,ScoreCalucurator scoreCalucurator)
        {
            inGameCanvas.SetActive(false);
            ResultCanvas.SetActive(true);
            var score = scoreCalucurator.GetScore();
            scoreText.text = " Score "+score.ToString();
        }

        public void GetCollectCoin()
        {
            var collectCoinDictionary = this.CoinCollector.GetCollectCoinDictionary();
            var gold = collectCoinDictionary[CoinType.Gold];
            var silver = collectCoinDictionary[CoinType.Silver];
            var copper = collectCoinDictionary[CoinType.Copper];
            Debug.Log("gold : "+ gold + " silver : "+ silver + " copper : "+ copper);
        }

        public void SetCoinCollector(CoinCollector coinCollector)
        {
            this.CoinCollector = coinCollector;
        }
    }
}