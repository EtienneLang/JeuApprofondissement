using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaclable : Collidable
{
    private bool isInRange;
    private Collider2D[] hitsCircle = new Collider2D[5];
    protected CircleCollider2D circleCollider;
    public ContactFilter2D contactCircle;
    KeyCode lootKey = KeyCode.Space;

    protected override void Start()
    {
        base.Start();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    protected override void Update()
    {
        circleCollider.OverlapCollider(contactCircle, hitsCircle);
        for (int i = 0; i < hitsCircle.Length; i++)
        {
            if (hitsCircle[i] != null)
            {
                OnCollide(hitsCircle[i]);
            }
            hitsCircle[i] = null;
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (isInRange && Input.GetKeyDown(lootKey))
        {
            Debug.Log("Door should open");
            if (coll.name == "Player")
            {
                OnInteraction();
                Debug.Log("Looted");

            }
        }
    }

    protected virtual void OnInteraction() 
    {
        //Logique de quoi faire quand on loot un objet (dans les enfants)
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isInRange = true;
            Debug.Log("Player in range - trashcan");
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        Debug.Log("Player Is leaving - trashcan");
    }

}
