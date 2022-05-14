using TMPro;
using UnityEngine;

namespace CoinCollect2.Result
{
    public class RankingOneLine : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rankText;
        
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI usernameText;

        public void SetData(int rank,int score,string username)
        {
            this.rankText.text = rank.ToString();
            this.scoreText.text = score.ToString();
            this.usernameText.text = username;
        }


    }
}