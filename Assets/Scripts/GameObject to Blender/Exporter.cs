using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Mech3D
{
    public class Exporter : Editor
    {
        //public GameObject mechanicalKeyboard;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //mechanicalKeyboard = GameObject.FindGameObjectWithTag("MechanicalKeyboards");
            //buttonExporter.onClick.AddListener(ExportGameObject(mechanicalKeyboard, true, true));
            //buttonExporter.onClick.AddListener(ExportCurrentGameObject);
            GameObject.Find("Canvas").transform.Find("File Menu Canvas").Find("Export Button").GetComponent<Button>().onClick.AddListener(ExportCurrentGameObject);

            if (GameObject.FindGameObjectWithTag("MechanicalKeyboards") != null)
                GameObject.Find("Canvas").transform.Find("File Menu Canvas").Find("Export Button").GetComponent<Button>().interactable = false;
        }

        //public void ExportCurrentGameObject(bool copyMaterials, bool copyTextures)
        public void ExportCurrentGameObject()
        {
            if (Selection.activeGameObject == null)
            {
                //EditorUtility.DisplayDialog("No Object Selected", "Please select any GameObject to Export to FBX", "Okay");
                Debug.Log("No Object Selected. Please add a Mechanical Keyboard first before you do an Export to FBX.");
                return;
            }

            //GameObject currentGameObject = Selection.activeObject as GameObject;
            GameObject currentGameObject = GameObject.FindGameObjectWithTag("MechanicalKeyboards");

            if (currentGameObject == null)
            {
                //EditorUtility.DisplayDialog("Warning", "Item selected is not a GameObject", "Okay");
                Debug.Log("Item selected is not a GameObject.");
                return;
            }

            ExportGameObject(currentGameObject, true, false);
        }

        public static string ExportGameObject(GameObject gameObj, bool copyMaterials, bool copyTextures, string oldPath = null)
        {
            if (gameObj == null)
            {
                EditorUtility.DisplayDialog("Object is null", "Please select any GameObject to Export to FBX", "Okay");
                return null;
            }

            string newPath = GetNewPath(gameObj, oldPath);

            if (newPath != null && newPath.Length != 0)
            {
                bool isSuccess = FBXExporter.ExportGameObjToFBX(gameObj, newPath, copyMaterials, copyTextures);

                if (isSuccess)
                {
                    return newPath;
                }
                else
                    EditorUtility.DisplayDialog("Warning", "The extension probably wasn't an FBX file, could not export.", "Okay");
            }
            return null;
        }

        private static string GetNewPath(GameObject gameObject, string oldPath = null)
        {
            // NOTE: This must return a path with the starting "Assets/" or else textures won't copy right

            string name = gameObject.name;

            string newPath = null;
            if (oldPath == null)
                newPath = EditorUtility.SaveFilePanelInProject("Export FBX File", name + ".fbx", "fbx", "Export " + name + " GameObject to a FBX file");
            else
            {
                if (oldPath.StartsWith("/Assets"))
                {
                    oldPath = Application.dataPath.Remove(Application.dataPath.LastIndexOf("/Assets"), 7) + oldPath;
                    oldPath = oldPath.Remove(oldPath.LastIndexOf('/'), oldPath.Length - oldPath.LastIndexOf('/'));
                }
                newPath = EditorUtility.SaveFilePanel("Export FBX File", oldPath, name + ".fbx", "fbx");
            }

            int assetsIndex = newPath.IndexOf("Assets");

            if (assetsIndex < 0)
                return null;

            if (assetsIndex > 0)
                newPath = newPath.Remove(0, assetsIndex);

            return newPath;
        }
    }
}