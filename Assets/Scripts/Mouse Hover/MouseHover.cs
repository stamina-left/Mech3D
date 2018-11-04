using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour {

    void OnMouseOver(GameObject gameObject)
    {
        Debug.Log("Mouse di atas button " + this.gameObject.name);
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().enabled = false;
    }

    void OnMouseExit(GameObject gameObject)
    {
        Debug.LogError("Mouse sudah tidak di atas button " + this.gameObject.name);
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().enabled = true;
    }
}
