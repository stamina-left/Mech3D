using System.Collections;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{

    // sementara masih gagal
    #region Custom Binary Files
    //    //public static void SaveProject(MechanicalKeyboard mechanicalKeyboard, string projectName)
    //    public static void SaveProject(MechanicalKeyboard mechanicalKeyboard)
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        //FileStream stream = new FileStream(Application.persistentDataPath + "/" + projectName + ".sav", FileMode.Create);
    //        FileStream stream = new FileStream(Application.persistentDataPath + "/MechanicalKeyboard.sav", FileMode.Create);

    //        MechanicalKeyboardData data = new MechanicalKeyboardData(mechanicalKeyboard);

    //        int keySwitch = int.Parse(mechanicalKeyboard.checkLayout().ToString());

    //        // keycaps
    //        data.materials[0] = new string[keySwitch][];
    //        for (int i = 0; i <= keySwitch; i++)
    //        {
    //            data.materials[0][i] = new string[2];
    //            data.materials[0][i][0] = mechanicalKeyboard.keycapsMaterial[i][0];
    //            data.materials[0][i][1] = null;

    //            if (mechanicalKeyboard.keycapsMaterial[i][1] != null)
    //            {
    //                data.materials[0][i][1] = mechanicalKeyboard.keycapsMaterial[i][1];
    //            }
    //        }

    //        // cases
    //        data.materials[1] = new string[1][];
    //        data.materials[1][0] = new string[1];
    //        data.materials[1][0][1] = mechanicalKeyboard.casesMaterial;

    //        // switches
    //        data.materials[2] = new string[keySwitch][];
    //        for (int i = 0; i <= keySwitch; i++)
    //        {
    //            data.materials[2][i] = new string[3];
    //            data.materials[2][i][0] = mechanicalKeyboard.switchesMaterial[i][0];
    //            data.materials[2][i][1] = mechanicalKeyboard.switchesMaterial[i][1];
    //            data.materials[2][i][2] = mechanicalKeyboard.switchesMaterial[i][2];
    //        }

    //        bf.Serialize(stream, data);
    //        stream.Close();
    //    }

    //	public static string[][][] LoadProject()
    //    {
    //        if (File.Exists(Application.persistentDataPath + "/MechanicalKeyboard.sav"))
    //        {
    //            BinaryFormatter bf = new BinaryFormatter();
    //            FileStream stream = new FileStream(Application.persistentDataPath + "/MechanicalKeyboard.sav", FileMode.Open);

    //            MechanicalKeyboardData data = bf.Deserialize(stream) as MechanicalKeyboardData;

    //            stream.Close();

    //            return data.materials;
    //        }
    //        else
    //        {
    //            Debug.LogError("File does not exist.");
    //            return new string[3][][];
    //        }
    //    }
    //}

    //[Serializable]
    //public class MechanicalKeyboardData
    //{
    //    public string[][][] materials;

    //    public MechanicalKeyboardData(MechanicalKeyboard mechanicalKeyboard)
    //    {
    //        materials = new string[3][][];

    //        // ARRAY PERTAMA
    //        for (int i = 0; i <= materials.GetLength(0); i++) // 0 = keycaps; 1 = cases; 2 = switches;
    //        {
    //            // U/ CASES
    //            if (i == 1)
    //            {
    //                materials[i] = new string[1][];
    //                materials[i][0] = new string[1];
    //                materials[i][0][1] = mechanicalKeyboard.casesMaterial;
    //            }

    //            else if (i == 0 || i == 2)
    //            {
    //                // ARRAY KEDUA U/ KEYCAPS (0) & SWITCHES (2)
    //                //Debug.Log(materials.GetLength(0));
    //                //for (int j = 0; j <= materials.GetLength(1); j++) // ERROR: array index is out of range
    //                //Debug.Log(mechanicalKeyboard.checkLayout());
    //                if (i == 0) // KEYCAPS (0)
    //                {
    //                    materials[i] = new string[mechanicalKeyboard.checkLayout()][];
    //                }
    //                else if (i == 2) // SWITCHES (2)
    //                {
    //                    materials[i] = new string[mechanicalKeyboard.checkLayout()][];
    //                }

    //                for (int j = 0; j <= materials[i].Length; j++) 
    //                {
    //                    materials[i] = new string[mechanicalKeyboard.checkLayout()][];

    //                    if (i == 0) // KEYCAPS (0)
    //                    {
    //                        materials[i][j] = new string[2];
    //                        Debug.Log(mechanicalKeyboard.keycapsMaterial[i]);
    //                        materials[i][j][0] = mechanicalKeyboard.keycapsMaterial[i][0]; // Object reference not set to an instance of an object
    //                        materials[i][j][1] = null;
    //                        if (mechanicalKeyboard.keycapsMaterial[i][1] != null)
    //                        {
    //                            materials[i][j][1] = mechanicalKeyboard.keycapsMaterial[i][1];
    //                        }
    //                    }

    //                    else if (i == 2) // SWITCHES (2)
    //                    {
    //                        materials[i][j] = new string[3];
    //                        materials[i][j][0] = mechanicalKeyboard.switchesMaterial[i][0];
    //                        materials[i][j][1] = mechanicalKeyboard.switchesMaterial[i][1];
    //                        materials[i][j][2] = mechanicalKeyboard.switchesMaterial[i][2];
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    #endregion
}