using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ches : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 10;
    protected override void onCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("gain 10 money");
            GameManager.instance.ShowText("+ " + pesosAmount + "Pesos!", 30 , Color.yellow, transform.position, Vector3.up*50, 3.0f);

        }
    }
}
