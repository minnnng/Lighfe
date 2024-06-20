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

       /* // Ÿ�ϸʿ� TilemapCollider2D �߰�
        TilemapCollider2D tilemapCollider = tilemap.gameObject.AddComponent<TilemapCollider2D>();
        tilemapCollider.usedByComposite = true; // Ÿ�ϸ� �ݶ��̴� ���� ���*/
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

                // �� Ÿ�Ͽ��� Collider �߰�
                if (ch == '#')
                {
                    // �� Ÿ�Ͽ� Collider �߰�
                    GameObject tileGameObject = tilemap.GetInstantiatedObject(new Vector3Int(x, lines.Length - y - 1, 0));
                    if (tileGameObject != null)
                    {
                        // �ݸ����� ������ ����
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
