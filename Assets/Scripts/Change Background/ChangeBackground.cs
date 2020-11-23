using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;

public class ChangeBackground : MonoBehaviour {

    public Button buttonChangeBackground;

	// Use this for initialization
	void Start () {
        buttonChangeBackground.onClick.AddListener(openChangeMenu);
	}

    public void openChangeMenu()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png", ".jpeg")); // atur file extension yang dapat dibaca oleh file explorer
        FileBrowser.SetDefaultFilter(".jpg"); // set extension filter yang utama
        FileBrowser.SetExcludedExtensions(".sav", ".zip", ".rar", ".exe"); // file extension yang tidak dimasukkan di file explorer
        FileBrowser.AddQuickLink("Users", Application.persistentDataPath, null); // atur lokasi utama saat pertama buka file explorer
        StartCoroutine(ShowChangeDialogCoroutine()); // JALAN, tapi persistent data path tidak jalan, dan hasil save tidak muncul.
        //Debug.Log(Application.persistentDataPath); // JALAN
    }

    IEnumerator ShowChangeDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(false, null, "Load", "Load");
        //Debug.Log(FileBrowser.Success + " " + FileBrowser.Result); // True C:\Users\Albert Pangestu\Documents\Test.sav
        if (FileBrowser.Success) // Berhasil
        {
            
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
