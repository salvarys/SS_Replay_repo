using System.Collections.Generic;
using UnityEngine;

public class RecordCommand : Command
{
    private Queue<Vector3> recordedPositions = new Queue<Vector3>();
    private Transform playerTransform; // Store the player's transform

    public RecordCommand(Transform player)
    {
        playerTransform = player;
    }

    public void Record(Vector3 position)
    {
        recordedPositions.Enqueue(position);
    }

    public override void Execute()
    {
        if (recordedPositions.Count > 0)
        {
            Vector3 nextPosition = recordedPositions.Dequeue();
            playerTransform.position = nextPosition;
        }
    }

    public bool IsReplayComplete()
    {
        return recordedPositions.Count == 0;
    }

    public Transform PlayerTransform => playerTransform; // Getter for accessing the player's transform
}
