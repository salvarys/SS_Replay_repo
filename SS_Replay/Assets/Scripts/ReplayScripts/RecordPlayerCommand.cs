using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerCommand : ICommand
{
    private Queue<Vector3> recordedPositions; // Stores recorded player positions
    private Transform playerTransform; // Player's transform

    public RecordPlayerCommand(Transform player)
    {
        recordedPositions = new Queue<Vector3>();
        playerTransform = player;
    }

    // Record the player's position
    public void RecordPosition(Vector3 position)
    {
        recordedPositions.Enqueue(position);
    }

    // Execute the replay by dequeuing positions
    public void Execute()
    {
        if (recordedPositions.Count > 0)
        {
            playerTransform.position = recordedPositions.Dequeue();
        }
    }

    // Check if the replay has completed
    public bool IsReplayComplete()
    {
        return recordedPositions.Count == 0;
    }
}
