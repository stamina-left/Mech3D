using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorPrefab : MonoBehaviour {

    // Use this for initialization
    public GameObject buttonColorPrefab, textCPTitle;
    public Button buttonGMK, buttonSPABS, buttonSPPBT, buttonWASD, buttonReverseColor;
    public GameObject panelColorPalette, imageColorBrand;
    public Canvas canvasColorPalette, canvasColorPaletteSelection;
    private Material[] cpGMKUniqey, cpSPABS, cpSPPBT, cpWASD;

	void Start () {

        cpGMKUniqey = Resources.LoadAll<Material>("Materials/GMK Uniqey Color");
        cpSPABS = Resources.LoadAll<Material>("Materials/Signature Plastics ABS");
        cpSPPBT = Resources.LoadAll<Material>("Materials/Signature Plastics PBT");
        cpWASD = Resources.LoadAll<Material>("Materials/WASD Keyboards");

        // nama asset icon panjang
        string textGMK = "GMK Long Icon";
        string textSPABS = "Signature Plastics ABS Long Icon";
        string textSPPBT = "Signature Plastics PBT Long Icon";
        string textWASD = "WASDKeyboards Long Icon";

        int positionLR = 0; // start from left -> middle -> right

        buttonGMK.onClick.AddListener(delegate { callCP(positionLR, cpGMKUniqey, textGMK); });
        buttonSPABS.onClick.AddListener(delegate { callCP(positionLR, cpSPABS, textSPABS); });
        buttonSPPBT.onClick.AddListener(delegate { callCP(positionLR, cpSPPBT, textSPPBT); });
        buttonWASD.onClick.AddListener(delegate { callCP(positionLR, cpWASD, textWASD); });
        buttonReverseColor.onClick.AddListener(reverseColor);
    }

    // Update is called once per frame
    void Update () {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.A)) // ON PROGRESS
        {
            Debug.Log("Control and Type A is clicked.");
            
            //if (GameObject.Find("Keycaps").activeSelf) // if keycaps aren't hiding.
            if (GameObject.FindGameObjectsWithTag("Keycaps") != null) // if keycaps aren't hiding
            {
                GameObject[] otherKeycapsTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
                foreach (GameObject otherKeycapTarget in otherKeycapsTarget)
                {
                    Behaviour oktHalo = (Behaviour)otherKeycapTarget.GetComponent("Halo");
                    oktHalo.enabled = false;
                    otherKeycapTarget.tag = "Keycaps";
                }
                //int keycapsCount = GameObject.Find("Keycaps").transform.childCount;
                GameObject[] keycapsTarget = GameObject.FindGameObjectsWithTag("Keycaps");
                //for (int i = 0; i < keycapsCount; i++)
                for (int i = 0; i < keycapsTarget.Length; i++)
                {
                    //Debug.Log("Selected " + GameObject.Find("Keycaps").transform.GetChild(i).name);
                    //Behaviour eachHalosKeycaps = (Behaviour)GameObject.Find("Keycaps").transform.GetChild(i).GetComponent("Halo");
                    Behaviour eachHalosKeycaps = (Behaviour)keycapsTarget[i].GetComponent("Halo");
                    //Component eachHalosKeycaps = GameObject.Find("Keycaps").transform.GetChild(i).GetComponent("Halo");
                    //if (GameObject.Find("Keycaps").transform.GetChild(i).tag == "Keycaps")
                    //{
                    //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, true, null);
                    //    GameObject.Find("Keycaps").transform.GetChild(i).tag = "KeycapsSelected";
                    //}
                    //else if (GameObject.Find("Keycaps").transform.GetChild(i).tag == "KeycapsSelected")
                    //{
                    //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, false, null);
                    //    GameObject.Find("Keycaps").transform.GetChild(i).tag = "Keycaps";
                    //}
                    //if (keycapsTarget[i].tag == "Keycaps")
                    //{
                    //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, true, null);
                    //    keycapsTarget[i].tag = "KeycapsSelected";
                    //}
                    //else if (keycapsTarget[i].tag == "KeycapsSelected")
                    //{
                    //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, false, null);
                    //    keycapsTarget[i].tag = "Keycaps";
                    //}
                    eachHalosKeycaps.enabled = true;
                    keycapsTarget[i].tag = "KeycapsSelected";
                }
            }
            if (GameObject.FindGameObjectsWithTag("KeycapsSelected") != null)
            {
                GameObject[] keycapsTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
                foreach (GameObject keycapTarget in keycapsTarget)
                {
                    Behaviour ktHalo = (Behaviour)keycapTarget.GetComponent("Halo");
                    ktHalo.enabled = false;
                    keycapTarget.tag = "Keycaps";
                }
            }
            if (GameObject.Find("Switches").activeSelf) // if switches aren't hiding.
            {
                int switchesCount = GameObject.Find("Switches").transform.childCount;
                for (int i = 0; i < switchesCount; i++)
                {
                    Behaviour eachHalosSwitches = (Behaviour)GameObject.Find("Switches").transform.GetChild(i).GetComponent("Halo");
                    if (GameObject.Find("Switches").transform.GetChild(i).tag == "SwitchesSelected")
                    {
                        eachHalosSwitches.enabled = false;
                        GameObject.Find("Switches").transform.GetChild(i).tag = "Switches";
                    }
                    else if (GameObject.Find("Switches").transform.GetChild(i).tag == "Switches")
                    {
                        eachHalosSwitches.enabled = true;
                        GameObject.Find("Switches").transform.GetChild(i).tag = "SwitchesSelected";
                    }
                }
            }
            if (GameObject.Find("Case").activeSelf) // if keyboard case aren't hiding.
            {
                //Behaviour haloCase = (Behaviour)GameObject.Find("Case").GetComponent("Halo");
                if(GameObject.Find("Case").tag == "CaseSelected")
                {
                    //haloCase.enabled = false;
                    GameObject.Find("Case").tag = "Case";
                }
                else if(GameObject.Find("Case").tag == "Case")
                {
                    //haloCase.enabled = true;
                    GameObject.Find("Case").tag = "CaseSelected";
                }
            }
        }
        else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetMouseButtonDown(0)) // ON PROGRESS
        {
            //
            Debug.Log("Left mouse button and control button is clicked.");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //if (hit)
            //{
            //    Debug.Log(hitInfo.transform.tag);
            //    Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
            //    if (hitInfo.transform.tag == "Keycaps")
            //    {
            //        Debug.Log("You just clicked " + hitInfo.transform.name);
                    
            //        //if (hitInfo.transform.gameObject.tag == "Keycaps")
            //        //{
            //            hitInfo.transform.gameObject.tag = "KeycapsSelected";
            //            hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, true, null);
            //        //}
            //        //else if (hitInfo.transform.gameObject.tag == "KeycapsSelected")
            //        //{
            //        //    hitInfo.transform.gameObject.tag = "Keycaps";
            //        //    hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
            //        //}
            //    }
            //    else if (hitInfo.transform.tag == "KeycapsSeleted")
            //    {
            //        Debug.Log("You just clicked " + hitInfo.transform.name);

            //        hitInfo.transform.gameObject.tag = "Keycaps";
            //        hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
            //    }

            //    // ERROR: Click di objek yang sama, masuk ke sini
            //    //else if (hitInfo.transform.gameObject.tag != "Keycaps" || hitInfo.transform.gameObject.tag != "KeycapsSelected")
            //    //{
            //    //    Debug.Log("You just clicked another object. It's a " + hitInfo.transform.gameObject.tag);
            //    //}
            //}
            if (hit && hitInfo.transform.tag == "Keycaps")
            {
                Debug.Log(hitInfo.transform.tag);
                Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
                hitInfo.transform.tag = "KeycapsSelected";
                hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, true, null);
            }
            else if (hit && hitInfo.transform.tag == "KeycapsSelected")
            {
                Debug.Log(hitInfo.transform.tag);
                Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
                hitInfo.transform.tag = "Keycaps";
                hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
            }
            else
            {
                Debug.Log("You didn't touch anything.");
            }
        }
        else if (Input.GetMouseButtonDown(0)) // ON PROGRESS
        {
            Debug.Log("Left mouse button is clicked.");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //if (hit)
            //{
            //    if (hitInfo.transform.gameObject.tag == "Keycaps" || hitInfo.transform.gameObject.tag == "KeycapsSelected")
            //    {
            //        GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
            //        foreach (GameObject otherKeycap in otherKeycaps)
            //        {
            //            //Behaviour hitOtherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
            //            //hitOtherHalo.enabled = false;
            //            otherKeycap.tag = "Keycaps";
            //        }

            //        GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
            //        foreach (GameObject selectedKeycaps in otherSelectedKeycaps)
            //        {
            //            selectedKeycaps.tag = "Keycaps";
            //        }

            //        Debug.Log("You just clicked " + hitInfo.transform.name);
            //        //Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
            //        if (hitInfo.transform.gameObject.tag == "Keycaps")
            //        {
            //            hitInfo.transform.gameObject.tag = "KeycapsSelected";
            //            //hitHalo.enabled = true;
            //        }
            //        else if (hitInfo.transform.gameObject.tag == "KeycapsSelected")
            //        {
            //            hitInfo.transform.gameObject.tag = "Keycaps";
            //            //hitHalo.enabled = false;
            //        }
            //    }
            //    else if (hitInfo.transform.gameObject.tag == "Switches" || hitInfo.transform.gameObject.tag == "SwitchesSelected")
            //    {
            //        GameObject[] otherSwitches = GameObject.FindGameObjectsWithTag("Switches");
            //        foreach (GameObject otherSwitch in otherSwitches)
            //        {
            //            otherSwitch.tag = "Switches";
            //        }

            //        GameObject[] otherSelectedSwitches = GameObject.FindGameObjectsWithTag("SwitchesSelected");
            //        foreach (GameObject selectedSwitches in otherSelectedSwitches)
            //        {
            //            selectedSwitches.tag = "Switches";
            //        }

            //        Debug.Log("You just clicked a switch.");

            //        if (hitInfo.transform.gameObject.tag == "Switches")
            //        {
            //            hitInfo.transform.gameObject.tag = "SwitchesSelected";
            //        }
            //        else if (hitInfo.transform.gameObject.tag == "SwitchesSelected")
            //        {
            //            hitInfo.transform.gameObject.tag = "Switches";
            //        }
            //    }
            //    else if (hitInfo.transform.gameObject.tag == "Case" || hitInfo.transform.gameObject.tag == "CaseSelected")
            //    {
            //        if (hitInfo.transform.gameObject.tag == "Case")
            //            hitInfo.transform.gameObject.tag = "CaseSelected";
            //        else if (hitInfo.transform.gameObject.tag == "CaseSelected")
            //            hitInfo.transform.gameObject.tag = "Case";
            //    }
            //    else
            //    {
            //        Debug.Log("You just clicked another object. It's a " + hitInfo.transform.gameObject.name);
            //    }
            //}
            if (hit && hitInfo.transform.tag == "Keycaps")
            {
                GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
                foreach (GameObject otherKeycap in otherKeycaps)
                {
                    Debug.Log("Keycaps lain yang terpilih, sudah tidak terpilih lagi.");
                    Behaviour otherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
                    otherHalo.enabled = false;
                    otherKeycap.tag = "Keycaps";
                }

                Debug.Log("You just clicked " + hitInfo.transform.name);
                Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
                hitInfo.transform.tag = "KeycapsSelected";
                hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, true, null);
            }
            else if (hit && hitInfo.transform.tag == "KeycapsSelected")
            {
                GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
                foreach (GameObject otherKeycap in otherKeycaps)
                {
                    Debug.Log("Keycaps lain yang terpilih, sudah tidak terpilih lagi.");
                    Behaviour otherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
                    otherHalo.enabled = false;
                    otherKeycap.tag = "Keycaps";
                }

                Debug.Log("You just clicked " + hitInfo.transform.name);
                Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
                hitInfo.transform.tag = "Keycaps";
                hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
            }
            else if (!hit)
            {
                Debug.Log("You didn't touch anything.");
                //GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
                //foreach (GameObject otherKeycap in otherKeycaps)
                //{
                //    Behaviour hitOtherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
                //    hitOtherHalo.enabled = false;
                //}
            }
        }
    }

    void callCP(int positionLR, Material[] matCP, string title)
    {
        // sembunyikan menu sebelumnya
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().alpha = 0f;
        canvasColorPaletteSelection.GetComponent<CanvasGroup>().blocksRaycasts = false;

        // muncul pilihan gambar
        canvasColorPalette.GetComponent<CanvasGroup>().alpha = 1f;
        canvasColorPalette.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //canvasColorPalette.transform.Find("Color Title").GetComponent<Text>().text = title;
        imageColorBrand.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + title);
        Debug.Log(imageColorBrand.gameObject.GetComponent<Image>().sprite.name);

        Vector3 buttonPosition = new Vector3(0, 0);

        if(matCP != null)
        {
            foreach (Material colorPalette in matCP)
            {
                Button colorButton;
                colorButton = ((GameObject)Object.Instantiate(buttonColorPrefab, buttonPosition, buttonColorPrefab.transform.rotation)).GetComponent<Button>();
                colorButton.onClick.AddListener(delegate { setColor(colorButton, colorPalette); });

                colorButton.GetComponent<Image>().color = colorPalette.color;
                colorButton.GetComponentInChildren<Text>().text = colorPalette.name;

                RectTransform colorButtonTransform = colorButton.gameObject.transform as RectTransform;
                colorButton.transform.SetParent(panelColorPalette.transform, false);

                if (buttonPosition.x < 720)
                    buttonPosition.x += 90;
                else if (buttonPosition.x >= 720)
                {
                    buttonPosition.y -= 45;
                    buttonPosition.x = 0;
                }
            }
        }
    }

    void reverseColor()
    {
        GameObject[] allKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        Color materialOne, materialTwo;
        foreach (GameObject eachKeycap in allKeycaps)
        {
            materialOne = eachKeycap.GetComponent<MeshRenderer>().materials[0].color; // outer
            materialTwo = eachKeycap.GetComponent<MeshRenderer>().materials[1].color; // font

            eachKeycap.GetComponent<MeshRenderer>().materials[0].color = materialTwo;
            eachKeycap.GetComponent<MeshRenderer>().materials[1].color = materialOne;
        }
    }

    void setColor(Button btnSet, Material matSet)
    {
        //
        GameObject[] allKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        foreach (GameObject eachKeycap in allKeycaps)
        {
            //if((Behaviour)eachKeycap.GetComponent("Halo") != null)
            eachKeycap.GetComponent<MeshRenderer>().materials[0].color = matSet.color;
        }
    }
}
