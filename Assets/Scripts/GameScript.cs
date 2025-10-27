using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{
    public List<Card> selectedCards = new List<Card>();

    private Grid grid;
    public GameObject menuPanel;

    public bool canClick = true;
    public bool winCondition = false;

    public int currentCount = 0;

    public int score = 0;
    public TMP_Text scoreUI;

    void Start()
    {
        grid = GameObject.FindObjectOfType<Grid>();
    }

    public void CardSelected(Card card)
    {

        selectedCards.Add(card);
        if (selectedCards.Count == 2)
        {
            canClick = false;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        Card card1 = selectedCards[0];
        Card card2 = selectedCards[1];

        if (card1.Card_id == card2.Card_id)
        {
            score += 1;
            scoreUI.text = "Score: " + score;
            scoreUI.gameObject.SetActive(true);
            card1.isMatched = true;
            card2.isMatched = true;
            currentCount += 1;
            selectedCards.Clear();
            canClick = true;
            AudioManager.instance.Match(); 
            if (currentCount == grid.id.Count/2)
            {
                winCondition = true;
                Debug.Log("win");
                AudioManager.instance.Win();
                StartCoroutine(ShowMenu(1f));
            }
        }
        else
        {
            selectedCards.Clear();
            canClick = true;
            StartCoroutine(FlipBackRoutine(card1, card2));
            AudioManager.instance.MissMatch(); 
        }
        
    }

    IEnumerator FlipBackRoutine(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.41f);
        card1.Flip();
        card2.Flip();
    }

    IEnumerator ShowMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        grid.ClearGrid();
        menuPanel.SetActive(true);

    }

    
}
