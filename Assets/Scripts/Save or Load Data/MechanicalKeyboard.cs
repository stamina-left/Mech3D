using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechanicalKeyboard : MonoBehaviour {

    #region Custom Binary Files

    //public GameObject projectNameText;
    //public GameObject loadProjectText;

    //public string[][] keycapsMaterial;
    //public string[][] switchesMaterial;
    //public string casesMaterial;

    //public GameObject mechanicalKeyboard;


    //private void Awake()
    //{
    //    insertArray();
    //}

    //private void Start()
    //{

    //}

    //public void Update()
    //{
    //    mechanicalKeyboard = GameObject.FindWithTag("MechanicalKeyboards");
    //}

    //public void insertArray()
    //{
    //    if(mechanicalKeyboard != null)
    //    {
    //        //Debug.Log(mechanicalKeyboard.transform.GetChild(0).childCount.ToString()); // transform child is out of bounds.
    //        int KeycapsCount = int.Parse(mechanicalKeyboard.transform.GetChild(0).childCount.ToString());
    //        keycapsMaterial = new string[KeycapsCount][];
    //        //Debug.Log(keycapsMaterial.Length);
    //        //keycapsMaterial = new string[int.Parse(this.transform.GetChild(0).gameObject.transform.childCount.ToString())][];
    //        for (int i = 0; i <= keycapsMaterial.Length; i++)
    //        {
    //            int keycapsMatLength = 0;
    //            // tidak bisa ambil material spacebar
    //            //Debug.Log(mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length); // bisa tahu jumlah mat spacebar
    //            if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length > 1) // untuk hitung jumlah keycaps
    //            {
    //                keycapsMatLength = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length;
    //            }
    //            else if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length < 2)
    //            {
    //                keycapsMatLength = 1;
    //            }
    //            //Debug.Log(mechanicalKeyboard.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().materials.Length); // ambil material, bukan child obj
    //            //Debug.Log(keycapsMatLength);
    //            keycapsMaterial[i] = new string[keycapsMatLength]; // 1. warna out; 2. warna font;

    //            string keycapsFirstColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.name; // ambil warna out
    //            string keycapsSecondColor = null;

    //            //Debug.Log(mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name); // array index is out of range.
    //            //if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1] != null) // cek warna font ada atau tidak
    //            //{
    //            //    keycapsSecondColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna font
    //            //}

    //            Debug.Log(i + " " + mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length);
    //            keycapsMaterial[i][0] = keycapsFirstColor; // Array index is out of range

    //            // ERROR di bagian Spacebar
    //            if (mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials.Length == 2) // kalau keycaps ke-i mempunyai warna font (u/ pengecekan spacebar)
    //            {
    //                keycapsSecondColor = mechanicalKeyboard.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().materials[1].name; // ambil warna font
    //                keycapsMaterial[i][1] = keycapsSecondColor;
    //            }
    //        }

    //        switchesMaterial = new string[int.Parse(this.transform.GetChild(2).childCount.ToString())][];
    //        for (int i = 0; i <= switchesMaterial.Length; i++)
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
    //    }

    //    else if (mechanicalKeyboard == null)
    //    {
    //        return;
    //    }
    //}

    //public void Save()
    //{
    //    //Text projectName = projectNameText.gameObject.GetComponent<Text>();
    //    //SaveLoadManager.SaveProject(this, projectName.ToString());
    //    //SaveLoadManager.SaveProject(this);
    //}

    //public void Load()
    //{
    //    //Text loadProjectName = loadProjectText.gameObject.GetComponent<Text>();
    //    //string[][][] loadedMaterials = SaveLoadManager.LoadProject(loadProjectName.ToString());
    //    //string[][][] loadedMaterials = SaveLoadManager.LoadProject();
    //}

    //public int checkLayout() // untuk mengetahui berapa banyak keycaps atau switches
    //{
    //    GameObject keycaps = mechanicalKeyboard.gameObject.transform.GetChild(0).gameObject;
    //    GameObject cases = mechanicalKeyboard.gameObject.transform.GetChild(1).gameObject;
    //    GameObject switches = mechanicalKeyboard.gameObject.transform.GetChild(2).gameObject;

    //    return int.Parse(keycaps.transform.childCount.ToString());
    //}
    #endregion

    #region Scriptable Object

    public MechanicalKeyboardData data;



#endregion
}
