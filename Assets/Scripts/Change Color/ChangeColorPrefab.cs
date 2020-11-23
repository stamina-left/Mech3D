using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ChangeColorPrefab : MonoBehaviour {

    // Use this for initialization
    public GameObject buttonColorPrefab, textCPTitle;
    public Button buttonGMK, buttonSPABS, buttonSPPBT, buttonWASD, buttonReverseColor;
    public GameObject panelColorPalette, imageColorBrand;
    public Canvas canvasColorPalette, canvasColorPaletteSelection;
    private Material[] cpGMKUniqey, cpSPABS, cpSPPBT, cpWASD, cpAllKeycaps;

	void Start () {

        cpAllKeycaps = Resources.LoadAll<Material>("Materials");
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
        //if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.A)) // SUKSES
        //{
        //    Debug.Log("Control and Type A is clicked.");
        //    if (GameObject.FindWithTag("Keycaps") || (GameObject.FindWithTag("Keycaps") && GameObject.FindWithTag("KeycapsSelected")))
        //    {
        //        GameObject[] otherKeycapsTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        //        foreach (GameObject otherKeycapTarget in otherKeycapsTarget)
        //        {
        //            Behaviour oktHalo = (Behaviour)otherKeycapTarget.GetComponent("Halo");
        //            oktHalo.enabled = false;
        //            otherKeycapTarget.tag = "Keycaps";
        //        }
        //        GameObject[] keycapsTarget = GameObject.FindGameObjectsWithTag("Keycaps");
        //        foreach (GameObject keycapTarget in keycapsTarget)
        //        {
        //            Behaviour ktHalo = (Behaviour)keycapTarget.GetComponent("Halo");
        //            ktHalo.enabled = true;
        //            keycapTarget.tag = "KeycapsSelected";
        //        }
        //    }
        //    else if (GameObject.FindWithTag("KeycapsSelected"))
        //    {
        //        GameObject[] keycapsSelectedTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        //        foreach (GameObject keycapSelectedTarget in keycapsSelectedTarget)
        //        {
        //            Behaviour kstHalo = (Behaviour)keycapSelectedTarget.GetComponent("Halo");
        //            kstHalo.enabled = false;
        //            keycapSelectedTarget.tag = "Keycaps";
        //        }
        //        Debug.Log("No longer keycaps selected.");
        //    }
        //}
        ////if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.A)) // ON PROGRESS
        ////{
        ////    Debug.Log("Control and Type A is clicked.");
            
        ////    //if (GameObject.Find("Keycaps").activeSelf) // if keycaps aren't hiding.
        ////    if (GameObject.FindGameObjectsWithTag("Keycaps") != null || (GameObject.FindGameObjectsWithTag("Keycaps") != null && GameObject.FindGameObjectsWithTag("KeycapsSelected") != null)) // if keycaps aren't hiding
        ////    {
        ////        GameObject[] otherKeycapsTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        ////        foreach (GameObject otherKeycapTarget in otherKeycapsTarget)
        ////        {
        ////            Behaviour oktHalo = (Behaviour)otherKeycapTarget.GetComponent("Halo");
        ////            oktHalo.enabled = false;
        ////            otherKeycapTarget.tag = "Keycaps";
        ////        }
        ////        //int keycapsCount = GameObject.Find("Keycaps").transform.childCount;
        ////        GameObject[] keycapsTarget = GameObject.FindGameObjectsWithTag("Keycaps");
        ////        //for (int i = 0; i < keycapsCount; i++)
        ////        for (int i = 0; i < keycapsTarget.Length; i++)
        ////        {
        ////            //Debug.Log("Selected " + GameObject.Find("Keycaps").transform.GetChild(i).name);
        ////            //Behaviour eachHalosKeycaps = (Behaviour)GameObject.Find("Keycaps").transform.GetChild(i).GetComponent("Halo");
        ////            Behaviour eachHalosKeycaps = (Behaviour)keycapsTarget[i].GetComponent("Halo");
        ////            //Component eachHalosKeycaps = GameObject.Find("Keycaps").transform.GetChild(i).GetComponent("Halo");
        ////            //if (GameObject.Find("Keycaps").transform.GetChild(i).tag == "Keycaps")
        ////            //{
        ////            //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, true, null);
        ////            //    GameObject.Find("Keycaps").transform.GetChild(i).tag = "KeycapsSelected";
        ////            //}
        ////            //else if (GameObject.Find("Keycaps").transform.GetChild(i).tag == "KeycapsSelected")
        ////            //{
        ////            //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, false, null);
        ////            //    GameObject.Find("Keycaps").transform.GetChild(i).tag = "Keycaps";
        ////            //}
        ////            //if (keycapsTarget[i].tag == "Keycaps")
        ////            //{
        ////            //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, true, null);
        ////            //    keycapsTarget[i].tag = "KeycapsSelected";
        ////            //}
        ////            //else if (keycapsTarget[i].tag == "KeycapsSelected")
        ////            //{
        ////            //    eachHalosKeycaps.GetType().GetProperty("enabled").SetValue(eachHalosKeycaps, false, null);
        ////            //    keycapsTarget[i].tag = "Keycaps";
        ////            //}
        ////            eachHalosKeycaps.enabled = true;
        ////            keycapsTarget[i].tag = "KeycapsSelected";
        ////        }
        ////    }
        ////    else if (GameObject.FindGameObjectsWithTag("KeycapsSelected") != null && GameObject.FindGameObjectsWithTag("Keycaps") == null)
        ////    {
        ////        GameObject[] keycapsSelectedTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        ////        //foreach (GameObject keycapTarget in keycapsTarget)
        ////        //{
        ////        //    Behaviour ktHalo = (Behaviour)keycapTarget.GetComponent("Halo");
        ////        //    ktHalo.enabled = false;
        ////        //    keycapTarget.tag = "Keycaps";
        ////        //}
        ////        Debug.Log(keycapsSelectedTarget.Length); // TIDAK JALAN
        ////        for (int i = 0; i < keycapsSelectedTarget.Length; i++)
        ////        {
        ////            Behaviour ktHalo = (Behaviour)keycapsSelectedTarget[i].GetComponent("Halo");
        ////            ktHalo.enabled = false;
        ////            keycapsSelectedTarget[i].tag = "Keycaps";
        ////        }
        ////    }
        ////    //if (GameObject.Find("Switches").activeSelf) // if switches aren't hiding.
        ////    //{
        ////    //    int switchesCount = GameObject.Find("Switches").transform.childCount;
        ////    //    for (int i = 0; i < switchesCount; i++)
        ////    //    {
        ////    //        Behaviour eachHalosSwitches = (Behaviour)GameObject.Find("Switches").transform.GetChild(i).GetComponent("Halo");
        ////    //        if (GameObject.Find("Switches").transform.GetChild(i).tag == "SwitchesSelected")
        ////    //        {
        ////    //            eachHalosSwitches.enabled = false;
        ////    //            GameObject.Find("Switches").transform.GetChild(i).tag = "Switches";
        ////    //        }
        ////    //        else if (GameObject.Find("Switches").transform.GetChild(i).tag == "Switches")
        ////    //        {
        ////    //            eachHalosSwitches.enabled = true;
        ////    //            GameObject.Find("Switches").transform.GetChild(i).tag = "SwitchesSelected";
        ////    //        }
        ////    //    }
        ////    //}
        ////    //if (GameObject.Find("Case").activeSelf) // if keyboard case aren't hiding.
        ////    //{
        ////    //    //Behaviour haloCase = (Behaviour)GameObject.Find("Case").GetComponent("Halo");
        ////    //    if(GameObject.Find("Case").tag == "CaseSelected")
        ////    //    {
        ////    //        //haloCase.enabled = false;
        ////    //        GameObject.Find("Case").tag = "Case";
        ////    //    }
        ////    //    else if(GameObject.Find("Case").tag == "Case")
        ////    //    {
        ////    //        //haloCase.enabled = true;
        ////    //        GameObject.Find("Case").tag = "CaseSelected";
        ////    //    }
        ////    //}
        ////}
        //else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetMouseButtonDown(0)) // ON PROGRESS
        //{
        //    //
        //    Debug.Log("Left mouse button and control button is clicked.");

        //    RaycastHit hitInfo = new RaycastHit();
        //    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        //    //if (hit)
        //    //{
        //    //    Debug.Log(hitInfo.transform.tag);
        //    //    Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
        //    //    if (hitInfo.transform.tag == "Keycaps")
        //    //    {
        //    //        Debug.Log("You just clicked " + hitInfo.transform.name);
                    
        //    //        //if (hitInfo.transform.gameObject.tag == "Keycaps")
        //    //        //{
        //    //            hitInfo.transform.gameObject.tag = "KeycapsSelected";
        //    //            hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, true, null);
        //    //        //}
        //    //        //else if (hitInfo.transform.gameObject.tag == "KeycapsSelected")
        //    //        //{
        //    //        //    hitInfo.transform.gameObject.tag = "Keycaps";
        //    //        //    hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
        //    //        //}
        //    //    }
        //    //    else if (hitInfo.transform.tag == "KeycapsSeleted")
        //    //    {
        //    //        Debug.Log("You just clicked " + hitInfo.transform.name);

        //    //        hitInfo.transform.gameObject.tag = "Keycaps";
        //    //        hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
        //    //    }

        //    //    // ERROR: Click di objek yang sama, masuk ke sini
        //    //    //else if (hitInfo.transform.gameObject.tag != "Keycaps" || hitInfo.transform.gameObject.tag != "KeycapsSelected")
        //    //    //{
        //    //    //    Debug.Log("You just clicked another object. It's a " + hitInfo.transform.gameObject.tag);
        //    //    //}
        //    //}
        //    if (hit && hitInfo.transform.tag == "Keycaps")
        //    {
        //        //Debug.Log(hitInfo.transform.tag); // Jalan
        //        Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
        //        hitInfo.transform.tag = "KeycapsSelected";
        //        hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, true, null);
        //    }
        //    else if (hit && hitInfo.transform.tag == "KeycapsSelected")
        //    {
        //        Debug.Log(hitInfo.transform.tag);
        //        Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
        //        hitInfo.transform.tag = "Keycaps";
        //        hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
        //    }
        //    else
        //    {
        //        Debug.Log("You didn't touch anything.");
        //    }
        //}
        //else if (Input.GetMouseButtonDown(0)) // ON PROGRESS
        //{
        //    Debug.Log("Left mouse button is clicked.");

        //    RaycastHit hitInfo = new RaycastHit();
        //    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        //    //if (hit)
        //    //{
        //    //    if (hitInfo.transform.gameObject.tag == "Keycaps" || hitInfo.transform.gameObject.tag == "KeycapsSelected")
        //    //    {
        //    //        GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        //    //        foreach (GameObject otherKeycap in otherKeycaps)
        //    //        {
        //    //            //Behaviour hitOtherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
        //    //            //hitOtherHalo.enabled = false;
        //    //            otherKeycap.tag = "Keycaps";
        //    //        }

        //    //        GameObject[] otherSelectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        //    //        foreach (GameObject selectedKeycaps in otherSelectedKeycaps)
        //    //        {
        //    //            selectedKeycaps.tag = "Keycaps";
        //    //        }

        //    //        Debug.Log("You just clicked " + hitInfo.transform.name);
        //    //        //Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
        //    //        if (hitInfo.transform.gameObject.tag == "Keycaps")
        //    //        {
        //    //            hitInfo.transform.gameObject.tag = "KeycapsSelected";
        //    //            //hitHalo.enabled = true;
        //    //        }
        //    //        else if (hitInfo.transform.gameObject.tag == "KeycapsSelected")
        //    //        {
        //    //            hitInfo.transform.gameObject.tag = "Keycaps";
        //    //            //hitHalo.enabled = false;
        //    //        }
        //    //    }
        //    //    else if (hitInfo.transform.gameObject.tag == "Switches" || hitInfo.transform.gameObject.tag == "SwitchesSelected")
        //    //    {
        //    //        GameObject[] otherSwitches = GameObject.FindGameObjectsWithTag("Switches");
        //    //        foreach (GameObject otherSwitch in otherSwitches)
        //    //        {
        //    //            otherSwitch.tag = "Switches";
        //    //        }

        //    //        GameObject[] otherSelectedSwitches = GameObject.FindGameObjectsWithTag("SwitchesSelected");
        //    //        foreach (GameObject selectedSwitches in otherSelectedSwitches)
        //    //        {
        //    //            selectedSwitches.tag = "Switches";
        //    //        }

        //    //        Debug.Log("You just clicked a switch.");

        //    //        if (hitInfo.transform.gameObject.tag == "Switches")
        //    //        {
        //    //            hitInfo.transform.gameObject.tag = "SwitchesSelected";
        //    //        }
        //    //        else if (hitInfo.transform.gameObject.tag == "SwitchesSelected")
        //    //        {
        //    //            hitInfo.transform.gameObject.tag = "Switches";
        //    //        }
        //    //    }
        //    //    else if (hitInfo.transform.gameObject.tag == "Case" || hitInfo.transform.gameObject.tag == "CaseSelected")
        //    //    {
        //    //        if (hitInfo.transform.gameObject.tag == "Case")
        //    //            hitInfo.transform.gameObject.tag = "CaseSelected";
        //    //        else if (hitInfo.transform.gameObject.tag == "CaseSelected")
        //    //            hitInfo.transform.gameObject.tag = "Case";
        //    //    }
        //    //    else
        //    //    {
        //    //        Debug.Log("You just clicked another object. It's a " + hitInfo.transform.gameObject.name);
        //    //    }
        //    //}
        //    if (hit && hitInfo.transform.tag == "Keycaps")
        //    {
        //        GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        //        foreach (GameObject otherKeycap in otherKeycaps)
        //        {
        //            Debug.Log("Keycaps lain yang terpilih, sudah tidak terpilih lagi.");
        //            Behaviour otherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
        //            otherHalo.enabled = false;
        //            otherKeycap.tag = "Keycaps";
        //        }

        //        Debug.Log("You just clicked " + hitInfo.transform.name);
        //        Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
        //        hitInfo.transform.tag = "KeycapsSelected";
        //        hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, true, null);
        //    }
        //    else if (hit && hitInfo.transform.tag == "KeycapsSelected")
        //    {
        //        GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        //        foreach (GameObject otherKeycap in otherKeycaps)
        //        {
        //            Debug.Log("Keycaps lain yang terpilih, sudah tidak terpilih lagi.");
        //            Behaviour otherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
        //            otherHalo.enabled = false;
        //            otherKeycap.tag = "Keycaps";
        //        }

        //        Debug.Log("You just clicked " + hitInfo.transform.name);
        //        Behaviour hitHalo = (Behaviour)GameObject.Find(hitInfo.transform.name).GetComponent("Halo");
        //        hitInfo.transform.tag = "Keycaps";
        //        hitHalo.GetType().GetProperty("enabled").SetValue(hitHalo, false, null);
        //    }
        //    else if (!hit)
        //    {
        //        Debug.Log("You didn't touch anything.");
        //        //GameObject[] otherKeycaps = GameObject.FindGameObjectsWithTag("Keycaps");
        //        //foreach (GameObject otherKeycap in otherKeycaps)
        //        //{
        //        //    Behaviour hitOtherHalo = (Behaviour)otherKeycap.GetComponent("Halo");
        //        //    hitOtherHalo.enabled = false;
        //        //}
        //    }
        //}
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

    void reverseColor() // Final & Done
    {
        GameObject[] selectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");

        Material[][] skMaterials = new Material[selectedKeycaps.Length][];
        for (int i = 0; i < selectedKeycaps.Length; i++)
        {
            if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length < 2)
                i = i;
            else if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
            {
                skMaterials[i] = selectedKeycaps[i].GetComponent<Renderer>().materials;
                skMaterials[i][0] = selectedKeycaps[i].GetComponent<Renderer>().materials[1];
                skMaterials[i][1] = selectedKeycaps[i].GetComponent<Renderer>().materials[0];

                selectedKeycaps[i].GetComponent<MeshRenderer>().materials = skMaterials[i];
            }
        }
    }

    //void reverseColor()
    //{
    //    GameObject[] selectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");

    //    Material[][] skMaterials = new Material[selectedKeycaps.Length][];
    //    for (int i = 0; i < selectedKeycaps.Length; i++)
    //    {
    //        if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length < 2)
    //            i = i;
    //        else if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
    //        {
    //            skMaterials[i] = new Material[selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //            skMaterials[i][0] = new Material(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1]);
    //            skMaterials[i][1] = new Material(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0]);
                
    //            selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0].color = skMaterials[i][0].color;
    //            selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1].color = skMaterials[i][1].color;
    //        }
    //    }
    //}

    //void reverseColor()
    //{
    //    GameObject[] selectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
    //    //Material[][] skMaterials = new Material[selectedKeycaps.Length][];
    //    string[][] materials = new string[selectedKeycaps.Length][];
    //    string test = "";
    //    for (int i = 0; i < selectedKeycaps.Length; i++)
    //    {
    //        if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length < 2)
    //            i = i;
    //        else if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
    //        {
    //            //skMaterials[i] = new Material[selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //            //skMaterials[i][0] = new Material(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1]); // RGBA(0.176, 0.180, 0.188, 1.000)
    //            //skMaterials[i][1] = new Material(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0]); // RGBA(0.949, 0.545, 0.478, 1.000)
    //            materials[i] = new string[2];
    //            materials[i][0] = "RGBA(0.176, 0.180, 0.188, 1.000)";
    //            materials[i][1] = "RGBA(0.949, 0.545, 0.478, 1.000)";

    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0].color = skMaterials[i][0].color;
    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1].color = skMaterials[i][1].color;

    //            //materials[i][0].Remove(0, 5);
    //            //materials[i][0].Remove(materials[i][0].Length - 1, 1);

    //            //test = materials[i][0].Remove(materials[i][0].Length - 1, 1).Remove(0, 5).Insert(5, "f").Insert(13, "f").Insert(21, "f").Insert(29, "f");
    //            test = materials[i][0].Remove(materials[i][0].Length - 1, 1).Remove(0, 5);
    //            string[] new_color = test.Split(',');

    //            selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0].color = new Color(float.Parse(new_color[0]), float.Parse(new_color[1]), float.Parse(new_color[2]), float.Parse(new_color[3]));

    //            Debug.Log(test);

    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0].color = new Color(0.176f, 0.180f, 0.188f, 1.000f);

    //            //Debug.Log(skMaterials[i][0].color);
    //            //Debug.Log(skMaterials[i][1].color);
    //        }
    //    }
    //}

    //void reverseColor() // MASIH BUG
    //{
    //    GameObject[] selectedKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
    //    //string[][] skMaterials = new string[selectedKeycaps.Length][];
    //    Material[][] skMaterials = new Material[selectedKeycaps.Length][];
    //    int a = 0;
    //    int b = 1;
    //    for (int i = 0; i < selectedKeycaps.Length; i++)
    //    {
    //        //skMaterials[i] = new string[selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //        skMaterials[i] = new Material[selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //        //for (int j = selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length - 1; j > -1; j--)
    //        //{
    //        //    //skMaterials[i][j] = selectedKeycaps[i].GetComponent<MeshRenderer>().materials[j].name;
    //        //    for (int k = 0; k < skMaterials[i].Length; k++)
    //        //        skMaterials[i][k] = selectedKeycaps[i].GetComponent<MeshRenderer>().materials[j];
    //        //    //Debug.Log("I: " + i + " & J: " + j + " & Material: " + skMaterials[i][j]); // Jalan
    //        //}
    //        if (skMaterials[i].Length > 1)
    //        {
    //            //skMaterials[i][0] = selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1];
    //            //skMaterials[i][1] = selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0];
    //            //b = 0;
    //            //a = 1;
    //        }
    //        else if (skMaterials[i].Length < 2)
    //            skMaterials[i][0] = selectedKeycaps[i].GetComponent<MeshRenderer>().material;
    //    }
    //    for (int i = 0; i < selectedKeycaps.Length; i++)
    //    {
    //        if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
    //        {
    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0] = skMaterials[i][0];
    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1] = skMaterials[i][1];
    //           // Debug.Log(a);
    //            //Debug.Log(b);
    //            selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0] = Resources.Load("2D2E30", typeof(Material)) as Material;
    //            selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1] = Resources.Load("F28B7A", typeof(Material)) as Material;
    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0] = Resources.Load<Material>("Materials/" + skMaterials[i][0]);
    //            //selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1] = Resources.Load<Material>("Materials/" + skMaterials[i][1]);
    //            //Debug.Log(Resources.Load<Material>("Materials/" + skMaterials[i][0].name));
    //            //Debug.Log(Resources.Load<Material>("Materials/" + skMaterials[i][1].name));
    //        }
    //        else if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length < 2)
    //        {
    //            selectedKeycaps[i].GetComponent<MeshRenderer>().material.color = skMaterials[i][0].color;
    //        }
    //        Debug.Log(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[0] + " " + skMaterials[i][0]);
    //        Debug.Log(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[1] + " " + skMaterials[i][1]);
    //        //for (int j = 0; j < selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length; j++)
    //        //{
    //        //    selectedKeycaps[i].GetComponent<MeshRenderer>().materials[j] = skMaterials[i][j];
    //        //    //Debug.Log(skMaterials[i][j]); // jalan
    //        //Debug.Log(selectedKeycaps[i].GetComponent<MeshRenderer>().materials[j] + " " + skMaterials[i][j]); // hasilnya sudah beda, tapi tidak bisa assign
    //        //Debug.Log(Resources.Load<Material>(skMaterials[i][j].ToString())); // null
    //        //if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length < 2)
    //        //{
    //        //    selectedKeycaps[i].GetComponent<MeshRenderer>().materials[j] = Resources.Load<Material>("Materials/" + skMaterials[i][j]);
    //        //    Debug.Log(skMaterials[i][j]);
    //        //    j++;
    //        //}
    //        //else if (selectedKeycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
    //        //    //    selectedKeycaps[i].GetComponent<MeshRenderer>().materials[j] = Resources.Load<Material>("Materials/" + skMaterials[i][j]);
    //        //}
    //    }
    //    //Debug.Log(GameObject.FindWithTag("MechanicalKeyboards").transform.Find("Space").GetComponent<MeshRenderer>().materials.Length); // TIDAK JALAN
    //    //Debug.Log(GameObject.FindWithTag("MechanicalKeyboards").transform.Find("Space").GetComponent<MeshRenderer>().material.name); // TIDAK JALAN
    //    //GameObject[] allKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
    //    //Material materialOne, materialTwo;
    //    //Debug.Log(allKeycaps.Length); // JALAN
    //    //string[][] keycapsMaterial = new string[allKeycaps.Length][];

    //    //for (int i = 0; i < allKeycaps.Length; i++)
    //    //{
    //    //    keycapsMaterial[i] = new string[allKeycaps[i].GetComponent<MeshRenderer>().materials.Length];
    //    //    for (int j = 0; j < allKeycaps[i].GetComponent<MeshRenderer>().materials.Length; j++)
    //    //        keycapsMaterial[i][j] = allKeycaps[i].GetComponent<MeshRenderer>().materials[j].name;
    //    //}

    //    //for (int i = 0; i < allKeycaps.Length; i++)
    //    //{
    //    //    for (int j = 0; j < allKeycaps[i].GetComponent<MeshRenderer>().materials.Length; j++)
    //    //    {
    //    //        for (int k = keycapsMaterial[i].Length-1; k > -1; k--)
    //    //        {
    //    //            //Debug.Log("Length: " + keycapsMaterial[i].Length + " & I: " + i + " & J: " + j + " & K: " + k); // JALAN
    //    //            allKeycaps[i].GetComponent<MeshRenderer>().materials[j] = Resources.Load<Material>("Materials/" + keycapsMaterial[i][k]);
    //    //        }
    //    //    }
    //    //}

    //    //foreach (GameObject eachKeycap in allKeycaps)
    //    //{
    //    //    materialOne = eachKeycap.GetComponent<MeshRenderer>().materials[0].color; // outer
    //    //    materialTwo = eachKeycap.GetComponent<MeshRenderer>().materials[1].color; // font

    //    //    eachKeycap.GetComponent<MeshRenderer>().materials[0].color = materialTwo;
    //    //    eachKeycap.GetComponent<MeshRenderer>().materials[1].color = materialOne;
    //    //}
    //}

    void setColor(Button btnSet, Material matSet)
    {
        //
        GameObject[] allKeycaps = GameObject.FindGameObjectsWithTag("KeycapsSelected");
        Material[] newColor;
        foreach (GameObject eachKeycap in allKeycaps)
        {
            //if((Behaviour)eachKeycap.GetComponent("Halo") != null)
            
            if (eachKeycap.GetComponent<Renderer>().materials.Length > 1)
            {
                newColor = eachKeycap.GetComponent<Renderer>().materials;
                newColor[0] = matSet;
                newColor[1] = eachKeycap.GetComponent<Renderer>().materials[1];
                eachKeycap.GetComponent<MeshRenderer>().materials = newColor;
            }
            else if (eachKeycap.GetComponent<Renderer>().materials.Length < 2)
            {
                newColor = eachKeycap.GetComponent<Renderer>().materials;
                newColor[0] = matSet;
                eachKeycap.GetComponent<MeshRenderer>().materials = newColor;
            }
            //eachKeycap.GetComponent<MeshRenderer>().materials[0] = matSet;
        }
    }
}
