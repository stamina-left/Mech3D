using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mech3D
{ 
    public class ExporterScript : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            GameObject.Find("Canvas").transform.Find("File Menu Canvas").Find("Export Button").GetComponent<Button>().onClick.AddListener(ExportCurrentGameObject);

            if (GameObject.FindGameObjectWithTag("MechanicalKeyboards") == null)
                GameObject.Find("Canvas").transform.Find("File Menu Canvas").Find("Export Button").GetComponent<Button>().interactable = false;
            else if (GameObject.FindGameObjectWithTag("MechanicalKeyboards") != null)
                GameObject.Find("Canvas").transform.Find("File Menu Canvas").Find("Export Button").GetComponent<Button>().interactable = true;
        }

        public void ExportCurrentGameObject()
        {
            if (GameObject.FindGameObjectWithTag("MechanicalKeyboards") == null)
            {
                //EditorUtility.DisplayDialog("No Object Selected", "Please select any GameObject to Export to FBX", "Okay");
                Debug.LogError("No Object Selected. Please add a Mechanical Keyboard first before you do an Export to FBX.");
                return;
            }

            //GameObject currentGameObject = Selection.activeObject as GameObject;
            GameObject currentGameObject = GameObject.FindGameObjectWithTag("MechanicalKeyboards");

            if (currentGameObject == null)
            {
                //EditorUtility.DisplayDialog("Warning", "Item selected is not a GameObject", "Okay");
                Debug.LogError("Item selected is not a GameObject.");
                return;
            }

            ExportGameObject(currentGameObject, true, false);
        }

        public static string ExportGameObject(GameObject gameObj, bool copyMaterials, bool copyTextures, string oldPath = null)
        {
            if (gameObj == null)
            {
                //EditorUtility.DisplayDialog("Object is null", "Please select any GameObject to Export to FBX", "Okay");
                Debug.Log("Please add a Mechanical Keyboard first to Export to FBX.");
                return null;
            }

            //string newPath = GetNewPath(gameObj, oldPath);
            string newPath = "Assets/Save Data/" + gameObj.name + ".fbx";

            if (newPath != null && newPath.Length != 0)
            {
                bool isSuccess = FBXExporter.ExportGameObjToFBX(gameObj, newPath, copyMaterials, copyTextures);

                if (isSuccess)
                {
                    return newPath;
                }
                else
                    //EditorUtility.DisplayDialog("Warning", "The extension probably wasn't an FBX file, could not export.", "Okay");
                    Debug.LogError("Could not export because the extension probably wasn't a FBX file.");
            }
            return null;
        }
    }
}