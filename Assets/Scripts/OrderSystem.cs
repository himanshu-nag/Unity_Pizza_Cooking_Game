using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public static OrderSystem instance;
    public RackManager[] rackManagers;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    //int level = 1;
    private GameManager gameManager;
    [System.Serializable]
    public struct Pizza
    {
        public string OrderName;
        public string[] OrderRecipe;
    }

    public List<Pizza> pizzas;


    int rackNumber;
    private void Start()
    {
        SetOrder(0);
        SetOrder(1);
    }
    public void SetOrder(int rackNum)
    {
        int random = Random.Range(0, 1);
        rackManagers[rackNum].orderName = pizzas[random].OrderName;
        rackManagers[rackNum].orderNameTxt.text = pizzas[random].OrderName;
        foreach (var item in pizzas[random].OrderRecipe)
        {
            rackManagers[rackNum].orderRecipe.Add(item);
        }
    } 
}
