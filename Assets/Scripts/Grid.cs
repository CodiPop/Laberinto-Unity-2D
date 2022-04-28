using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Grid : ScriptableObject
{
    private int width;
    private int height;
    private int cellSize;
    private Cell cellPrefab;
    private Cell cellPrefab2;
    private Cell[,] gridArray;
    private int maxm;
    private float P;
    private int cont;
    string final = "Cell 9,9";
    public string abc;

    public Grid(int width, int height, int cellSize, Cell cellPrefab, Cell cellPrefab2)
    {
        
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.cellPrefab = cellPrefab;
        this.cellPrefab2 = cellPrefab2;

        generateBoard();
    }

    private void generateBoard()
    {
        maxm = BoardManager.Instance.GetM();
        P = BoardManager.Instance.GetP();
        Cell cell;
        gridArray = new Cell[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var p = new Vector2(i, j) * cellSize;
                cell = Instantiate(cellPrefab, p, Quaternion.identity);
                cell.Init(this, (int)p.x, (int)p.y, true);

                if (Random.Range(0, P) <= 2)
                {
                    
                    if (cont < maxm)
                    {
                        cell.SetWalkable(false);
                        cont = cont + 1;
                        P = P - 1;


                    }
                }
                else
                {
                    cell.SetColor(Color.white);

                }
                    

                gridArray[i, j] = cell;
            }
        }

        var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }

    internal int GetHeight()
    {
        return height;
    }

    internal int GetWidth()
    {
        return width;
    }

    public void CellMouseClick(Cell cell)
    {
        //cell.SetText("Click on cell "+cell.x+ " "+ cell.y);
        BoardManager.Instance.CellMouseClick(cell.x, cell.y);
    }

    

    public Cell GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    internal float GetCellSize()
    {
        return cellSize;
    }
}
