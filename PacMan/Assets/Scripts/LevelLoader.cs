using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class LevelLoader : MonoBehaviour {

    public GameObject Block;
    public GameObject Pellet;
    public string fileName;
    string[][] grid;

    // Use this for initialization
    void Start ()
    {
        try
        {
            string line;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            using (reader)
            {
                do
                {
                    int i = 0;
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        string[] entries = line.Split();
                        grid[i] = entries;
                        ++i;
                    }
                }
                while (line != null);

                reader.Close();
            }
        }
        catch
        {
            
        }

        int x = 0, y = 0;

        for (int i = 0; i < 36; ++i;) 
        {
            for (int u = 0; u < 28; ++u;)
            {
                if (grid[i][u] == "1")
                {
                    Instantiate(Block, new Vector3(x, y, 0), Quaternion.identity);
                }
                else if (grid[i][u] == "0")
                {
                    Instantiate(Pellet, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
