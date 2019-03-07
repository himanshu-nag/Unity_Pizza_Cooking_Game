using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    private UIManager UIManager;
    private PlayerManager playerManager;
    private GameManager GameManager;
    private void Start()
    {
        UIManager = UIManager.instance;
        playerManager = PlayerManager.instance;
        GameManager = GameManager.instance;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(playerManager.currentProduct == DataManager.product.none && playerManager.handPizza.activeInHierarchy)
            {
                foreach (var item in playerManager.baseProductHand)
                {
                    item.SetActive(false);
                }
                playerManager.handPizza.SetActive(false);
                return;
            }
            else if (playerManager.currentProduct == DataManager.product.none && playerManager.handPizzaIndex[playerManager.CurrentPizzaIndex].activeInHierarchy)
            {
                foreach (Transform item in playerManager.handPizzaIndex[playerManager.CurrentPizzaIndex].transform)
                {
                    item.gameObject.SetActive(false);
                }
                playerManager.handPizzaIndex[playerManager.CurrentPizzaIndex].SetActive(false);
                return;
            }
            playerManager.productSystem[playerManager.currentProduct].productPrefab.SetActive(false);
            playerManager.hasProduct = false;
            playerManager.currentProduct = DataManager.product.none;
        }
    }
}
