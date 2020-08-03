using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesHolder : MonoBehaviour
{
    private Tile _baseTile;

    private void Awake()
    {
        _baseTile = (Tile) Resources.Load("base", typeof(Tile));
    }

    public Tile GetBaseTile()
    {
        return _baseTile;
    }
}