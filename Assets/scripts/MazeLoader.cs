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
            }
        }
    }
}

