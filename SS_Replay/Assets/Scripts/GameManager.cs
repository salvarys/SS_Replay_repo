
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        bool gameHasEnded = false;
        public float restartDelay = 1f;
        public GameObject completeLevelUI;

        public void GameOver()
        {
            if (gameHasEnded == false)
            {
                gameHasEnded = true;
                Invoke("Restart", restartDelay);
            }
        }

        void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

       public void CompleteLevel()
         {
            completeLevelUI.SetActive(true);
         }
}
