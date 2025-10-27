using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int Card_id;

    public bool isFlipped;
    public bool isMatched;  

    private Image cardImage;
    public Sprite backSprite;
    public Sprite frontSprite;

    private GameScript gameManager;
    
    void Awake()
    {
        isFlipped = false;

        cardImage = GetComponent<Image>();
        gameManager = GameObject.FindObjectOfType<GameScript>();

        backSprite = cardImage.sprite;
    }


    public void Flip()
    {
        isFlipped = !isFlipped;
        

        if (isFlipped)
        {
            cardImage.sprite = frontSprite;
        }
        else
        {
            cardImage.sprite = backSprite;
        }
    }

    public void OnButtonPress()
    {
        

        if (!isFlipped && !isMatched && gameManager.canClick)
        {
            Flip();
            gameManager.CardSelected(this);
        }
    }

}
