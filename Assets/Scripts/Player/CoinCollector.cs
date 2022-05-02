using System;
using UnityEngine;

namespace UnityTemplateProjects.Player
{
    public class CoinCollector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Items.ITouchable getObject))
            {
                getObject.Touch();
                Debug.Log("取得した！");
            }
        }
    }
}