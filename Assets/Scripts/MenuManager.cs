using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public Grid grid;

    public void StartEasy()
    {
        StartGame(Grid.Difficulty.Easy);
    }

    public void StartMedium()
    {
        StartGame(Grid.Difficulty.Medium);
    }

    public void StartHard()
    {
        StartGame(Grid.Difficulty.Hard);
    }

    void StartGame(Grid.Difficulty difficulty)
    {
        grid.ClearGrid();
        grid.SetGrid(difficulty);
        menuPanel.SetActive(false);
    }
}
