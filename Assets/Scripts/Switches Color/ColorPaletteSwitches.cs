using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPaletteSwitches : MonoBehaviour {

    public Button buttonCherryMX, buttonGateron, buttonApply;
    public Canvas canvasSwitchesBrandSelection, canvasCPSwitches;
    public GameObject imageSwitchesBrand;
    public Dropdown switchesColorPalette;
    private List<string> cherryMXOptions = new List<string> { "MX Black", "MX Blue", "MX Green", "MX RGB Black", "MX RGB Blue", "MX RGB Green" };
    private List<string> gateronOptions = new List<string> { "Gateron Black", "Gateron Blue", "Gateron Green" };

    // Use this for initialization
    void Start () {

        //buttonGMK.onClick.AddListener(delegate { callCP(positionLR, cpGMKUniqey, textGMK); });
        buttonCherryMX.onClick.AddListener(delegate { callCP("Cherry MX Long Icon"); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void callCP(string title)
    {
        canvasSwitchesBrandSelection.GetComponent<CanvasGroup>().alpha = 0f;
        canvasSwitchesBrandSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvasCPSwitches.GetComponent<CanvasGroup>().alpha = 1f;
        canvasCPSwitches.GetComponent<CanvasGroup>().blocksRaycasts = true;

        imageSwitchesBrand.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + title);

        switchesColorPalette.GetComponent<Dropdown>().ClearOptions(); // Object reference not set to an instance of an object

        if (title == "Cherry MX Long Icon")
            switchesColorPalette.AddOptions(cherryMXOptions);
        else if (title == "Gateron Long Icon")
            switchesColorPalette.AddOptions(gateronOptions);

        buttonApply.onClick.AddListener(applyColor);
    }

    void applyColor()
    {
        string[] newColor = switchesColorPalette.options[switchesColorPalette.value].text.Split(' ');
        GameObject[] switches = GameObject.FindGameObjectsWithTag("Switches");
        if (switchesColorPalette.options[switchesColorPalette.value].text.Contains("MX"))
        {
            for (int i = 0; i < switches.Length; i++)
            {
                Material[] newMaterial = switches[i].GetComponent<MeshRenderer>().materials;
                if (switchesColorPalette.options[switchesColorPalette.value].text.Contains("RGB"))
                { 
                    newMaterial[0] = Resources.Load<Material>("Materials/Switches/Switch Case (Transparent)");
                    newMaterial[1] = Resources.Load<Material>("Materials/Switches/" + newColor[2]);
                    newMaterial[2] = Resources.Load<Material>("Materials/Switches/Pin");
                }
                else if (!switchesColorPalette.options[switchesColorPalette.value].text.Contains("RGB"))
                { 
                    newMaterial[0] = Resources.Load<Material>("Materials/Switches/Switch Case (Normal)");
                    newMaterial[1] = Resources.Load<Material>("Materials/Switches/" + newColor[1]);
                    newMaterial[2] = Resources.Load<Material>("Materials/Switches/Pin");
                }
                switches[i].GetComponent<MeshRenderer>().materials = newMaterial;
            }
        }
        else if (switchesColorPalette.options[switchesColorPalette.value].text.Contains("Gateron"))
        {
            for (int i = 0; i < switches.Length; i++)
            {
                Material[] newMaterial = switches[i].GetComponent<MeshRenderer>().materials;
                newMaterial[0] = Resources.Load<Material>("Materials/Switches/Switch Case (Milky)");
                newMaterial[1] = Resources.Load<Material>("Materials/Switches/" + newColor[1]);
                newMaterial[2] = Resources.Load<Material>("Materials/Switches/Pin");
                switches[i].GetComponent<MeshRenderer>().materials = newMaterial;
            }
        }
    }
}