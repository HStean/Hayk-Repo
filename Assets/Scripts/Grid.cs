using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public GameObject backPrefab;

    private int rows;
    private int columns;

    public enum Difficulty 
    {
        Easy, Medium, Hard
    }

    public void SetGrid(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                rows = 2;
                columns = 2;
                break;
            case Difficulty.Medium:
                rows = 3;
                columns = 3;
                break;
            case Difficulty.Hard:
                rows = 5;
                columns = 6;
                break;
        }

        RectTransform rt = gridLayoutGroup.GetComponent<RectTransform>();
        float Width = rt.rect.width;
        float Height = rt.rect.height;

        Width -= gridLayoutGroup.spacing.x * (columns - 1);
        Height -= gridLayoutGroup.spacing.y * (rows - 1);

        float cellSize = Mathf.Min(Width / columns, Height / rows);
        gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);

        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = columns;

        for (int i = 0; i < rows * columns; i++)
        {
            Instantiate(backPrefab, gridLayoutGroup.transform);
            Debug.Log(i);
        }
    }


    void Start()
    {
        SetGrid(Difficulty.Medium);
    }
}
