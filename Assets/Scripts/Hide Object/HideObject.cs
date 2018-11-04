using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideObject : MonoBehaviour
{
    public Canvas canvasFile, canvasCreate, canvasProperties, canvasColorPaletteSelection, canvasColorPalette, canvasSwitchesSelection, 
        canvasSaveLoadMenu;
    public Button buttonFileProject, buttonSaveProject, buttonHideKeycaps, buttonHideSwitches, buttonChangeKeycapsColor, buttonChangeSwitches,
        buttonCreate, buttonProperties, buttonCloseFile, buttonCloseCreate, buttonCloseProperties, buttonCloseChangeKeycapsColor,
        buttonCloseColorPalette, buttonCloseChangeSwitches;
    private GameObject mechanicalKeyboards;
    private GameObject[] buttonCreateMenu, buttonPropertiesMenu;
    private Transform keycaps, switches;

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

        canvasSaveLoadMenu.GetComponent<CanvasGroup>().alpha = 0f;
        canvasSaveLoadMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

        // After hide some object, add listener to each button
        buttonFileProject.onClick.AddListener(OpenFileMenu);

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
        canvasFile.GetComponent<CanvasGroup>().alpha = 1f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void CloseFileMenu()
    {
        canvasFile.GetComponent<CanvasGroup>().alpha = 0f;
        canvasFile.GetComponent<CanvasGroup>().blocksRaycasts = false;
        buttonFileProject.gameObject.SetActive(true);
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
        buttonSaveProject.interactable = false;
        buttonHideKeycaps.interactable = false;
        buttonHideSwitches.interactable = false;
        buttonChangeKeycapsColor.interactable = false;

        if (mechanicalKeyboards == null)
            return;
        else if (mechanicalKeyboards != null)
        {
            buttonSaveProject.interactable = true;
            buttonHideKeycaps.interactable = true;
            buttonHideSwitches.interactable = true;
            buttonChangeKeycapsColor.interactable = true;
        }
    }

    void HideKeycaps()
    {
        GameObject[] targetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        foreach(GameObject targetKeycap in targetKeycaps)
        {
            targetKeycap.GetComponent<MeshCollider>().enabled = false;
        }

        GameObject[] targetSwitches = GameObject.FindGameObjectsWithTag("Switches");
        foreach (GameObject targetSwitch in targetSwitches)
        {
            targetSwitch.GetComponent<MeshCollider>().enabled = true;
        }

        keycaps = mechanicalKeyboards.transform.Find("Keycaps");
        keycaps.gameObject.SetActive(false);
        //buttonHideKeycaps.GetComponentInChildren<Text>().text = "Unhide Keycaps";
        buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Unhide Keycaps Icon");
        buttonHideKeycaps.onClick.RemoveAllListeners();
        buttonHideKeycaps.onClick.AddListener(UnhideKeycaps);
    }

    void UnhideKeycaps()
    {

        GameObject[] targetSwitches = GameObject.FindGameObjectsWithTag("Switches");
        foreach (GameObject targetSwitch in targetSwitches)
        {
            targetSwitch.GetComponent<MeshCollider>().enabled = false;
        }

        GameObject[] targetKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        foreach(GameObject targetKeycap in targetKeycaps)
        {
            targetKeycap.GetComponent<MeshCollider>().enabled = true;
        }

        keycaps = mechanicalKeyboards.transform.Find("Keycaps");
        keycaps.gameObject.SetActive(true);
        //buttonHideKeycaps.GetComponentInChildren<Text>().text = "Hide Keycaps";
        buttonHideKeycaps.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Keycaps Icon");
        buttonHideKeycaps.onClick.RemoveAllListeners();
        buttonHideKeycaps.onClick.AddListener(HideKeycaps);
    }

    void HideSwitches()
    {
        switches = mechanicalKeyboards.transform.Find("Switches");
        switches.gameObject.SetActive(false);
        //buttonHideSwitches.GetComponentInChildren<Text>().text = "Unhide Switches";
        buttonHideSwitches.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Unhide Switches Icon");
        buttonHideSwitches.onClick.RemoveAllListeners();
        buttonHideSwitches.onClick.AddListener(UnhideSwitches);
    }

    void UnhideSwitches()
    {
        switches = mechanicalKeyboards.transform.Find("Switches");
        switches.gameObject.SetActive(true);
        //buttonHideSwitches.GetComponentInChildren<Text>().text = "Hide Switches";
        buttonHideSwitches.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Hide Switches Icon");
        buttonHideSwitches.onClick.RemoveAllListeners();
        buttonHideSwitches.onClick.AddListener(HideSwitches);
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
        canvasSwitchesSelection.GetComponent<CanvasGroup>().alpha = 0f;
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
