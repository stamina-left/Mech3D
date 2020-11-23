using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;

public class ScreenshotPNG : MonoBehaviour {

    public GameObject textColorMechanicalKeyboard;
    public Button buttonCaptureButtonfromCanvas;

    // Use this for initialization
    void Start () {
        //GameObject.Find("Screenshot Canvas").transform.GetChild();
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        //buttonCaptureButtonfromCanvas.onClick.AddListener(openMenuScreenshot);
        buttonCaptureButtonfromCanvas.onClick.AddListener(takePicture);
	}
	
	// Update is called once per frame
	void Update () {
        EnableButton();
	}

    void EnableButton()
    {
        buttonCaptureButtonfromCanvas.interactable = false;

        if (!GameObject.FindGameObjectWithTag("MechanicalKeyboards"))
            return;
        else if (GameObject.FindGameObjectWithTag("MechanicalKeyboards"))
            buttonCaptureButtonfromCanvas.interactable = true;
    }

    //private static string HexConverter(Color c)
    //{
    //    string[] color =
    //    return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
    //}

    //void openMenuScreenshot()
    //{
    //    //GameObject[] keycaps = GameObject.FindGameObjectsWithTag("Keycaps");
    //    //string[] baseColor = new string[GameObject.FindGameObjectsWithTag("Keycaps").Length];
    //    //string[] legendColor = new string[GameObject.FindGameObjectsWithTag("Keycaps").Length];

    //    //for (int i = 0; i < GameObject.FindGameObjectsWithTag("Keycaps").Length; i++)
    //    //{
    //    //    if (keycaps[i].GetComponent<MeshRenderer>().materials.Length > 1)
    //    //    {
    //    //        if (keycaps[i].GetComponent<MeshRenderer>().materials[0].color == )
    //    //    }
    //    //}
    //}

    void takePicture()
    {

        FileBrowser.SetFilters(true, new FileBrowser.Filter("Pictures", ".png"));
        FileBrowser.SetDefaultFilter(".png");
        FileBrowser.SetExcludedExtensions(".jpg", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", Application.persistentDataPath, null);
        StartCoroutine(ShowSaveDialogCoroutine());
    }

    IEnumerator ShowSaveDialogCoroutine()
    {
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Screenshot Canvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Game Manager").transform.GetChild(1).GetComponent<HideObject>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().enabled = false;
        yield return FileBrowser.WaitForSaveDialog(false, null, "Save", "Save");
        //Debug.Log(FileBrowser.Success + " " + FileBrowser.Result); // True C:\Users\Albert Pangestu\Documents\Test.sav
        if (FileBrowser.Success) // Berhasil
        {
            ScreenCapture.CaptureScreenshot(FileBrowser.Result);

            GameObject.Find("Main Camera").GetComponent<CameraOrbit>().enabled = true;
            GameObject.Find("Game Manager").transform.GetChild(1).GetComponent<HideObject>().enabled = true;
        }
        
        if (FileBrowser.Result != null)
        {
            GameObject.Find("Canvas").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("Canvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
