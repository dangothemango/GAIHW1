using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class LevelLoader : MonoBehaviour {

    public GameObject Block;
    public GameObject Pellet;
    public string fileName;
    char[][] grid = new char[36][];

    // Use this for initialization
    void Start ()
    {
        try
        {
            string line;
            int i = 0;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            using (reader)
            {
                do
                {
                    
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        char[] entries = line.ToCharArray();
                        grid[i] = entries;
                        string str = "";
                        foreach (char c in entries) {
                            str += c;
                        }
                        Debug.Log(str+grid[i].Length.ToString());
                        ++i;
                    }
                }
                while (line != null);

                reader.Close();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            Debug.LogWarning(e.StackTrace);
        }

        float x = 0, y = 38.5f;
        Debug.Log(grid.Length);
        Debug.Log(grid[1].Length);

        for (int i = 0; i < 36; ++i) 
        {
            for (int u = 0; u < 28; ++u)
            {
                Debug.Log(i.ToString() + " " + u.ToString());
                if (grid[i][u] == '1')
                {
                    Debug.Log(i.ToString() + " " + u.ToString());
                    Instantiate(Block, new Vector3(x, y, 0), Quaternion.identity);
                }
                else if (grid[i][u] == '0')
                {
                    Debug.Log(i.ToString() + " " + u.ToString());
                    Instantiate(Pellet, new Vector3(x, y, 0), Quaternion.identity);
                }
                x += 2.6f;
            }
            x = 0;
            y -= 2.6f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
