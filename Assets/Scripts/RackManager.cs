using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RackManager : MonoBehaviour
{
    public int rackNumber;
    private UIManager UIManager;
    public string orderName;
    public Text orderNameTxt;
    public List<string> orderRecipe;
    private PlayerManager playerManager;
    private OrderSystem orderSystem;
    private void Start()
    {
        orderSystem = OrderSystem.instance;
        UIManager = UIManager.instance;
        playerManager = PlayerManager.instance;
        orderRecipe = new List<string>();
    }

    void SubmitPizza()
    {
        if(playerManager.recipeCheckCount != orderRecipe.Count || playerManager.BurntPizza.activeInHierarchy)
        {
            print("false");
            return;
        }
        int i = 0;
       
        foreach (Transform item in playerManager.handPizzaIndex[playerManager.CurrentPizzaIndex].transform)
        {
            if(item.gameObject.activeInHierarchy)
            {
                if(item.name != orderRecipe[i])
                {
                    print("false");
                    return;
                }
            }
        }
        print("true");
        orderSystem.SetOrder(rackNumber);
    }

    bool isNear;
    private void OnTriggerStay(Collider other)
    {
        isNear = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
    private void OnMouseDown()
    {
        if (isNear && !playerManager.hasProduct && (playerManager.handPizzaIndex[playerManager.CurrentPizzaIndex].activeInHierarchy || playerManager.BurntPizza.activeInHierarchy))
         SubmitPizza();
    }
}
