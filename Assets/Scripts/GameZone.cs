using UnityEngine;
using UnityEngine.Tilemaps;

public class GameZone : MonoBehaviour
{
    private const float CameraPositionModifier = 0.5f;
    private const float CameraSizeModifier = 1.2f;

    private Tilemap _gameZoneTilemap;
    private TilesHolder _tilesHolder;
    private GameData _gameData;
    private Camera _camera;

    private void Awake()
    {
        _gameZoneTilemap = GetComponent<Tilemap>();
        _tilesHolder = GetComponent<TilesHolder>();
        _gameData = FindObjectOfType<GameData>();
        _camera = Camera.main;
    }

    private void Start()
    {
        var sizes = _gameData.Size.Split('x');
        var origin = _gameZoneTilemap.origin;
        var cellSize = _gameZoneTilemap.cellSize;
        _gameZoneTilemap.ClearAllTiles();
        var currentCellPosition = origin;
        var width = int.Parse(sizes[0]);
        var height = int.Parse(sizes[1]);
        for (var h = 0; h < height; h++)
        {
            for (var w = 0; w < width; w++)
            {
                _gameZoneTilemap.SetTile(currentCellPosition, _tilesHolder.GetBaseTile());
                currentCellPosition = new Vector3Int(
                    (int) (cellSize.x + currentCellPosition.x),
                    currentCellPosition.y, origin.z);
            }

            currentCellPosition = new Vector3Int(origin.x, (int) (cellSize.y + currentCellPosition.y), origin.z);
        }

        _gameZoneTilemap.CompressBounds();

        ModifyCamera(width);
    }

    private void ModifyCamera(int width)
    {
        var modifier = (width - 4) * CameraPositionModifier;
        _camera.transform.position = new Vector3(
            _camera.transform.position.x + modifier,
            _camera.transform.position.y + modifier,
            _camera.transform.position.z
        );
        _camera.orthographicSize = Mathf.Pow(CameraSizeModifier, (width - 4)) * _camera.orthographicSize;
    }
}