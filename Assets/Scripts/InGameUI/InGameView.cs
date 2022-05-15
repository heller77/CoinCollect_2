using TMPro;
using UnityEngine;

namespace CoinCollect2.InGameUI
{
    public class InGameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gameTimeText;
        [SerializeField] private TextMeshProUGUI goldCoinNumText;
        [SerializeField] private TextMeshProUGUI silverCoinNumText;
        [SerializeField] private TextMeshProUGUI copperCoinNumText;
        [SerializeField] private TextMeshProUGUI magnificationText;

        public void UpdateMagnification(int magnification)
        {
            magnificationText.text = "*"+magnification.ToString();
        }
        public void UpdateScore(float score)
        {
            scoreText.text = "Score : " + score;
        }

        public void UpdateGameTime(float time)
        {
            gameTimeText.text = "Time " + time.ToString("F");
        }

        public void UpdateGoldCoinText(int goldCoinNum)
        {
            goldCoinNumText.text = goldCoinNum.ToString();
        }

        public void UpdateSilverText(int silverCoinNum)
        {
            silverCoinNumText.text = silverCoinNum.ToString();
        }

        public void UpdateCopperText(int copperCoinNum)
        {
            copperCoinNumText.text = copperCoinNum.ToString();
        }
        
        
    }
}