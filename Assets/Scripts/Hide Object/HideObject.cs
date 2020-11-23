using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideObject : MonoBehaviour
{
    public Canvas canvasFile, canvasCreate, canvasProperties, canvasColorPaletteSelection, canvasColorPalette, canvasSwitchesSelection, canvasSwitchesCP;
    public Button buttonFileProject, buttonChangeProfileKeycaps, buttonReverseColorKeycaps,
        buttonSaveProject, buttonHideKeycaps, buttonHideSwitches, buttonChangeKeycapsColor, buttonChangeSwitches, buttonOpenMenuScreenshot,
        buttonCreate, buttonProperties, buttonCloseFile, buttonCloseCreate, buttonCloseProperties, buttonCloseChangeKeycapsColor,
        buttonCloseColorPalette, buttonCloseChangeSwitches, buttonCloseSwitchesColorPalette, buttonCloseToCanvas;
    private GameObject mechanicalKeyboards;
    private GameObject[] buttonCreateMenu, buttonPropertiesMenu;
    private Transform keycaps, switches;
    // bisa juga untuk ganti profil keycap
    private string keycapsParent; // untuk ambil nama parent dari keycap yang disembunyikan

    // Use this for initialization
    void Start()
    {
        // All irrelevant UI object, set Active true, and hide all object (alpha - 0f & blockRaycast - false)
        canvasCreate.GetComponent<CanvasGroup>().alpha = 0f;
        canvasCreate.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasFile.GetComponent<CanvasGroup>().alpha = 0f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasProperties.GetComponent<CanvasGroup>().alpha = 0f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasColorPalette.GetComponent<CanvasGroup>().alpha = 0f;
        canvasColorPalette.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasColorPaletteSelection.GetComponent<CanvasGroup>().alpha = 0f;
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasSwitchesSelection.GetComponent<CanvasGroup>().alpha = 0f;
        canvasSwitchesSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasSwitchesCP.GetComponent<CanvasGroup>().alpha = 0f;
        canvasSwitchesCP.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //canvasSaveLoadMenu.GetComponent<CanvasGroup>().alpha = 0f;
        //canvasSaveLoadMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

        // After hide some object, add listener to each button
        buttonFileProject.onClick.AddListener(OpenFileMenu);
        buttonChangeProfileKeycaps.onClick.AddListener(ChangeKeycapProfile);
        // buttonReverseColorKeycaps sudah diatur listener di script ChangeColorPrefab

        buttonCreate.onClick.AddListener(OpenCreateMenu);
        buttonProperties.onClick.AddListener(OpenPropertiesMenu);

        buttonHideKeycaps.onClick.AddListener(HideKeycaps);
        buttonHideSwitches.onClick.AddListener(HideSwitches);
        buttonChangeKeycapsColor.onClick.AddListener(HidePropCKC);
        buttonChangeSwitches.onClick.AddListener(HidePropCS);
        buttonOpenMenuScreenshot.onClick.AddListener(HideMenuCanvas);

        buttonCloseFile.onClick.AddListener(CloseFileMenu);
        buttonCloseCreate.onClick.AddListener(CloseCreateMenu);
        buttonCloseProperties.onClick.AddListener(ClosePropertiesMenu);
        buttonCloseChangeKeycapsColor.onClick.AddListener(UnHidePropCKC);
        buttonCloseColorPalette.onClick.AddListener(UnHideCPSelect);
        buttonCloseChangeSwitches.onClick.AddListener(UnHidePropCS);
        buttonCloseSwitchesColorPalette.onClick.AddListener(UnHideSwitchesBrand);
        buttonCloseToCanvas.onClick.AddListener(UnHideMenuCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        mechanicalKeyboards = GameObject.FindWithTag("MechanicalKeyboards");
        EnableButton();
    }

    void OpenFileMenu()
    {
        buttonFileProject.gameObject.SetActive(false);
        buttonChangeProfileKeycaps.gameObject.SetActive(false);
        buttonReverseColorKeycaps.gameObject.SetActive(false);
        canvasFile.GetComponent<CanvasGroup>().alpha = 1f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //string material = "2D2E30";
        //Debug.Log(Resources.Load("Materials/" + material, typeof(Material)) as Material); // muncul
        //string newPath = "Materials/2D2E30";
        //Debug.Log(Resources.Load(newPath, typeof(Material)) as Material); // muncul
        //Debug.Log(Resources.Load("Materials/2D2E30", typeof(Material)) as Material); // muncul
    }

    void CloseFileMenu()
    {
        canvasFile.GetComponent<CanvasGroup>().alpha = 0f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = false;
        buttonFileProject.gameObject.SetActive(true);
        buttonChangeProfileKeycaps.gameObject.SetActive(true);
        buttonReverseColorKeycaps.gameObject.SetActive(true);
    }

    void OpenCreateMenu()
    {
        canvasFile.GetComponent<CanvasGroup>().alpha = 0f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvasCreate.GetComponent<CanvasGroup>().alpha = 1f;
        canvasCreate.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void CloseCreateMenu()
    {
        canvasFile.GetComponent<CanvasGroup>().alpha = 1f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = true;
        canvasCreate.GetComponent<CanvasGroup>().alpha = 0f;
        canvasCreate.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void OpenPropertiesMenu()
    {
        buttonProperties.gameObject.SetActive(false);
        canvasProperties.GetComponent<CanvasGroup>().alpha = 1f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void ClosePropertiesMenu()
    {
        buttonProperties.gameObject.SetActive(true);
        canvasProperties.GetComponent<CanvasGroup>().alpha = 0f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void EnableButton()
    {
        buttonChangeProfileKeycaps.interactable = false;
        buttonReverseColorKeycaps.interactable = false;
        buttonSaveProject.interactable = false;
        buttonHideKeycaps.interactable = false;
        buttonHideSwitches.interactable = false;
        buttonChangeKeycapsColor.interactable = false;
        buttonChangeSwitches.interactable = false;
        buttonOpenMenuScreenshot.interactable = false;

        if (mechanicalKeyboards == null)
            return;
        else if (mechanicalKeyboards != null)
        {
            buttonChangeProfileKeycaps.interactable = true;
            buttonReverseColorKeycaps.interactable = true;
            buttonSaveProject.interactable = true;
            buttonHideKeycaps.interactable = true;
            buttonHideSwitches.interactable = true;
            buttonChangeKeycapsColor.interactable = true;
            buttonChangeSwitches.interactable = true;
            buttonOpenMenuScreenshot.interactable = true;
        }
    }

    // 1. ambil keycap dengan tag keycapsSelected
    // 2. ganti dengan tag keycaps & component halo di-matikan
    // 3. ambil keycap dengan tag Keycaps
    // 4. ambil parent dari keycap tsb (untuk function unhide)
    public void HideKeycaps() 
    {
        GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        foreach (GameObject otherSelectedKeycap in otherSelectedKeycaps)
        {
            Behaviour oskHalo = (Behaviour)otherSelectedKeycap.GetComponent("Halo");
            oskHalo.enabled = false;
            otherSelectedKeycap.tag = "Keycaps";
        }

        //GameObject[] targetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        ////Debug.Log(targetKeycaps[0].transform.parent.name);
        //foreach(GameObject targetKeycap in targetKeycaps)
        //{
        //    keycapsParent = targetKeycap.transform.parent.name;
        //    //targetKeycap.GetComponent<MeshCollider>().enabled = false;
        //    targetKeycap.SetActive(false);
        //}

        keycapsParent = GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name;
        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsParent).gameObject.SetActive(false);

        //GameObject[] targetSwitches = GameObject.FindGameObjectsWithTag("Switches");
        //foreach (GameObject targetSwitch in targetSwitches)
        //{
        //    targetSwitch.GetComponent<MeshCollider>().enabled = true;
        //}

        //keycaps = mechanicalKeyboards.transform.Find("Keycaps");
        //keycaps.gameObject.SetActive(false);
        //buttonHideKeycaps.GetComponentInChildren<Text>().text = "Unhide Keycaps";
        buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Unhide Keycaps Icon");
        buttonHideKeycaps.onClick.RemoveAllListeners();
        buttonHideKeycaps.onClick.AddListener(UnhideKeycaps);
    }

    public void UnhideKeycaps() // tidak bisa menemukan objek sebelumya
    {

        //GameObject[] targetSwitches = GameObject.FindGameObjectsWithTag("Switches");
        //foreach (GameObject targetSwitch in targetSwitches)
        //{
        //    targetSwitch.GetComponent<MeshCollider>().enabled = false;
        //}

        //GameObject[] targetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        //foreach(GameObject targetKeycap in targetKeycaps)
        //{
        //    //targetKeycap.GetComponent<MeshCollider>().enabled = true;
        //    targetKeycap.SetActive(true);
        //}

        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsParent).gameObject.SetActive(true);

        //keycaps = mechanicalKeyboards.transform.Find("Keycaps");
        //keycaps.gameObject.SetActive(true);
        //buttonHideKeycaps.GetComponentInChildren<Text>().text = "Hide Keycaps";
        buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
        buttonHideKeycaps.onClick.RemoveAllListeners();
        buttonHideKeycaps.onClick.AddListener(HideKeycaps);
    }

    public void HideSwitches()
    {
        //GameObject[] targetSwitches = GameObject.FindGameObjectsWithTag("Switches");
        //foreach (GameObject targetSwitch in targetSwitches)
        //{
        //    targetSwitch.GetComponent<MeshCollider>().enabled = false;
        //}
        GameObject[] otherSelectedSwitches = GameObject.FindGameObjectsWithTag("SwitchesSelected");
        foreach (GameObject otherSelectedSwitch in otherSelectedSwitches)
        {
            Behaviour oskHalo = (Behaviour)otherSelectedSwitch.GetComponent("Halo");
            oskHalo.enabled = false;
            otherSelectedSwitch.tag = "Switches";
        }
        
        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find("Switches").gameObject.SetActive(false);

        //switches = mechanicalKeyboards.transform.Find("Switches");
        //switches.gameObject.SetActive(false);
        //buttonHideSwitches.GetComponentInChildren<Text>().text = "Unhide Switches";
        buttonHideSwitches.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Unhide Switches Icon");
        buttonHideSwitches.onClick.RemoveAllListeners();
        buttonHideSwitches.onClick.AddListener(UnhideSwitches);
    }

    public void UnhideSwitches()
    {
        //GameObject[] targetSwitches = GameObject.FindGameObjectsWithTag("Switches");
        //foreach (GameObject targetSwitch in targetSwitches)
        //{
        //    targetSwitch.GetComponent<MeshCollider>().enabled = true;
        //}

        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find("Switches").gameObject.SetActive(true);

        //switches = mechanicalKeyboards.transform.Find("Switches");
        //switches.gameObject.SetActive(true);
        //buttonHideSwitches.GetComponentInChildren<Text>().text = "Hide Switches";
        buttonHideSwitches.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Switches Icon");
        buttonHideSwitches.onClick.RemoveAllListeners();
        buttonHideSwitches.onClick.AddListener(HideSwitches);
    }

    public void ChangeKeycapProfile() // Final Test
    {
        GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        foreach (GameObject otherSelectedKeycap in otherSelectedKeycaps)
        {
            Behaviour oskHalo = (Behaviour)otherSelectedKeycap.GetComponent("Halo");
            oskHalo.enabled = false;
            otherSelectedKeycap.tag = "Keycaps";
        } // 1. buat KeycapsSelected jadi Keycaps

        if (GameObject.FindGameObjectWithTag("Keycaps") == null)
        {
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsParent).gameObject.SetActive(true);
            buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
            buttonHideKeycaps.onClick.RemoveAllListeners();
            buttonHideKeycaps.onClick.AddListener(HideKeycaps);
        } // 1.5. Kalau misal keycaps yang mau dirubah, tersembunyi: buat btn HideKeycapsIcon kembali semula, lalu setactive true semua keycaps

        Material[][] keycapsMaterial = new Material[GameObject.FindGameObjectsWithTag("Keycaps").Length][];

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Keycaps").Length; i++)
        {
            keycapsMaterial[i] = GameObject.Find(GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name).transform.GetChild(i).GetComponent<Renderer>().materials;
            keycapsMaterial[i][0] = GameObject.Find(GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name).transform.GetChild(i).GetComponent<Renderer>().materials[0];
            if (GameObject.Find(GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name).transform.GetChild(i).GetComponent<Renderer>().materials.Length > 1)
                keycapsMaterial[i][1] = GameObject.Find(GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name).transform.GetChild(i).GetComponent<Renderer>().materials[1];
        } // 2. Ambil material dari Keycaps saat ini

        if (GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name == "Cherry Keycaps")
        {
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).gameObject.SetActive(true);
        } // 3.1. Pengecekan jika parent keycap adalah Cherry Keycaps

        else if (GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name == "SA Keycaps")
        {
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).gameObject.SetActive(false);
        } // 3.2. Pengecekan jika parent keycap adalah SA Keycaps

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Keycaps").Length; i++)
        {
            GameObject.Find(GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name).transform.GetChild(i).GetComponent<Renderer>().materials = keycapsMaterial[i];
        } // 4. Taruh material dari keycaps sebelumnya ke keycaps saat ini
    }

    //public void ChangeKeycapProfile() // test
    //{
    //GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
    //    foreach (GameObject otherSelectedKeycap in otherSelectedKeycaps)
    //    {
    //        Behaviour oskHalo = (Behaviour)otherSelectedKeycap.GetComponent("Halo");
    //oskHalo.enabled = false;
    //        otherSelectedKeycap.tag = "Keycaps";
    //    } // 1. buat KeycapsSelected jadi Keycaps

    //    if (GameObject.FindGameObjectWithTag("Keycaps") == null)
    //    {
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsParent).gameObject.SetActive(true);
    //        buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
    //        buttonHideKeycaps.onClick.RemoveAllListeners();
    //        buttonHideKeycaps.onClick.AddListener(HideKeycaps);
    //    } // 1.5. Kalau misal keycaps yang mau dirubah, tersembunyi: buat btn HideKeycapsIcon kembali semula, lalu setactive true semua keycaps

    //    string keycapsProfile = GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name;
    //    if (keycapsProfile == "Cherry Keycaps")
    //    {
    //        GameObject[] currentMaterial = new GameObject[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).childCount];
    //        for (int i = 0; i < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).childCount; i++)
    //        {
    //            for (int j = 0; j < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<Renderer>().materials.Length; j++)
    //            {
    //                currentMaterial[i].GetComponent<Renderer>().materials[j] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<Renderer>().materials[j];
    //            }
    //        }
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).gameObject.SetActive(false);
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).gameObject.SetActive(true);
    //        for (int i = 0; i < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).childCount; i++)
    //        {
    //            for (int j = 0; j < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<Renderer>().materials.Length; j++)
    //            {
    //                GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<Renderer>().materials[j] = currentMaterial[i].GetComponent<Renderer>().materials[j];
    //            }
    //        }
    //    }
    //    else if (keycapsProfile == "SA Keycaps")
    //    {
    //        GameObject[] currentMaterial = new GameObject[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).childCount];
    //        for (int i = 0; i < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).childCount; i++)
    //        {
    //            for (int j = 0; j < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<Renderer>().materials.Length; j++)
    //            {
    //                currentMaterial[i].GetComponent<Renderer>().materials[j] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<Renderer>().materials[j];
    //            }
    //        }
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).gameObject.SetActive(true);
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).gameObject.SetActive(false);
    //        for (int i = 0; i < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).childCount; i++)
    //        {
    //            for (int j = 0; j < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<Renderer>().materials.Length; j++)
    //            {
    //                GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<Renderer>().materials[j] = currentMaterial[i].GetComponent<Renderer>().materials[j];
    //            }
    //        }
    //    }
    //}

    // kalau tidak ketemu, ambil dari variable keycaps parent
    // 1. dicari dulu dari nama var, lalu diaktifkan
    // 2. baru ambil material dsb

    // 1. ambil material setiap keycap
    // 2. nonaktifkan keycap saat ini
    // 3. aktifkan keycap lawan
    // 4. foreach
    // 5. button icon diganti
    //public void ChangeKeycapProfile() // masih bug
    //{
    //GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
    //    foreach(GameObject otherSelectedKeycap in otherSelectedKeycaps)
    //    {
    //        Behaviour oskHalo = (Behaviour)otherSelectedKeycap.GetComponent("Halo");
    //oskHalo.enabled = false;
    //        otherSelectedKeycap.tag = "Keycaps";
    //    } // 1. buat KeycapsSelected jadi Keycaps

    //    if (GameObject.FindGameObjectWithTag("Keycaps") == null)
    //    {
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsParent).gameObject.SetActive(true);
    //        buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
    //        buttonHideKeycaps.onClick.RemoveAllListeners();
    //        buttonHideKeycaps.onClick.AddListener(HideKeycaps);
    //    } // 1.5. Kalau misal keycaps yang mau dirubah, tersembunyi: buat btn HideKeycapsIcon kembali semula, lalu setactive true semua keycaps

    //    GameObject[] targetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
    //    string keycapsProfile = GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name;

    //    //Material[][] keyMats = new Material[targetKeycaps.Length][];
    //    string[][] keyMats = new string[targetKeycaps.Length][];
    //    for (int i = 0; i < targetKeycaps.Length; i++)
    //    {
    //        //keyMats[i] = new Material[targetKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //        keyMats[i] = new string[targetKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //        if (keyMats[i].Length > 1)
    //        {
    //            for (int j = 0; j < keyMats[i].Length; j++)
    //            {
    //                keyMats[i][j] = targetKeycaps[i].GetComponent<MeshRenderer>().materials[j].color.ToString().Remove(targetKeycaps[i].GetComponent<MeshRenderer>().materials[j].color.ToString().Length - 1, 1).Remove(0, 5); ;
    //            }
    //        }
    //        else if (keyMats[i].Length < 2)
    //        {
    //            keyMats[i][0] = targetKeycaps[i].GetComponent<MeshRenderer>().material.color.ToString().Remove(targetKeycaps[i].GetComponent<MeshRenderer>().material.color.ToString().Length - 1, 1).Remove(0, 5); ;
    //        }
    //        //for (int j = 0; j < keyMats[i].Length; j++)
    //        //{
    //        //    keyMats[i][j] = targetKeycaps[i].GetComponent<MeshRenderer>().materials[j];
    //        //}
    //    }


    //    //GameObject[] keycapsMaterials = new GameObject[targetKeycaps.Length];
    //    //for (int i = 0; i < targetKeycaps.Length; i++)
    //    //{
    //    //    keycapsMaterials[i] = targetKeycaps[i];
    //    //}

    //    if (keycapsProfile == "Cherry Keycaps")
    //    {
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsProfile).gameObject.SetActive(false);
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find("SA Keycaps").gameObject.SetActive(true);
    //        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change SA Keycap Profile Icon");
    //    }
    //    else if (keycapsProfile == "SA Keycaps")
    //    {
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsProfile).gameObject.SetActive(false);
    //        GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find("Cherry Keycaps").gameObject.SetActive(true);
    //        GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change Cherry Keycap Profile Icon");
    //    }

    //    GameObject[] newTargetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
    //    //for (int i = 0; i < newTargetKeycaps.Length; i++)
    //    //{
    //    //    //Debug.Log(keycapsMaterials[i].name); // JALAN
    //    //    //if ((newTargetKeycaps[i].transform.position.x == keycapsMaterials[i].transform.position.x) && (newTargetKeycaps[i].transform.position.z == keycapsMaterials[i].transform.position.z))
    //    //    //{
    //    //    //    for (int j = 0; j < newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length; j++)
    //    //    //    {
    //    //    //        newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j] = keycapsMaterials[i].GetComponent<MeshRenderer>().materials[j];
    //    //    //    }
    //    //    //}
    //    //    for (int j = 0; j < keycapsMaterials.Length; j++)
    //    //    {
    //    //        if ((newTargetKeycaps[i].transform.position.x != keycapsMaterials[i].transform.position.x) || (newTargetKeycaps[i].transform.position.z != keycapsMaterials[i].transform.position.z))
    //    //            //Debug.LogError("Keycaps didn't match. " + keycapsMaterials[j].name);
    //    //            return;
    //    //        for (int k = 0; k < newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length; k++)
    //    //            newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[k] = keycapsMaterials[j].GetComponent<MeshRenderer>().materials[k];
    //    //    }
    //    //}


    //    for (int i = 0; i < newTargetKeycaps.Length; i++)
    //    {
    //        if (newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
    //        {
    //            for (int j = 0; j < newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length; j++)
    //            {
    //                Debug.Log(newTargetKeycaps[i].name);
    //                Debug.Log(keyMats[i][j]); // bermasalah di shift_1 bagian cherry
    //                string[] new_color = keyMats[i][j].Split(',');
    //                newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j].color = new Color(float.Parse(new_color[0]), float.Parse(new_color[1]), float.Parse(new_color[2]), float.Parse(new_color[3]));
    //            }
    //        }
    //        else if (newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length == 1)
    //        {
    //            string[] new_color = keyMats[i][0].Split(',');
    //            newTargetKeycaps[i].GetComponent<MeshRenderer>().material.color = new Color(float.Parse(new_color[0]), float.Parse(new_color[1]), float.Parse(new_color[2]), float.Parse(new_color[3]));
    //        }
    //        //for (int j = 0; j < keyMats[i].Length; j++)
    //        ////for (int j = 0; j < keycapsMaterials.Length; j++)
    //        //{
    //        //    //Debug.Log("I-" + i + " & J-" + j);
    //        //    //Debug.Log(newTargetKeycaps[i].name + " & " + newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j].name);
    //        //    //if (newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length < 2)
    //        //    //{
    //        //    //    newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j].color = keyMats[i][j].color;
    //        //    //    j++;
    //        //    //}
    //        //    //else
    //        //    //    newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j].color = keyMats[i][j].color; // Keycap Spacebar Error: Array index is out of range
    //        //    //if ((newTargetKeycaps[i].transform.position.x == keycapsMaterials[j].transform.position.x) && (newTargetKeycaps[i].transform.position.z == keycapsMaterials[j].transform.position.z))
    //        //    //{
    //        //    //    for (int k = 0; k < newTargetKeycaps[i].GetComponent<MeshRenderer>().materials.Length; k++)
    //        //    //    {
    //        //    //        newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[k] = keycapsMaterials[j].GetComponent<MeshRenderer>().materials[k];
    //        //    //    }
    //        //    //}
    //        //    //else if ((newTargetKeycaps[i].transform.position.x != keycapsMaterials[j].transform.position.x) && (newTargetKeycaps[i].transform.position.z != keycapsMaterials[j].transform.position.z))
    //        //    //{
    //        //    //    j++;
    //        //    //}
    //        //}
    //    }
    //}

    void HidePropCKC()
    {
        canvasProperties.GetComponent<CanvasGroup>().alpha = 0f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().alpha = 1f;
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void UnHidePropCKC()
    {
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().alpha = 0f;
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvasProperties.GetComponent<CanvasGroup>().alpha = 1f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void UnHideCPSelect()
    {
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().alpha = 1f;
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().blocksRaycasts = true;
        canvasColorPalette.GetComponent<CanvasGroup>().alpha = 0f;
        canvasColorPalette.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void HidePropCS()
    {
        canvasProperties.GetComponent<CanvasGroup>().alpha = 0f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvasSwitchesSelection.GetComponent<CanvasGroup>().alpha = 1f;
        canvasSwitchesSelection.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void UnHidePropCS()
    {
        canvasSwitchesSelection.GetComponent<CanvasGroup>().alpha = 0f;
        canvasSwitchesSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvasProperties.GetComponent<CanvasGroup>().alpha = 1f;
        canvasProperties.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void UnHideSwitchesBrand()
    {
        canvasSwitchesSelection.GetComponent<CanvasGroup>().alpha = 1f;
        canvasSwitchesSelection.GetComponent<CanvasGroup>().blocksRaycasts = true;
        canvasSwitchesCP.GetComponent<CanvasGroup>().alpha = 0f;
        canvasSwitchesCP.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void HideMenuCanvas()
    {
        if (GameObject.FindGameObjectWithTag("KeycapsSelected"))
        {
            GameObject[] keycapsSelected = GameObject.FindGameObjectsWithTag("KeycapsSelected");
            foreach (GameObject keycapSelected in keycapsSelected)
            {
                Behaviour ksHalo = (Behaviour)keycapSelected.GetComponent("Halo");
                ksHalo.enabled = false;
                keycapSelected.tag = "Keycaps";
            }
        }

        GameObject.Find("Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;

        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().alpha = 1f;
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void UnHideMenuCanvas()
    {
        GameObject.Find("Canvas").GetComponent<CanvasGroup>().alpha = 1f;
        GameObject.Find("Canvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
