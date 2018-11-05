using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechKeyPrefab : MonoBehaviour {

    public GameObject keyboardSpawn, prefabFullsize, prefabTKL, prefab60;
    public Button buttonFullsize, buttonTKL, button60;

	// Use this for initialization
	void Start () {
        prefabFullsize.SetActive(false);
        prefabTKL.SetActive(false);
        prefab60.SetActive(false);

        Button btnFZ = buttonFullsize.GetComponent<Button>();
        Button btnTKL = buttonTKL.GetComponent<Button>();
        Button btn60 = button60.GetComponent<Button>();

        btnFZ.onClick.AddListener(mechaFZ);
        btnTKL.onClick.AddListener(mechaTKL);
        btn60.onClick.AddListener(mecha60);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void mechaFZ ()
    {
        checkMechaExist();
        //Instantiate(prefabFullsize, keyboardSpawn.transform.position, keyboardSpawn.transform.rotation);
        prefabFullsize.SetActive(true);
        buttonFullsize.interactable = false;
        buttonTKL.interactable = true;
        button60.interactable = true;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
    }

    void mechaTKL ()
    {
        checkMechaExist();
        //Instantiate(prefabTKL, keyboardSpawn.transform.position, keyboardSpawn.transform.rotation);
        prefabTKL.SetActive(true);
        buttonFullsize.interactable = true;
        buttonTKL.interactable = false;
        button60.interactable = true;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
    }

    void mecha60 ()
    {
        checkMechaExist();
        //Instantiate(prefab60, keyboardSpawn.transform.position, keyboardSpawn.transform.rotation);
        prefab60.SetActive(true);
        buttonFullsize.interactable = true;
        buttonTKL.interactable = true;
        button60.interactable = false;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
    }

    void checkMechaExist()
    {
        GameObject[] mechKeys;
        mechKeys = GameObject.FindGameObjectsWithTag("MechanicalKeyboards");
        if (mechKeys == null)
            return;
        foreach(GameObject mechKey in mechKeys)
        {
            //Destroy(mechKey);
            mechKey.SetActive(false);
        }
    }
}
