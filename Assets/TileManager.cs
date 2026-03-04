using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase blockTile;
    public Transform player;
    private float range = 6f;
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPosition);

        float distance = Vector2.Distance(player.position, cellCenter);

        if (distance <= range)
        {
            if (Input.GetMouseButtonDown(0) && tilemap.GetTile(cellPosition) == null)
            {
                tilemap.SetTile(cellPosition, blockTile);
            }

            if (Input.GetMouseButtonDown(1) && tilemap.GetTile(cellPosition) != null)
            {
                tilemap.SetTile(cellPosition, null);
            }
        }

        

    }
}
