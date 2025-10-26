using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public List<Card> selectedCards = new List<Card>();

    public bool canClick = true;

    public void CardSelected(Card card)
    {
        if (!canClick) return;

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
            Debug.Log("Match");
        }
        else
        {
            StartCoroutine(FlipBackRoutine(card1, card2));
        }
        selectedCards.Clear();
    }

    IEnumerator FlipBackRoutine(Card card1, Card card2)
    {
        yield return new WaitForSeconds(1f);
        card1.Flip();
        card2.Flip();

        canClick = true;
    }


    
}
