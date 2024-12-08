using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{
    public Transform player; // Assign the player GameObject in the Inspector
    public Text replayText; // Assign a UI Text for "Replay" message
    public float replaySpeed = 5f; // Replay execution speed

    private RecordPlayerCommand replayCommand; // Replay command
    private bool isReplaying = false;

    void Start()
    {
        // Initialize the replay command
        replayCommand = new RecordPlayerCommand(player);

        // Hide replay text initially
        if (replayText != null)
        {
            replayText.enabled = false;
        }
    }

    void Update()
    {
        // Record player position if not replaying
        if (!isReplaying)
        {
            replayCommand.RecordPosition(player.position);
        }

        // Trigger replay on death (replace with your game's death condition)
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartReplay();
        }

        // Execute replay logic
        if (isReplaying)
        {
            ExecuteReplay();
        }
    }

    // Start the replay process
    public void StartReplay()
    {
        if (replayCommand.IsReplayComplete())
        {
            Debug.LogWarning("No positions recorded to replay.");
            return;
        }

        isReplaying = true;
        Debug.Log("Replay started!");

        // Show replay text
        if (replayText != null)
        {
            replayText.enabled = true;
            StartCoroutine(FlashReplayText());
        }
    }

    // Execute replay logic
    private void ExecuteReplay()
    {
        if (!replayCommand.IsReplayComplete())
        {
            replayCommand.Execute();
        }
        else
        {
            EndReplay();
        }
    }

    // End the replay process
    private void EndReplay()
    {
        isReplaying = false;

        // Hide replay text
        if (replayText != null)
        {
            replayText.enabled = false;
        }

        Debug.Log("Replay finished.");
    }

    // Flash the "Replay" text on the screen
    private IEnumerator FlashReplayText()
    {
        while (isReplaying)
        {
            if (replayText != null)
            {
                replayText.color = Color.red;
                yield return new WaitForSeconds(0.5f);
                replayText.color = Color.clear;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
