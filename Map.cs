using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace PacMan;

public class Map
{
    private const int tileSize = 30;
    public char[,] map;
    private int rows, cols;
    public int DotCount { get; private set; }

    public Map()
    {
        if (!LoadMap("../../../Map.txt"))
        {
            throw new Exception("Файл карты не найден");
        }
    }

    public bool IsWall(int x, int y)
    {
        if (x < 0 || y < 0 || x >= map.GetLength(1) * tileSize || y >= map.GetLength(0) * tileSize)
            return true;

        int i = y / tileSize;
        int j = x / tileSize;

        return map[i, j] == '#';
    }

    private bool LoadMap(string filename)
    {
        List<string> lines = new();
        if (!File.Exists(filename))
        {
            return false;
        }
        using (StreamReader reader = File.OpenText(filename))
        {
            string? str;
            while ((str = reader.ReadLine()) != null)
            {
                lines.Add(str);
                rows++;
                if (str.Length > cols) cols = str.Length;
                foreach (char c in str)
                {
                    if (c == '.') DotCount++;
                }
            }
        }
        map = new char[rows, cols];
        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                map[i, j] = lines[i][j];
            }
        }
        return true;
    }

    public void DrawMap(Graphics g)
    {
        Pen pen = new Pen(Color.LightBlue);
        Brush brWall = new SolidBrush(Color.Blue);
        Brush brCoin = new SolidBrush(Color.PeachPuff);
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == '#')
                {
                    g.DrawRectangle(pen, tileSize * j, tileSize * i, tileSize, tileSize);
                    g.FillRectangle(brWall, tileSize * j + 1, tileSize * i + 1, tileSize - 1, tileSize - 1);
                }
                else if (map[i, j] == '.')
                {
                    g.FillEllipse(brCoin, j * tileSize + 11, i * tileSize + 11, tileSize / 3, tileSize / 3);
                }
                else if (map[i, j] == '-')
                {
                    g.FillRectangle(brCoin, j * tileSize, i * tileSize + tileSize / 3, tileSize, tileSize / 3);
                }
            }
        }
    }
}
