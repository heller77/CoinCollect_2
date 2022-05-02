using CoinCollect2.Player;

namespace CoinCollect2.Items
{
    public interface ITouchable
    {
        void Touch(PlayerContactDetector detector);
    }
}