using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public Dictionary<DataManager.product, ProductManager> productSystem = new Dictionary<DataManager.product, ProductManager>();
    private GameManager gameManager;
    public DataManager.product currentProduct;
    public GameObject[] baseProductHand;
    public GameObject handPizza;
    public int CurrentPizzaIndex;
    public GameObject[] handPizzaIndex;
    public int recipeCheckCount;
    public GameObject BurntPizza;
    public bool hasProduct;
	private void Start()
	{
        hasProduct = false;
        gameManager = GameManager.instance;
        int i = 0;
        foreach (DataManager.product item in Enum.GetValues(typeof(DataManager.product)))
        {
            productSystem.Add(item,gameManager.productManagers[i]);
            i++;
        }
    }

    public void SetPickUp(DataManager.product product)
    {
        if(hasProduct){
            return;
        }
        hasProduct = true;
        productSystem[product].productPrefab.SetActive(true);
        currentProduct = product;
    }
}
