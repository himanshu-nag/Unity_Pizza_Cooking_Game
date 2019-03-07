using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public DataManager.product product;
    private UIManager uIManager;
    public GameObject prefab;
	private void Start()
	{
        uIManager = UIManager.instance;
	}
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
        uIManager.infoBar.text = "Pick up " + product;
        //GameManager.instance.currentProduct = product;
	}

	private void OnTriggerExit(Collider other)
	{
        uIManager.infoBar.text = "";
	}
    private void OnMouseDown()
    {
        UIManager.instance.infoBar.text = "" + product;
        PlayerManager.instance.SetPickUp(product);
    }
}
