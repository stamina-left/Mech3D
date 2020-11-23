using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechanicalKeyboard : MonoBehaviour {

    #region Custom Binary Files

    //public GameObject projectNameText;
    //public GameObject loadProjectText;

    //public string mechanicalKeyboardName;
    //public string keycapsProfile;
    //public string[][] keycapsMaterial;
    //public string[][] switchesMaterial;
    //public string casesMaterial;

    ////public GameObject mechanicalKeyboard;


    //private void Awake()
    //{
    //    //mechanicalKeyboard = GameObject.FindWithTag("MechanicalKeyboards");
    //    insertArray();
    //}

    //private void Start()
    //{

    //}

    //public void Update()
    //{
    //    //mechanicalKeyboard = GameObject.FindWithTag("MechanicalKeyboards");
    //}

    //public void insertArray()
    //{
    //    //if (mechanicalKeyboard != null)
    //    //{
    //    //Debug.Log(mechanicalKeyboard.transform.GetChild(0).childCount.ToString()); // transform child is out of bounds.
    //    //int KeycapsCount = int.Parse(mechanicalKeyboard.transform.GetChild(0).childCount.ToString());
    //    mechanicalKeyboardName = this.name;
    //    if (this.transform.GetChild(1).gameObject.activeSelf != null)
    //    {

    //    }
    //    int KeycapsCount = int.Parse(this.transform.GetChild(0).childCount.ToString());
    //    keycapsMaterial = new string[KeycapsCount][];
    //        //Debug.Log(keycapsMaterial.Length);
    //        //keycapsMaterial = new string[int.Parse(this.transform.GetChild(0).gameObject.transform.childCount.ToString())][];
    //        for (int i = 0; i < keycapsMaterial.Length; i++)
    //        {
    //            int keycapsMatLength = 0;
    //            // tidak bisa ambil material spacebar
    //            //print(i);
    //        //Debug.Log(mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length); // bisa tahu jumlah mat spacebar
    //        //if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length > 1) // untuk hitung jumlah keycaps
    //        if (this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length > 1) // untuk hitung jumlah keycaps
    //        {
    //            //keycapsMatLength = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length;
    //            keycapsMatLength = this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length;
    //        }
    //        //else if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length < 2)
    //        else if (this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length < 2)
    //        {
    //                keycapsMatLength = 1;
    //            }
    //            //Debug.Log(mechanicalKeyboard.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().materials.Length); // ambil material, bukan child obj
    //            //Debug.Log(keycapsMatLength);
    //            keycapsMaterial[i] = new string[keycapsMatLength]; // 1. warna out; 2. warna font;

    //        //string keycapsFirstColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.name; // ambil warna out
    //        string keycapsFirstColor = this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.name;
    //        string keycapsSecondColor = null;

    //            //Debug.Log(mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name); // array index is out of range.
    //            //if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1] != null) // cek warna font ada atau tidak
    //            //{
    //            //    keycapsSecondColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna font
    //            //}

    //            //Debug.Log(i + " " + mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length);
    //            keycapsMaterial[i][0] = keycapsFirstColor; // Array index is out of range

    //        // ERROR di bagian Spacebar
    //        //if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length == 2) // kalau keycaps ke-i mempunyai warna font (u/ pengecekan spacebar)
    //        if (this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length == 2)
    //        {
    //            //keycapsSecondColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna font
    //            keycapsSecondColor = this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name;
    //            keycapsMaterial[i][1] = keycapsSecondColor;
    //            }
    //        }
    //        //print("transform get chik(2): " + gameObject.transform.name);
    //        switchesMaterial = new string[int.Parse(this.transform.GetChild(2).childCount.ToString())][];
    //        for (int i = 0; i < switchesMaterial.Length; i++)
    //        {
    //            switchesMaterial[i] = new string[3]; // 1. warna s. case; 2. warna s. stem; 3. warna s. pin

    //            string switchCaseColor = this.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[0].name; // ambil warna s. case
    //            string switchStemColor = this.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna s. stem
    //            string switchPinColor = this.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[2].name; // ambil warna s. pin

    //            switchesMaterial[i][0] = switchCaseColor;
    //            switchesMaterial[i][1] = switchStemColor;
    //            switchesMaterial[i][2] = switchPinColor;
    //        }

    //        casesMaterial = this.transform.GetChild(1).GetComponent<MeshRenderer>().material.name; // ambil warna case keyboard
    //    //}

    //    //else if (mechanicalKeyboard == null)
    //    //{
    //    //    return;
    //    //}
    //}

    //public void Save()
    //{
    //    //Text projectName = projectNameText.gameObject.GetComponent<Text>();
    //    //SaveLoadManager.SaveProject(this, projectName.ToString());
    //    SaveLoadManager.SaveProject(this);
    //}

    //public void Load()
    //{
    //    //Text loadProjectName = loadProjectText.gameObject.GetComponent<Text>();
    //    //string[][][] loadedMaterials = SaveLoadManager.LoadProject(loadProjectName.ToString());
    //    //string[][][] loadedMaterials = SaveLoadManager.LoadProject();
    //    string[][][] loadedMaterials = SaveLoadManager.LoadProject();

    //    // Bandingkan jumlah material antara yang di-load dengan prefab
    //    if (loadedMaterials[0].Length == keycapsMaterial.Length && loadedMaterials[2].Length == switchesMaterial.Length)
    //    {
    //        for (int i = 0; i < keycapsMaterial.Length; i++)
    //        {
    //            //int keycapsMatLength = 0;
    //            //if (this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length > 1)
    //            //{
    //            //    keycapsMatLength = this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length;
    //            //}
    //            //else if (this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length < 2)
    //            //{
    //            //    keycapsMatLength = 1;
    //            //}
    //            //keycapsMaterial[i] = new string[keycapsMatLength]; // 1. warna out; 2. warna font;

    //            //string keycapsFirstColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.name; // ambil warna out
    //            //string keycapsFirstColor = this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.name;
    //            //string keycapsSecondColor = null;

    //            //Debug.Log(mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name); // array index is out of range.
    //            //if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1] != null) // cek warna font ada atau tidak
    //            //{
    //            //    keycapsSecondColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna font
    //            //}

    //            //Debug.Log(i + " " + mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length);
    //            //keycapsMaterial[i][0] = keycapsFirstColor; // Array index is out of range
    //            keycapsMaterial[i][0] = loadedMaterials[0][i][0];

    //            // ERROR di bagian Spacebar
    //            //if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length == 2) // kalau keycaps ke-i mempunyai warna font (u/ pengecekan spacebar)
    //            //if (this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length == 2)
    //            if (keycapsMaterial[i].Length == 2)
    //            {
    //                //keycapsSecondColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna font
    //                //keycapsSecondColor = this.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name;
    //                keycapsMaterial[i][1] = loadedMaterials[0][i][1];
    //            }
    //        }

    //        for (int i = 0; i < switchesMaterial.Length; i++)
    //        {
    //            switchesMaterial[i][0] = loadedMaterials[2][i][0];
    //            switchesMaterial[i][1] = loadedMaterials[2][i][1];
    //            switchesMaterial[i][2] = loadedMaterials[2][i][2];
    //        }

    //        casesMaterial = loadedMaterials[1][0][0];
    //    }
    //    else if (loadedMaterials[0].Length != keycapsMaterial.Length && loadedMaterials[2].Length != switchesMaterial.Length)
    //    {
    //        return;
    //    }
    //}

    ////public int checkLayout() // untuk mengetahui berapa banyak keycaps atau switches
    //public string profileName()
    //{
    //    //GameObject keycaps = mechanicalKeyboard.gameObject.transform.GetChild(0).gameObject;
    //    //GameObject cases = mechanicalKeyboard.gameObject.transform.GetChild(1).gameObject;
    //    //GameObject switches = mechanicalKeyboard.gameObject.transform.GetChild(2).gameObject;

    //    //GameObject keycaps = this.gameObject.transform.GetChild(0).gameObject;
    //    //GameObject cases = this.gameObject.transform.GetChild(1).gameObject;
    //    //GameObject switches = this.gameObject.transform.GetChild(2).gameObject;

    //    //return int.Parse(keycaps.transform.childCount.ToString());


    //}
    #endregion

    #region New Custom Binary Files

    public string keyboardName, keycapsProfile;
    //public Material caseMaterial;
    public string caseMaterial;
    //public Material[][] keycapsMaterial, switchesMaterial;
    public string[][] keycapsMaterial, switchesMaterial;

    private void Update()
    {
        //keyboardName = this.name;
        keyboardName = GameObject.FindGameObjectWithTag("MechanicalKeyboards").name;
        //Debug.Log(keyboardName);

        //caseMaterial = this.transform.GetChild(0).GetComponent<MeshRenderer>().material;
        caseMaterial = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(0).GetComponent<MeshRenderer>().material.color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(0).GetComponent<MeshRenderer>().material.color.ToString().Length - 1, 1).Remove(0, 5);
        //caseMaterial = this.transform.GetChild(0).GetComponent<MeshRenderer>().material.name;
        //Debug.Log(caseMaterial);

        //if (this.transform.Find("Cherry Keycaps").gameObject.activeInHierarchy == true)
        //if ((this.transform.Find("Cherry Keycaps").gameObject.activeInHierarchy) && !(this.transform.Find("SA Keycaps").gameObject.activeInHierarchy)) // BUG
        if ((GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).gameObject.activeInHierarchy) && !(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).gameObject.activeInHierarchy))
        {
            //Debug.Log("Cherry Keycaps is Activated");
            //keycapsProfile = this.transform.GetChild(1).name;
            keycapsProfile = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).name;
            //keycapsMaterial = new Material[this.transform.GetChild(1).childCount][];
            keycapsMaterial = new string[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).childCount][];
            //for (int i = 0; i < this.transform.GetChild(1).childCount; i++)
            for (int i = 0; i < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).childCount; i++)
            {
                //Debug.Log("I: " + i + " Keycaps Length: " + keycapsMaterial.Length); // JALAN
                //Debug.Log("I: " + i + " Materials length: " + this.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials.Length); // JALAN
                //keycapsMaterial[i] = new Material[this.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials.Length];
                keycapsMaterial[i] = new string[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials.Length];
                //for (int j = 0; j < this.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials.Length; j++)
                //{
                //    //Debug.Log(this.transform.GetChild(1).GetChild(i).name);
                //    keycapsMaterial[i][j] = this.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[j]; // ERROR: Array index is out of range
                //    //Debug.Log("I: " + i + " & J: " + j + " & Material: " + keycapsMaterial[i][j]);
                //    //Debug.Log(keycapsMaterial[i].Length); // JALAN
                //    //Debug.Log("j: " + j + " " + this.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[j]); // Result: null
                //}
                if (keycapsMaterial[i].Length > 1)
                {
                    keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[0].color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[0].color.ToString().Length - 1, 1).Remove(0, 5);
                    keycapsMaterial[i][1] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[1].color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[1].color.ToString().Length - 1, 1).Remove(0, 5);
                    //keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[0].name;
                    //keycapsMaterial[i][1] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[1].name;
                }
                else if (keycapsMaterial[i].Length < 2)
                {
                    keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material.color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material.color.ToString().Length - 1, 1).Remove(0, 5);
                    //keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material.name;
                }
            }
            //Debug.Log(keycapsMaterial[0][0]); // TIDAK ERROR
        }

        //else if (this.transform.Find("SA Keycaps").gameObject.activeInHierarchy == true)
        //else if (!(this.transform.Find("Cherry Keycaps").gameObject.activeInHierarchy) && (this.transform.Find("SA Keycaps").gameObject.activeInHierarchy))
        else if ((GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).gameObject.activeInHierarchy) && !(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).gameObject.activeInHierarchy))
        {
            //Debug.Log("SA Keycaps is Activated");
            //keycapsProfile = this.transform.GetChild(2).name;
            //keycapsMaterial = new Material[this.transform.GetChild(2).childCount][];
            keycapsProfile = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).name;
            keycapsMaterial = new string[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).childCount][];
            //for (int i = 0; i < this.transform.GetChild(2).childCount; i++)
            //{
            //    keycapsMaterial[i] = new Material[this.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials.Length];
            //    for (int j = 0; j < this.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials.Length; j++)
            //    {
            //        keycapsMaterial[i][j] = this.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[j];
            //    }
            //}
            //Debug.Log(keycapsMaterial[1].Length);
            for (int i = 0; i < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).childCount; i++)
            {
                keycapsMaterial[i] = new string[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials.Length];
                if (keycapsMaterial[i].Length > 1)
                {
                    keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[0].color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[0].color.ToString().Length - 1, 1).Remove(0, 5);
                    keycapsMaterial[i][1] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[1].color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().materials[1].color.ToString().Length - 1, 1).Remove(0, 5);
                    //keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[0].name;
                    //keycapsMaterial[i][1] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().materials[1].name;
                }
                else if (keycapsMaterial[i].Length < 2)
                {
                    keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().material.color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material.color.ToString().Length - 1, 1).Remove(0, 5);
                    //keycapsMaterial[i][0] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material.name;
                }
            }
        }

        //switchesMaterial = new Material[this.transform.GetChild(3).childCount][];
        switchesMaterial = new string[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(3).childCount][];
        //Debug.Log(switchesMaterial.Length); // JALAN
        for (int i = 0; i < this.transform.GetChild(3).childCount; i++)
        {
            //Debug.Log(this.transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials.Length); // JALAN
            //switchesMaterial[i] = new Material[this.transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials.Length];
            switchesMaterial[i] = new string[GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials.Length];
            //for (int j = 0; j < this.transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials.Length; j++)
            for (int j = 0; j < GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials.Length; j++)
            {
                //switchesMaterial[i][j] = this.transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials[j];
                switchesMaterial[i][j] = GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials[j].color.ToString().Remove(GameObject.FindGameObjectWithTag("MechanicalKeyboards").transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials[j].color.ToString().Length - 1, 1).Remove(0, 5);
                //switchesMaterial[i][j] = this.transform.GetChild(3).GetChild(i).GetComponent<MeshRenderer>().materials[j].name;
                //Debug.Log("I: " + i + " & J: " + j + " & Switches Name: " + switchesMaterial[i][j].name); // JALAN
            }
        }

        // Set Save and Load Button onClick
        //GameObject.Find("Canvas").transform.Find("File Menu Canvas").transform.Find("Save Button").GetComponent<Button>().onClick.AddListener(Save);
        //GameObject.Find("Canvas").transform.Find("File Menu Canvas").transform.Find("Load Button").GetComponent<Button>().onClick.AddListener(Load);

        //Debug.Log(keycapsMaterial[1].Length);
    }

    //public void Save()
    //{
    //    SaveLoadManager.SaveProject(this);
    //}

    //public void Load()
    //{
    //    string[][][] loadedMaterials = SaveLoadManager.LoadProject();

    //    //Debug.Log(loadedMaterials.Length); // JALAN

    //    GameObject.Find("Compact ANSI Keyboard").SetActive(true);
    //    GameObject.Find("Fullsize ANSI Keyboard").SetActive(true);
    //    GameObject.Find("Tenkeyless ANSI Keyboard").SetActive(true);

    //    GameObject[] targetKeyboards = GameObject.FindGameObjectsWithTag("MechanicalKeyboards");
    //    GameObject[] targetKeycaps = new GameObject[2];
    //    GameObject[] keycapsTargeted;

    //    // 0 = keyboard's name; 1 = keycap's name; 2 = keycaps; 3 = cases; 4 = switches;
    //    keyboardName = loadedMaterials[0][0][0];
    //    keycapsProfile = loadedMaterials[1][0][0];
    //    for (int i = 0; i < loadedMaterials[2].Length; i++)
    //    {
    //        keycapsMaterial = new Material[loadedMaterials[2].Length][];
    //        for (int j = 0; j < loadedMaterials[2][i].Length; j++)
    //        {
    //            keycapsMaterial[i] = new Material[loadedMaterials[2][i].Length];
    //            keycapsMaterial[i][j] = Resources.Load<Material>("Materials/" + loadedMaterials[2][i][j]); // belum pasti
    //        }
    //    }
    //    caseMaterial = Resources.Load<Material>(loadedMaterials[3][0][0]);
    //    for (int i = 0; i < loadedMaterials[4].Length; i++)
    //    {
    //        switchesMaterial = new Material[loadedMaterials[4].Length][];
    //        for (int j = 0; j < loadedMaterials[4][i].Length; j++)
    //        {
    //            switchesMaterial[i] = new Material[loadedMaterials[4][i].Length];
    //            switchesMaterial[i][j] = Resources.Load<Material>("Materials/" + loadedMaterials[4][i][j]); // belum pasti
    //        }
    //    }

    //    for (int i = 0; i < targetKeyboards.Length; i++) // 0 = keyboard's name; 1 = keycap's profile; 2 = keycaps; 3 = cases; 4 = switches;
    //    {
    //        /*Debug.Log("I: " + i + " & Keyboard's Name: " + targetKeyboards[i].name);*/ // ERROR: Object reference is not set to an instance of an object.
    //        //Debug.Log("I: " + i); // JALAN
    //        if (targetKeyboards[i].name != keyboardName)
    //        {
    //            targetKeyboards[i].SetActive(false);
    //        }
    //        else if (targetKeyboards[i].name == keyboardName) // 1. Pengecekan nama keyboard yang di-load
    //        {
    //            targetKeycaps[0] = targetKeyboards[i].transform.GetChild(1).gameObject;
    //            targetKeycaps[1] = targetKeyboards[i].transform.GetChild(2).gameObject;

    //            for (int j = 0; j < targetKeycaps.Length; j++) // 2. Pengecekan jenis keycap yang di-load
    //            {
    //                targetKeycaps[j].SetActive(true);
    //                if (targetKeycaps[j].name != keycapsProfile)
    //                {
    //                    targetKeycaps[j].SetActive(false);
    //                    keycapsTargeted = new GameObject[targetKeycaps[j].transform.childCount];

    //                    for (int k = 0; k < targetKeycaps[j].transform.childCount; k++) // 3. Pemasukkan material keycap
    //                    {
    //                        for (int l = 0; l < targetKeycaps[j].transform.GetChild(k).gameObject.GetComponent<MeshRenderer>().materials.Length; l++)
    //                        {
    //                            keycapsTargeted[k].GetComponent<MeshRenderer>().materials[l] = Resources.Load<Material>("Materials/" + loadedMaterials[2][k][l]); // belum pasti
    //                        }
    //                    }
    //                }
    //            }

    //            for (int j = 0; j < targetKeyboards[i].transform.GetChild(3).childCount; j++) // 4. Pemasukan material switches
    //            {
    //                for (int k = 0; k < targetKeyboards[i].transform.GetChild(3).GetChild(j).GetComponent<MeshRenderer>().materials.Length; k++)
    //                {
    //                    targetKeyboards[i].transform.GetChild(3).GetChild(j).GetComponent<MeshRenderer>().materials[k] = Resources.Load<Material>("Materials/" + loadedMaterials[4][j][k]); // belum pasti
    //                }
    //            }
    //        }
    //    }
    //}

    #endregion

    #region Scriptable Object

    //public MechanicalKeyboardData data;

    //public void Save()
    //{
    //    //Text projectName = projectNameText.gameObject.GetComponent<Text>();
    //    //SaveLoadManager.SaveProject(this, projectName.ToString());
    //    //SaveLoadManager.SaveProject(this);
    //    MechanicalKeyboardDataAsset.CreateAsset();
    //}

    //public void Load()
    //{
    //    //Text loadProjectName = loadProjectText.gameObject.GetComponent<Text>();
    //    //string[][][] loadedMaterials = SaveLoadManager.LoadProject(loadProjectName.ToString());
    //    //string[][][] loadedMaterials = SaveLoadManager.LoadProject();
    //}

    #endregion
}
