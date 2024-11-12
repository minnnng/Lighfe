using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeLoader : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile groundTile;

    void Start()
    {
        LoadMaze("Assets/large_maze.txt");

       /* // 타일맵에 TilemapCollider2D 추가
        TilemapCollider2D tilemapCollider = tilemap.gameObject.AddComponent<TilemapCollider2D>();
        tilemapCollider.usedByComposite = true; // 타일맵 콜라이더 설정 사용*/
    }

    void LoadMaze(string path)
    {
        string[] lines = File.ReadAllLines(path);
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                char ch = lines[y][x];
                Tile tile = ch == '#' ? wallTile : groundTile;
                tilemap.SetTile(new Vector3Int(x, lines.Length - y - 1, 0), tile);

                // 벽 타일에만 Collider 추가
                if (ch == '#')
                {
                    // 벽 타일에 Collider 추가
                    GameObject tileGameObject = tilemap.GetInstantiatedObject(new Vector3Int(x, lines.Length - y - 1, 0));
                    if (tileGameObject != null)
                    {
                        // 콜리더가 있으면 제거
                        BoxCollider2D collider = tileGameObject.GetComponent<BoxCollider2D>();
                        if (collider != null)
                        {
                            Destroy(collider);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Failed to find wall tile object at position: " + x + ", " + y);
                    }
                }
            }
        }
    }

}
