using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public List<Card> selectedCards = new List<Card>();

    private Grid gridManager;

    public bool canClick = true;
    public bool winCondition = false;

    public int winCount = 0;
    public int currentCount = 0;

    void Start()
    {
        gridManager = GameObject.FindObjectOfType<Grid>();
        winCount = gridManager.rows * gridManager.columns / 2;
        Debug.Log(winCount);
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
            card1.isMatched = true;
            card2.isMatched = true;
            currentCount += 1;
            selectedCards.Clear();
            canClick = true;
            if (currentCount == winCount)
            {
                winCondition = true;
                Debug.Log("Win");
            }
        }
        else
        {
            selectedCards.Clear();
            canClick = true;
            StartCoroutine(FlipBackRoutine(card1, card2));
        }
        
    }

    IEnumerator FlipBackRoutine(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.3f);
        card1.Flip();
        card2.Flip();
    }


    
}
