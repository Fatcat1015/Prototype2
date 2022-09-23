using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{

    public List<GameObject> Items;
    public GameObject SelectedItem = null;

    private void Start()
    {
        //add all children to items
        foreach (Transform child in transform)
        {
            Items.Add(child.gameObject);
        }

        for (int i = 0; i < Items.Count; i++)
        {
            Items[i].SetActive(false);

        }
    }

    public void DisplayItems()
    {
        for(int i = 0; i < Items.Count; i++)
        {
            Items[i].SetActive(true);
        }
    }

    public bool BuyItems(int fame, int money)
    {
        if(SelectedItem != null)
        {
            if(SelectedItem.GetComponent<Itemstats>().price <= money)
            {
                if(SelectedItem.GetComponent<Itemstats>().fame_required  <= fame)
                {
                    
                    return true;
                }
                else
                {
                    //need more fame
                    return false;
                }
            }
            else
            {
                //need more money
                return false;
            }
        }
        else
        {
            //error
            return false;
        }
    }

    private void Update()
    {

        if(SelectedItem != null)
        {
            SelectedItem.GetComponent<SpriteRenderer>().color = Color.blue;
        }


    }

}
