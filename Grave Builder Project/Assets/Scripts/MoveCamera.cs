using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public bool[][] blocks = new bool[26][];
    public GameObject well;

    private Vector3 moveBy = Vector3.zero;
    private int numBlocksInLevel = 1;
    private int blockSize = 250;

    void Start()
    {
        for (int i = 0; i < 26; i++)
        {
            blocks[i] = new bool[26]; 
            for (int j = 0; j < 26; j++)
            {
                blocks[i][j] = false;
            }
        }
        moveBy.y = numBlocksInLevel * blockSize;
    }

    // Update is called once per frame
    void Update()
    {
        int levels = 0;
        for (int i = 0; i < 26; i++)
        {
            levels++;
            for (int j = 0; j < 26; j++)
            {
                if (blocks[i][j] != true)
                {
                    levels--;
                    break;
                }
            }
            if (levels <= i)
            {
                break;
            }
        }
        if (levels >= numBlocksInLevel)
        {
            Debug.Log("MOVING!!!");
            GetComponent<Transform>().position += moveBy;
            well.transform.position += moveBy;
        }
    }


    public void addBlock(int ypos, int xpos)
    {
        int yindex = (ypos / 250)+5;
        int xindex = (xpos / 250)+14;
        Debug.Log("Block Added at " + xindex + "," + yindex);
        blocks[ypos / 250][xpos / 250] = true;
    }        
}
