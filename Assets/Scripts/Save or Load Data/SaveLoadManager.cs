using System.Collections;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SimpleFileBrowser;

public class SaveLoadManager : MonoBehaviour
{

    //sementara masih gagal
    #region Custom Binary Files
        //public static void SaveProject(MechanicalKeyboard mechanicalKeyboard, string projectName)
        public static void SaveProject(MechanicalKeyboard mechanicalKeyboard, string filepath)
        {
            BinaryFormatter bf = new BinaryFormatter();
        //FileStream stream = new FileStream(Application.persistentDataPath + "/" + projectName + ".sav", FileMode.Create);
        //FileStream stream = new FileStream(Application.persistentDataPath + "/MechanicalKeyboard.sav", FileMode.Create);
        FileStream stream = new FileStream(filepath, FileMode.Create);

        MechanicalKeyboardData data = new MechanicalKeyboardData(mechanicalKeyboard);

            //int keySwitch = int.Parse(mechanicalKeyboard.checkLayout().ToString());

            // keycaps
            //data.materials[0] = new string[keySwitch][];

            // 0 = keyboard's name; 1 = keycap's name; 2 = keycaps; 3 = cases; 4 = switches;

            //data.materials[0] = new string[1][];
            //data.materials[0][0] = new string[1];
            //data.materials[0][0][0] = mechanicalKeyboard.keyboardName;

            //data.materials[1] = new string[1][];
            //data.materials[1][0] = new string[1];
            //data.materials[1][0][0] = mechanicalKeyboard.keycapsProfile;

            ////for (int i = 0; i < keySwitch; i++)
            //for (int i = 0; i < mechanicalKeyboard.keycapsMaterial.Length; i++)
            //{
            //    //data.materials[0][i] = new string[2];
            //    //data.materials[0][i][0] = mechanicalKeyboard.keycapsMaterial[i][0];
            //    //data.materials[0][i][1] = null;

            //    //if (mechanicalKeyboard.keycapsMaterial[i][1] != null)
            //    //{
            //    //    data.materials[0][i][1] = mechanicalKeyboard.keycapsMaterial[i][1];
            //    //}
            //    data.materials[2] = new string[mechanicalKeyboard.keycapsMaterial.Length][];

            //    for (int j = 0; j < mechanicalKeyboard.keycapsMaterial[i].Length; j++)
            //    {
            //        data.materials[2][i] = new string[mechanicalKeyboard.keycapsMaterial[i].Length];
            //        data.materials[2][i][j] = mechanicalKeyboard.keycapsMaterial[i][j].name;
            //    }
            //}

            //// cases
            ////data.materials[1] = new string[1][];
            ////data.materials[1][0] = new string[1];
            ////data.materials[1][0][1] = mechanicalKeyboard.casesMaterial;
            //data.materials[3] = new string[1][];
            //data.materials[3][0] = new string[1];
            //data.materials[3][0][0] = mechanicalKeyboard.caseMaterial.name;

            //// switches
            ////data.materials[2] = new string[keySwitch][];
            //data.materials[4] = new string[mechanicalKeyboard.switchesMaterial.Length][];

            ////for (int i = 0; i < keySwitch; i++)
            //for (int i = 0; i < mechanicalKeyboard.switchesMaterial.Length; i++)
            //{
            //    //data.materials[2][i] = new string[3];
            //    //data.materials[2][i][0] = mechanicalKeyboard.switchesMaterial[i][0];
            //    //data.materials[2][i][1] = mechanicalKeyboard.switchesMaterial[i][1];
            //    //data.materials[2][i][2] = mechanicalKeyboard.switchesMaterial[i][2];
            //    data.materials[4][i] = new string[mechanicalKeyboard.switchesMaterial[i].Length];

            //    for (int j = 0; j < mechanicalKeyboard.switchesMaterial[i].Length; j++)
            //    {
            //        data.materials[4][i][j] = mechanicalKeyboard.switchesMaterial[i][j].name;
            //    }
            //}

            bf.Serialize(stream, data);
            stream.Close();
        }

    public static string[][][] LoadProject(string filepath)
    {
        if (File.Exists(Application.persistentDataPath + "/MechanicalKeyboard.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/MechanicalKeyboard.sav", FileMode.Open);

            MechanicalKeyboardData data = bf.Deserialize(stream) as MechanicalKeyboardData;

            stream.Close();

            return data.materials;
        }
        else
        {
            Debug.LogError("File does not exist.");
            //return new string[3][][];
            return new string[5][][];
        }
    }
}

[Serializable]
public class MechanicalKeyboardData
{
    public string[][][] materials;

    public MechanicalKeyboardData(MechanicalKeyboard mechanicalKeyboard)
    {
        //materials = new string[3][][];
        //materials = new string[4][][];
        materials = new string[5][][];

        // ARRAY PERTAMA
        //for (int i = 0; i <= materials.GetLength(0); i++) // 0 = keycaps; 1 = cases; 2 = switches;
        for (int i = 0; i <= materials.Length; i++) // 0 = keyboard's name; 1 = keycap's profile; 2 = keycaps; 3 = cases; 4 = switches;
        {
            // U/ Nama Keyboard
            if (i == 0)
            {
                materials[i] = new string[1][];
                materials[i][0] = new string[1];
                materials[i][0][0] = mechanicalKeyboard.keyboardName;
            }

            // U/ Keycaps Profile
            else if (i == 1)
            {
                materials[i] = new string[1][];
                materials[i][0] = new string[1];
                materials[i][0][0] = mechanicalKeyboard.keycapsProfile;
            }

            // U/ CASES
            //if (i == 1)
            else if (i == 3)
            {
                materials[i] = new string[1][];
                materials[i][0] = new string[1];
                materials[i][0][0] = mechanicalKeyboard.caseMaterial.name;
            }

            //else if (i == 0 || i == 2)
            else if (i == 2 || i == 4)
            {
                // ARRAY KEDUA U/ KEYCAPS (0) & SWITCHES (2)
                //Debug.Log(materials.GetLength(0));
                //for (int j = 0; j <= materials.GetLength(1); j++) // ERROR: array index is out of range
                //Debug.Log(mechanicalKeyboard.checkLayout());
                //if (i == 0) // KEYCAPS (0)
                if (i == 2) // KEYCAPS (2)
                {
                    //materials[i] = new string[mechanicalKeyboard.checkLayout()][];
                    materials[i] = new string[mechanicalKeyboard.keycapsMaterial.Length][];
                    for (int j = 0; j < mechanicalKeyboard.keycapsMaterial.Length; j++)
                    {
                        //Debug.Log(mechanicalKeyboard.keycapsMaterial[j].Length); // JALAN
                        materials[i][j] = new string[mechanicalKeyboard.keycapsMaterial[j].Length];
                        for (int k = 0; k < mechanicalKeyboard.keycapsMaterial[j].Length; k++)
                        {
                            materials[i][j][k] = mechanicalKeyboard.keycapsMaterial[j][k].name;
                        }
                    }
                }
                else if (i == 4) // SWITCHES (4)
                {
                    //Debug.Log(mechanicalKeyboard.switchesMaterial.Length); // JALAN
                    materials[i] = new string[mechanicalKeyboard.switchesMaterial.Length][]; // ERROR: Array index is out of range
                    for (int j = 0; j < mechanicalKeyboard.switchesMaterial.Length; j++)
                    {
                        materials[i][j] = new string[mechanicalKeyboard.switchesMaterial[j].Length];
                        for (int k = 0; k < mechanicalKeyboard.switchesMaterial[j].Length; k++)
                        {
                            materials[i][j][k] = mechanicalKeyboard.switchesMaterial[j][k].name;
                        }
                    }
                }

                //for (int j = 0; j <= materials[i].Length; j++)
                //{
                //    //materials[i] = new string[mechanicalKeyboard.checkLayout()][];

                //    //if (i == 0) // KEYCAPS (0)
                //    if (i == 2) // KEYCAPS (2)
                //    {
                //        //materials[i][j] = new string[2];
                //        //Debug.Log(mechanicalKeyboard.keycapsMaterial[i]);
                //        //materials[i][j][0] = mechanicalKeyboard.keycapsMaterial[i][0]; // Object reference not set to an instance of an object
                //        //materials[i][j][1] = null;
                //        //if (mechanicalKeyboard.keycapsMaterial[i][1] != null)
                //        //{
                //        //    materials[i][j][1] = mechanicalKeyboard.keycapsMaterial[i][1];
                //        //}
                //        materials[i][j] = new string[mechanicalKeyboard.keycapsMaterial[j].Length]; // object is not set to an instance of an object
                //        for (int k = 0; k < mechanicalKeyboard.keycapsMaterial[j].Length; k++)
                //        {
                //            materials[i][j][k] = mechanicalKeyboard.keycapsMaterial[j][k].name;
                //        }
                //    }

                //    //else if (i == 2) // SWITCHES (2)
                //    else if (i == 4) // SWITCHES (4)
                //    {
                //        //materials[i][j] = new string[3];
                //        //materials[i][j][0] = mechanicalKeyboard.switchesMaterial[i][0];
                //        //materials[i][j][1] = mechanicalKeyboard.switchesMaterial[i][1];
                //        //materials[i][j][2] = mechanicalKeyboard.switchesMaterial[i][2];
                //        materials[i][j] = new string[mechanicalKeyboard.switchesMaterial[j].Length];
                //        for (int k = 0; k < mechanicalKeyboard.switchesMaterial[j].Length; k++)
                //        {
                //            materials[i][j][k] = mechanicalKeyboard.switchesMaterial[j][k].name;
                //        }
                //    }
                //}
            }
        }
    }
}
    #endregion
