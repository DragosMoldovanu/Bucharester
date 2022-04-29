using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] sprites;
    public int currentSprite;
    public void CycleSprite()
    {
        if (currentSprite>=sprites.Length-1)
        {
            currentSprite = 0;
        }
        else
        {
            currentSprite++;
        }
        GetComponent<Image>().sprite = sprites[currentSprite];
    }
}
