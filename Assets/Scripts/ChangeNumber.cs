using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeNumber : MonoBehaviour
{
    public Player player;
    public bool isGameOver;
    public NumberInstantiate numberInstantiate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int colNum = Convert.ToInt32(collision.gameObject.GetComponent<SpriteRenderer>().sprite.name);

        //check if the current number is less than that number else gameover.
        if(player.currentNumber > colNum)
        {
            //instantiate the number of the sprite image
            player.playerSpriteNumber.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;

            Destroy(collision.gameObject);
        }
        else if(player.currentNumber == colNum)
        {
            //add plus one from the current ontrigger enter
            for (int i = 0; i < numberInstantiate.number.Length; i++)
            {
                Debug.Log(numberInstantiate.number.Length);

                if (colNum == Convert.ToInt32(numberInstantiate.number[(i + 1)]))
                {
                    player.playerSpriteNumber.sprite = numberInstantiate.number[(i + 2)].GetComponent<SpriteRenderer>().sprite;

                    Destroy(collision.gameObject);
                }
            }
        }
        else
        {
            isGameOver = true;
        }
    }
}
