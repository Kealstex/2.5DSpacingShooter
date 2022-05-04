using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadGame(){
            SceneManager.LoadScene(0);
        }
    }
}
