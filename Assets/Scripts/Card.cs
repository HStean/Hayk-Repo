using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int Card_id;

    public bool isFlipped = false;
    public bool isMatched = false;
    public bool isAnimating = false;  

    private Image cardImage;
    public Button button;
    public Sprite backSprite;
    public Sprite frontSprite;

    private GameScript gameManager;
    
    void Awake()
    {
        cardImage = GetComponent<Image>();
        gameManager = GameObject.FindObjectOfType<GameScript>();
        button = GetComponent<Button>();
        backSprite = cardImage.sprite;
    }


    public void Flip()
    {
        if(!isAnimating)
        {
            isFlipped = !isFlipped;
            StartCoroutine(FlipAnimation());
        }
    }

    IEnumerator FlipAnimation()
    {
        isAnimating = true;
        button.interactable = false;

        float duration = 0.2f;
        float time = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(0f, startScale.y, startScale.z);

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;

        if (isFlipped)
        {
            cardImage.sprite = frontSprite;
        }
        else
        {
            cardImage.sprite = backSprite;
        }
        time = 0f;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(endScale, startScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale;
        isAnimating = false;
        button.interactable = true;
    }

    public void OnButtonPress()
    {
        if (!isFlipped && !isMatched && gameManager.canClick)
        {
            Flip();
            gameManager.CardSelected(this);
            AudioManager.instance.Flip(); 
        }
    }


}
