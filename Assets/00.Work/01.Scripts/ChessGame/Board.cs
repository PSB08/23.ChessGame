using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform bottomLefSquareTransform;
    [SerializeField] private float squareSize;

    public Vector3 CalculatedPositionFromCoords(Vector2Int coords)
    {
        return bottomLefSquareTransform.position + new Vector3(coords.x * squareSize, 0f, coords.y * squareSize);
    }
}
