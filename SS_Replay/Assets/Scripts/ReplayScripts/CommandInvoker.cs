using UnityEngine;

public class CommandInvoker
{
    private RecordCommand replayCommand;
    private bool isReplaying = false;

    public void Initialize(Transform player)
    {
        replayCommand = new RecordCommand(player);
    }

    public void Record(Vector3 position)
    {
        if (!isReplaying)
        {
            replayCommand.Record(position);
        }
    }

    public void Replay()
    {
        isReplaying = true;
    }

    public void ExecuteReplay()
    {
        if (isReplaying && replayCommand != null)
        {
            if (!replayCommand.IsReplayComplete())
            {
                replayCommand.Execute();

                // Check if player is within bounds
                if (IsPlayerOutOfBounds())
                {
                    // Skip to the next position
                    replayCommand.Execute();
                }
            }
            else
            {
                isReplaying = false; // Replay is complete
            }
        }
    }

    private bool IsPlayerOutOfBounds()
    {
        // Assuming your game is in a 3D space, replace '10' with your world boundaries
        return replayCommand.PlayerTransform.position.y < -10.0f; // Example check for y below the ground level
    }

    public bool IsReplaying()
    {
        return isReplaying;
    }
}
