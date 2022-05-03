using CoinCollect2.Items.Coins;

namespace CoinCollect2.Result
{
    public class ScoreCalucurator
    {
        private float _score;
        private float _goldScore=10;
        private float _silverScore=5;
        private float _copperScore=1;
        public void addScoreByCoin(Coin coin)
        {
            var coinType = coin.GetCoinType();
            switch (coinType)
            {
                case CoinType.Gold:
                    _score += _goldScore;
                    break;
                    
                case CoinType.Silver:
                    _score += _silverScore;
                    break;
                case CoinType.Copper:
                    _score += _copperScore;
                    break;
            }
        }

        public float GetScore()
        {
            return _score;
        }
        
    }
}