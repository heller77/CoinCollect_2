using UnityEngine;

namespace UnityTemplateProjects.Items
{
    public class Coin : MonoBehaviour,ITouchable
    {
        private CoinType _type;
        public void Touch()
        {
            Debug.Log("コイン取得した");
        }
    }
}