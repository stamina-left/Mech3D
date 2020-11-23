using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraOrbit : MonoBehaviour {

    private Transform target;
    public float distance = 2.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Update()
    {
        if (GameObject.FindWithTag("MechanicalKeyboards") == null)
            return;
        else if (GameObject.FindWithTag("MechanicalKeyboards") != null)
            target = GameObject.FindWithTag("MechanicalKeyboards").transform;

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.A)) // SUKSES
        {
            Debug.Log("Control and Type A is clicked.");
            if (GameObject.FindWithTag("Keycaps") || (GameObject.FindWithTag("Keycaps") && GameObject.FindWithTag("KeycapsSelected")))
            {
                GameObject[] otherKeycapsTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
                foreach (GameObject otherKeycapTarget in otherKeycapsTarget)
                {
                    Behaviour oktHalo = (Behaviour)otherKeycapTarget.GetComponent("Halo");
                    oktHalo.enabled = false;
                    otherKeycapTarget.tag = "Keycaps";
                }
                GameObject[] keycapsTarget = GameObject.FindGameObjectsWithTag("Keycaps");
                foreach (GameObject keycapTarget in keycapsTarget)
                {
                    Behaviour ktHalo = (Behaviour)keycapTarget.GetComponent("Halo");
                    ktHalo.enabled = true;
                    keycapTarget.tag = "KeycapsSelected";
                }
            }
            else if (GameObject.FindWithTag("KeycapsSelected"))
            {
                GameObject[] keycapsSelectedTarget = GameObject.FindGameObjectsWithTag("KeycapsSelected");
                foreach (GameObject keycapSelectedTarget in keycapsSelectedTarget)
                {
                    Behaviour kstHalo = (Behaviour)keycapSelectedTarget.GetComponent("Halo");
                    kstHalo.enabled = false;
                    keycapSelectedTarget.tag = "Keycaps";
                }
                Debug.Log("No longer keycaps selected.");
            }
        }
        
        else if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetMouseButtonDown(0)) // ON PROGRESS
        {
            Debug.Log("Left mouse button and control button is clicked.");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit && hitInfo.transform.tag == "Keycaps")
            {
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
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button is clicked.");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
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
            }
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(1))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
