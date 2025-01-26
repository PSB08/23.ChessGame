using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerBoard : Board
{
    public override void SelectPieceMoved(Vector2 coords)
    {
        Vector2Int intCoords = new Vector2Int(Mathf.RoundToInt(coords.x), Mathf.RoundToInt(coords.y));
        OnSelectPieceMoved(intCoords);
    }

    public override void SetSelectedPiece(Vector2 coords)
    {
        Vector2Int intCoords = new Vector2Int(Mathf.RoundToInt(coords.x), Mathf.RoundToInt(coords.y));
        OnSetSelectedPiece(intCoords);
    }

    
}
