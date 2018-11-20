using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideObject : MonoBehaviour
{
    public Canvas canvasFile, canvasCreate, canvasProperties, canvasColorPaletteSelection, canvasColorPalette, canvasSwitchesSelection;
    public Button buttonFileProject, buttonChangeProfileKeycaps, buttonSaveProject, buttonHideKeycaps, buttonHideSwitches, buttonChangeKeycapsColor, buttonChangeSwitches,
        buttonCreate, buttonProperties, buttonCloseFile, buttonCloseCreate, buttonCloseProperties, buttonCloseChangeKeycapsColor,
        buttonCloseColorPalette, buttonCloseChangeSwitches;
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

        //canvasSaveLoadMenu.GetComponent<CanvasGroup>().alpha = 0f;
        //canvasSaveLoadMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

        // After hide some object, add listener to each button
        buttonFileProject.onClick.AddListener(OpenFileMenu);
        buttonChangeProfileKeycaps.onClick.AddListener(ChangeKeycapProfile);

        buttonCreate.onClick.AddListener(OpenCreateMenu);
        buttonProperties.onClick.AddListener(OpenPropertiesMenu);

        buttonHideKeycaps.onClick.AddListener(HideKeycaps);
        buttonHideSwitches.onClick.AddListener(HideSwitches);
        buttonChangeKeycapsColor.onClick.AddListener(HidePropCKC);
        buttonChangeSwitches.onClick.AddListener(HidePropCS);

        buttonCloseFile.onClick.AddListener(CloseFileMenu);
        buttonCloseCreate.onClick.AddListener(CloseCreateMenu);
        buttonCloseProperties.onClick.AddListener(ClosePropertiesMenu);
        buttonCloseChangeKeycapsColor.onClick.AddListener(UnHidePropCKC);
        buttonCloseColorPalette.onClick.AddListener(UnHideCPSelect);
        buttonCloseChangeSwitches.onClick.AddListener(UnHidePropCS);
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
        canvasFile.GetComponent<CanvasGroup>().alpha = 1f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void CloseFileMenu()
    {
        canvasFile.GetComponent<CanvasGroup>().alpha = 0f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = false;
        buttonFileProject.gameObject.SetActive(true);
        buttonChangeProfileKeycaps.gameObject.SetActive(true);
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
        buttonSaveProject.interactable = false;
        buttonHideKeycaps.interactable = false;
        buttonHideSwitches.interactable = false;
        buttonChangeKeycapsColor.interactable = false;

        if (mechanicalKeyboards == null)
            return;
        else if (mechanicalKeyboards != null)
        {
            buttonChangeProfileKeycaps.interactable = true;
            buttonSaveProject.interactable = true;
            buttonHideKeycaps.interactable = true;
            buttonHideSwitches.interactable = true;
            buttonChangeKeycapsColor.interactable = true;
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

    // kalau tidak ketemu, ambil dari variable keycaps parent
    // 1. dicari dulu dari nama var, lalu diaktifkan
    // 2. baru ambil material dsb

    // 1. ambil material setiap keycap
    // 2. nonaktifkan keycap saat ini
    // 3. aktifkan keycap lawan
    // 4. foreach
    // 5. button icon diganti
    public void ChangeKeycapProfile()
    {
        GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        foreach(GameObject otherSelectedKeycap in otherSelectedKeycaps)
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

        GameObject[] targetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        string keycapsProfile = GameObject.FindGameObjectWithTag("Keycaps").transform.parent.name;
        Material[][] keyMats = new Material[targetKeycaps.Length][];
        for (int i = 0; i < targetKeycaps.Length; i++)
        {
            keyMats[i] = new Material[targetKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
            for (int j = 0; j < keyMats[i].Length; j++)
            {
                keyMats[i][j] = targetKeycaps[i].GetComponent<MeshRenderer>().materials[j];
            }
        }

        if (keycapsProfile == "Cherry Keycaps")
        {
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsProfile).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find("SA Keycaps").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change SA Keycap Profile Icon");
        }
        else if (keycapsProfile == "SA Keycaps")
        {
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find(keycapsProfile).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.Find("Cherry Keycaps").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Change Profile Keycap Button").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Change Cherry Keycap Profile Icon");
        }

        GameObject[] newTargetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        for (int i = 0; i < newTargetKeycaps.Length; i++)
        {
            for (int j = 0; j < keyMats[i].Length; j++)
            {
                //Debug.Log("I-" + i + " & J-" + j);
                //Debug.Log(newTargetKeycaps[i].name + " & " + newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j].name);
                newTargetKeycaps[i].GetComponent<MeshRenderer>().materials[j].color = keyMats[i][j].color; // Keycap Spacebar Error: Array index is out of range
            }
        }
    }

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
}
