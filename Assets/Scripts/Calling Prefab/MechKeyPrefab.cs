using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechKeyPrefab : MonoBehaviour {

    public GameObject keyboardSpawn, prefabFullsize, prefabTKL, prefab60;
    public Button buttonFullsize, buttonTKL, button60, buttonSave, buttonLoad;

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

        buttonSave.onClick.AddListener(Save);
        buttonLoad.onClick.AddListener(Load);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Tes Save dan Load (BERHASIL)
    public void Save()
    {
        SaveLoadManager.SaveProject(GameObject.FindGameObjectWithTag("MechanicalKeyboards").GetComponent<MechanicalKeyboard>());
    }

    public void Load()
    {
        string[][][] loadedMaterials = SaveLoadManager.LoadProject();
        GameObject[] prefabArray = new GameObject[3];

        prefabFullsize.SetActive(true);
        prefabTKL.SetActive(true);
        prefab60.SetActive(true);

        prefabArray[0] = prefabFullsize;
        prefabArray[1] = prefabTKL;
        prefabArray[2] = prefab60;

        //Debug.Log(loadedMaterials.Length); // JALAN

        //GameObject.Find("Compact ANSI Keyboard").SetActive(true);
        //GameObject.Find("Fullsize ANSI Keyboard").SetActive(true);
        //GameObject.Find("Tenkeyless ANSI Keyboard").SetActive(true);
        
        for (int i = 0; i < prefabArray.Length; i++)
        {
            if (prefabArray[i].name != loadedMaterials[0][0][0])
                prefabArray[i].SetActive(false);
            else if (prefabArray[i].name == loadedMaterials[0][0][0]) // 1. Kalau pengecekan nama keyboard sama
            {
                if (prefabArray[i].transform.GetChild(1).name == loadedMaterials[1][0][0]) // 2.1. Jika nama keycaps profile "Cherry Keycaps"
                {
                    prefabArray[i].transform.GetChild(1).gameObject.SetActive(true);
                    prefabArray[i].transform.GetChild(2).gameObject.SetActive(false);

                    for (int j = 0; j < prefabArray[i].transform.GetChild(1).childCount; j++) // 3.1.1. For Length dari jumlah keycaps
                    {
                        for (int k = 0; k < prefabArray[i].transform.GetChild(1).GetChild(j).GetComponent<MeshRenderer>().materials.Length; k++) // 3.1.2. For Length dari jumlah warna keycaps
                        {
                            prefabArray[i].transform.GetChild(1).GetChild(j).GetComponent<MeshRenderer>().materials[k] = Resources.Load<Material>("Materials/" + loadedMaterials[2][j][k]);
                        }
                    }
                }
                else if (prefabArray[i].transform.GetChild(2).name == loadedMaterials[1][0][0]) // 2.2. Jika nama keycaps profile "SA Keycaps"
                {
                    prefabArray[i].transform.GetChild(2).gameObject.SetActive(true);
                    prefabArray[i].transform.GetChild(1).gameObject.SetActive(false);

                    for (int j = 0; j < prefabArray[i].transform.GetChild(2).childCount; j++) // 3.2.1. For Length dari jumlah keycaps
                    {
                        for (int k = 0; k < prefabArray[i].transform.GetChild(2).GetChild(j).GetComponent<MeshRenderer>().materials.Length; k++) // 3.2.2. For Length dari jumlah warna keycaps
                        {
                            prefabArray[i].transform.GetChild(2).GetChild(j).GetComponent<MeshRenderer>().materials[k] = Resources.Load<Material>("Materials/" + loadedMaterials[2][j][k]);
                        }
                    }
                }
                prefabArray[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + loadedMaterials[3][0][0]); // 4. Masukkkan material case
                for (int l = 0; l < prefabArray[i].transform.GetChild(3).childCount; l++) // 5.1. For Length dari jumlah switch pada Keyboard
                {
                    for (int m = 0; m < prefabArray[i].transform.GetChild(3).GetChild(l).GetComponent<MeshRenderer>().materials.Length; m++) // 5.2. For Length dari jumlah warna pada switch
                    {
                        prefabArray[i].transform.GetChild(3).GetChild(l).GetComponent<MeshRenderer>().materials[m] = Resources.Load<Material>("Materials/" + loadedMaterials[4][l][m]);
                    }
                }
            }
        }

        //GameObject[] targetKeyboards = GameObject.FindGameObjectsWithTag("MechanicalKeyboards");
        //GameObject[] targetKeycaps = new GameObject[2];
        //GameObject[] keycapsTargeted;

        // 0 = keyboard's name; 1 = keycap's name; 2 = keycaps; 3 = cases; 4 = switches;
        //keyboardName = loadedMaterials[0][0][0];
        //keycapsProfile = loadedMaterials[1][0][0];

        //for (int i = 0; i < loadedMaterials[2].Length; i++)
        //{
        //    keycapsMaterial = new Material[loadedMaterials[2].Length][];
        //    for (int j = 0; j < loadedMaterials[2][i].Length; j++)
        //    {
        //        keycapsMaterial[i] = new Material[loadedMaterials[2][i].Length];
        //        keycapsMaterial[i][j] = Resources.Load<Material>("Materials/" + loadedMaterials[2][i][j]); // belum pasti
        //    }
        //}
        //caseMaterial = Resources.Load<Material>(loadedMaterials[3][0][0]);

        //for (int i = 0; i < loadedMaterials[4].Length; i++)
        //{
        //    switchesMaterial = new Material[loadedMaterials[4].Length][];
        //    for (int j = 0; j < loadedMaterials[4][i].Length; j++)
        //    {
        //        switchesMaterial[i] = new Material[loadedMaterials[4][i].Length];
        //        switchesMaterial[i][j] = Resources.Load<Material>("Materials/" + loadedMaterials[4][i][j]); // belum pasti
        //    }
        //}

        //for (int i = 0; i < targetKeyboards.Length; i++) // 0 = keyboard's name; 1 = keycap's profile; 2 = keycaps; 3 = cases; 4 = switches;
        //{
        //    /*Debug.Log("I: " + i + " & Keyboard's Name: " + targetKeyboards[i].name);*/ // ERROR: Object reference is not set to an instance of an object.
        //    //Debug.Log("I: " + i); // JALAN
        //    if (targetKeyboards[i].name != keyboardName)
        //    {
        //        targetKeyboards[i].SetActive(false);
        //    }
        //    else if (targetKeyboards[i].name == keyboardName) // 1. Pengecekan nama keyboard yang di-load
        //    {
        //        targetKeycaps[0] = targetKeyboards[i].transform.GetChild(1).gameObject;
        //        targetKeycaps[1] = targetKeyboards[i].transform.GetChild(2).gameObject;

        //        for (int j = 0; j < targetKeycaps.Length; j++) // 2. Pengecekan jenis keycap yang di-load
        //        {
        //            targetKeycaps[j].SetActive(true);
        //            if (targetKeycaps[j].name != keycapsProfile)
        //            {
        //                targetKeycaps[j].SetActive(false);
        //                keycapsTargeted = new GameObject[targetKeycaps[j].transform.childCount];

        //                for (int k = 0; k < targetKeycaps[j].transform.childCount; k++) // 3. Pemasukkan material keycap
        //                {
        //                    for (int l = 0; l < targetKeycaps[j].transform.GetChild(k).gameObject.GetComponent<MeshRenderer>().materials.Length; l++)
        //                    {
        //                        keycapsTargeted[k].GetComponent<MeshRenderer>().materials[l] = Resources.Load<Material>("Materials/" + loadedMaterials[2][k][l]); // belum pasti
        //                    }
        //                }
        //            }
        //        }

        //        for (int j = 0; j < targetKeyboards[i].transform.GetChild(3).childCount; j++) // 4. Pemasukan material switches
        //        {
        //            for (int k = 0; k < targetKeyboards[i].transform.GetChild(3).GetChild(j).GetComponent<MeshRenderer>().materials.Length; k++)
        //            {
        //                targetKeyboards[i].transform.GetChild(3).GetChild(j).GetComponent<MeshRenderer>().materials[k] = Resources.Load<Material>("Materials/" + loadedMaterials[4][j][k]); // belum pasti
        //            }
        //        }
        //    }
        //}
    }
#endregion

    void mechaFZ ()
    {
        checkMechaExist();
        //Instantiate(prefabFullsize, keyboardSpawn.transform.position, keyboardSpawn.transform.rotation);
        prefabFullsize.SetActive(true);
        buttonFullsize.interactable = false;
        buttonTKL.interactable = true;
        button60.interactable = true;
        prefabFullsize.transform.GetChild(1).gameObject.SetActive(true); // set Cherry Profile as Active
        prefabFullsize.transform.GetChild(2).gameObject.SetActive(false); // set SA Profile as Not Active
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change Cherry Keycap Profile Icon");

        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Button>().onClick.AddListener(GameObject.Find("Game Manager").transform.Find("Menu Manager").GetComponent<HideObject>().HideKeycaps);

        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Switches Icon");
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Button>().onClick.AddListener(GameObject.Find("Game Manager").transform.Find("Menu Manager").GetComponent<HideObject>().HideSwitches);
    }

    void mechaTKL ()
    {
        checkMechaExist();
        //Instantiate(prefabTKL, keyboardSpawn.transform.position, keyboardSpawn.transform.rotation);
        prefabTKL.SetActive(true);
        buttonFullsize.interactable = true;
        buttonTKL.interactable = false;
        button60.interactable = true;
        prefabTKL.transform.GetChild(1).gameObject.SetActive(true); // set Cherry Profile as Active
        prefabTKL.transform.GetChild(2).gameObject.SetActive(false); // set SA Profile as Not Active
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change Cherry Keycap Profile Icon");

        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Button>().onClick.AddListener(GameObject.Find("Game Manager").transform.Find("Menu Manager").GetComponent<HideObject>().HideKeycaps);

        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Switches Icon");
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Button>().onClick.AddListener(GameObject.Find("Game Manager").transform.Find("Menu Manager").GetComponent<HideObject>().HideSwitches);
    }

    void mecha60 ()
    {
        checkMechaExist();
        //Instantiate(prefab60, keyboardSpawn.transform.position, keyboardSpawn.transform.rotation);
        prefab60.SetActive(true);
        buttonFullsize.interactable = true;
        buttonTKL.interactable = true;
        button60.interactable = false;
        prefab60.transform.GetChild(1).gameObject.SetActive(true); // set Cherry Profile as Active
        prefab60.transform.GetChild(2).gameObject.SetActive(false); // set SA Profile as Not Active
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Create Menu Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change Cherry Keycap Profile Icon");

        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").Find("Hide Keycaps").GetComponent<Button>().onClick.AddListener(GameObject.Find("Game Manager").transform.Find("Menu Manager").GetComponent<HideObject>().HideKeycaps);

        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Switches Icon");
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Canvas").transform.Find("Properties Menu Canvas").transform.Find("Hide Switches").GetComponent<Button>().onClick.AddListener(GameObject.Find("Game Manager").transform.Find("Menu Manager").GetComponent<HideObject>().HideSwitches);
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
