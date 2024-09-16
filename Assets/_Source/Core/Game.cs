using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}