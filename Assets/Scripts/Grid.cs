using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public GameObject backPrefab;
    public List<Sprite> frontSprites;

    public int rows;
    public int columns;

    public List<int> id;

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
                id = new List<int>{1,1,2,2};
                break;
            case Difficulty.Medium:
                rows = 3;
                columns = 4;
                id = new List<int>{1,1,2,2,3,3,4,4,5,5,6,6};
                break;
            case Difficulty.Hard:
                rows = 4;
                columns = 4;
                id = new List<int>{1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8};
                break;
        }

        for (int i = 0; i < id.Count; i++)
        {
            int random = Random.Range(0, id.Count);
            int before = id[i];       
            id[i] = id[random];
            id[random] = before;
        }


        RectTransform rt = gridLayoutGroup.GetComponent<RectTransform>();
        float Width = rt.rect.width;
        float Height = rt.rect.height;

        Width -= gridLayoutGroup.spacing.x * (columns - 1);
        Height -= gridLayoutGroup.spacing.y * (rows - 1);

        float cellSize = Mathf.Min(Width / columns, Height / rows) * 80/100;
        gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);

        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = columns;
        gridLayoutGroup.childAlignment = TextAnchor.MiddleCenter;


        for (int i = 0; i < rows * columns; i++)
        {
            GameObject newCard = Instantiate(backPrefab, gridLayoutGroup.transform);
            Card cardScript = newCard.GetComponent<Card>();
            cardScript.Card_id = id[i]; 
            cardScript.frontSprite = frontSprites[id[i] - 1];
        }
    }

    public void ClearGrid()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }
        GameObject.FindObjectOfType<GameScript>().score = 0;
        GameObject.FindObjectOfType<GameScript>().currentCount = 0;
        GameObject.FindObjectOfType<GameScript>().scoreUI.gameObject.SetActive(false);
        id.Clear();
    }

}
