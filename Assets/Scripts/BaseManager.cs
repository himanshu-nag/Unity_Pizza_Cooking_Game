using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    private UIManager uIManager;
    private PlayerManager playerManager;
    public GameObject[] baseProducts;
  
    private void Start()
    {
        uIManager = UIManager.instance;
        playerManager = PlayerManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        uIManager.infoBar.text = "Drop "+PlayerManager.instance.currentProduct+" here.";
    }

    private void OnTriggerExit(Collider other)
    {
        uIManager.infoBar.text = "";
    }

	private void OnTriggerStay(Collider other)
	{
        if(Input.GetMouseButtonDown(0) && playerManager.hasProduct && !playerManager.handPizza.activeInHierarchy)
        {
            var Temp = playerManager.productSystem[playerManager.currentProduct];
            Temp.productPrefab.SetActive(false);
            baseProducts[Temp.BaseIndex].SetActive(true);
            playerManager.baseProductHand[Temp.BaseIndex].SetActive(true);
            playerManager.hasProduct = false;
        }
        if (Input.GetMouseButtonDown(1) && !playerManager.hasProduct)
        {
            foreach (var item in baseProducts)
            {
                item.SetActive(false);
            }
            playerManager.handPizza.SetActive(true);
            playerManager.hasProduct = true;
        }
    }
}
