using Items;
using UnityEngine;

namespace Player
{
    public class PlayerContactDetector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITouchable getObject))
            {
                getObject.Touch(this);
                Debug.Log("検出器 「何かに触れた！」");
            }
        }
        
    }
}