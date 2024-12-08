using UnityEngine;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{
    public Transform player; // Assign the player object
    public Text replayText;  // Assign a Text UI element
    public GameManager gameManager; // Reference to GameManager

    private CommandInvoker invoker;

    void Start()
    {
        invoker = new CommandInvoker();
        invoker.Initialize(player);

        if (replayText != null)
        {
            replayText.enabled = false;
        }

        if (gameManager == null)
        {
            Debug.LogError("GameManager not assigned in ReplayManager!");
        }
    }

    void Update()
    {
        if (!invoker.IsReplaying())
        {
            invoker.Record(player.position);
        }
        else
        {
            invoker.ExecuteReplay();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with an obstacle. Game Over.");
            gameManager.GameOver(); // Trigger Game Over in GameManager
            StartReplay();           // Start replay after game over
        }
    }

    private void StartReplay()
    {
        if (invoker.IsReplaying()) return;

        invoker.Replay();
        if (replayText != null)
        {
            replayText.enabled = true;
            StartCoroutine(FlashReplayText());
        }
    }

    private System.Collections.IEnumerator FlashReplayText()
    {
        while (invoker.IsReplaying())
        {
            replayText.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            replayText.color = Color.clear;
            yield return new WaitForSeconds(0.3f);
                
                
                
                
                
                
                
            
        }

        replayText.enabled = false;
    }
}
