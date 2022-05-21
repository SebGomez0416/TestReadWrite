using System.IO;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    private void OnEnable()
    {
        LoadCharacter.LoadPosition += OnLoadPosition;
    }

    private void OnDisable()
    {
        LoadCharacter.LoadPosition -= OnLoadPosition;
    }
    
    private void OnLoadPosition(Transform p, string path)
    {
        if (!File.Exists(path)) return;
        
        FileStream fs = File.OpenRead(path);
        BinaryReader br = new BinaryReader(fs);

        Vector3 pos = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
        p.position = pos;
        br.Close();
        fs.Close();
    }
}
