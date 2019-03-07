using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenManager : MonoBehaviour
{
    public int OvenIndex;
    public GameObject[] CookedPizzaIngredient;
    public GameObject cookedPizza;
  
    public GameObject redLight, GreenLight;
    int itemCount,tempCount =0;

    private enum ovenStatus
    {
        occupied,
        empty
    }

    private enum pizzaStatus
    {
        notCooked,
        cooked,
        burnt
    }
    private pizzaStatus GetPizzaStatus;
    private ovenStatus GetOvenStatus;
    private PlayerManager playerManager;
    private bool isNear;

    private void Start()
    {
        GetOvenStatus = ovenStatus.empty;
        GetPizzaStatus = pizzaStatus.notCooked;
        playerManager = PlayerManager.instance;
    }

    public void CookPizza(Transform pizza)
    {
        tempCount = 0;
        foreach (Transform item in pizza.transform)
        {
            if (item.gameObject.activeSelf){
                CookedPizzaIngredient[itemCount].SetActive(true);
                tempCount++;
            }
              
            playerManager.baseProductHand[itemCount].SetActive(false);
            
            itemCount++;
        }
        itemCount = 0;
        pizza.gameObject.SetActive(false);
        GetPizzaStatus = pizzaStatus.notCooked;
        playerManager.hasProduct = false;
        StartCoroutine(OvenTimer());
    }

    IEnumerator OvenTimer()
    {
        int i = 0;
        while (i<45)
        {
            i++;
            if(i==30)
            {
                GreenLight.SetActive(true);
                GetPizzaStatus = pizzaStatus.cooked;
            }
            yield return new WaitForSeconds(1f);
        }
        GreenLight.SetActive(false);
        redLight.SetActive(true);
        GetPizzaStatus = pizzaStatus.burnt;
    }

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
        if (!isNear)
            return;
        if (playerManager.handPizza.activeInHierarchy && GetOvenStatus == ovenStatus.empty)
            CookPizza(playerManager.handPizza.transform);
        else if (GetPizzaStatus != pizzaStatus.notCooked && !playerManager.hasProduct && !playerManager.handPizza.activeInHierarchy)
        {
            if (GetPizzaStatus == pizzaStatus.cooked)
                cookedPizza.SetActive(true);
            else if (GetPizzaStatus == pizzaStatus.burnt)
                playerManager.BurntPizza.SetActive(true);
            GreenLight.SetActive(false);
            redLight.SetActive(false);
            GetOvenStatus = ovenStatus.empty;
            playerManager.CurrentPizzaIndex = OvenIndex;
            playerManager.recipeCheckCount = tempCount;
            StopAllCoroutines();
        }
    }
}
