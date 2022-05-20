using System;
using System.IO;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ReadFile();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            WriteFile();
    }

    private void WriteFile()
    {
        Debug.Log("ESCRIBINEDO.......");
        
        FileStream fs = File.OpenWrite("Assets/Data/position.dat");
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(rb.position.x);
        bw.Write(rb.position.y);
        bw.Write(rb.position.z);
        
        bw.Close();
        fs.Close();
    }

    private void ReadFile()
    {
        Debug.Log("LEYENDO.......");
        FileStream fs = File.OpenRead("Assets/Data/position.dat");

        BinaryReader br = new BinaryReader(fs);

        Vector3 pos = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());

        rb.position = pos;

        br.Close();
        fs.Close();
    }
}
