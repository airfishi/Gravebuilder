using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public bool[][] blocks;
    public GameObject well;

    private Vector3 moveBy = Vector3.zero;
    private int numBlocksInLevel = 1;
    private int blockSize = 250;

    void Start()
    {
        for (int i = 0; i < 26; i++)
        {
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
        Debug.Log("Block Added!");
        blocks[ypos / 250][xpos / 250] = true;
    }        
}
