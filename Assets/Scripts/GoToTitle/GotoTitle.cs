using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoinCollect2.GoToTitle
{
    public class GotoTitle : MonoBehaviour
    {
        public void GoToTitle()
        {
            SceneManager.LoadSceneAsync("Title");
        }
    }
}