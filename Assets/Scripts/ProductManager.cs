using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    //[HideInInspector]
    public GameObject productPrefab;
    public DataManager.product product;
    public int cost;
    public int BaseIndex;
    void Awake()
    {
        productPrefab = gameObject;
    }
}
