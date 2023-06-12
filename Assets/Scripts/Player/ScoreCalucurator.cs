using CoinCollect2.Items.Coins;

namespace CoinCollect2.Result
{
    public class ScoreCalucurator
    {
        private float _score;
        private float _goldScore=10;
        private float _silverScore=5;
        private float _copperScore=1;
        private int magnification = 1;
        public void addScoreByCoin(Coin coin)
        {
            var coinType = coin.GetCoinType();
            switch (coinType)
            {
                case CoinType.Gold:
                    _score += _goldScore*magnification;
                    break;
                    
                case CoinType.Silver:
                    _score += _silverScore*magnification;
                    break;
                case CoinType.Copper:
                    _score += _copperScore*magnification;
                    break;
            }
        }

        public float GetScore()
        {
            return _score;
        }

        public void DoublicMagnification()
        {
            magnification *= 2;
        }

        public int GetMagnification()
        {
            return this.magnification;
        }
    }
}