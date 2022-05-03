using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoinCollect2.Title
{
    public class TitleManager : MonoBehaviour
    {
        public void GoToMain()
        {
            SceneManager.LoadScene("Main");
        }
        
    }
}