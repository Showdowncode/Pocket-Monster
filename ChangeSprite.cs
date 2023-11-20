using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
   public Sprite forward,backward,right,left;


//Changes the sprites.
   private void Update()
   {
        if (Input.GetKeyDown(KeyCode.S))
            GetComponent<SpriteRenderer>().sprite = forward;
        if (Input.GetKeyDown(KeyCode.D))
            GetComponent<SpriteRenderer>().sprite = right;
        if (Input.GetKeyDown(KeyCode.A))
            GetComponent<SpriteRenderer>().sprite = left;
        if (Input.GetKeyDown(KeyCode.W))
            GetComponent<SpriteRenderer>().sprite = backward;
   }
}
