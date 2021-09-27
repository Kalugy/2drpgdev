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
            Debug.Log("gain 10 money"+ Vector3.up);
            GameManager.instance.ShowText("+" + pesosAmount + "Pesos!", 20 , Color.yellow, transform.position, Vector3.up*50, 2.0f);

        }
    }
}
