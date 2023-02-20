using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public GameObject well;


    private bool[][] blocks = new bool[26][];
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
        gravity();
        checkAndMove();
    }
    public void gravity()
    {
        for(int i = 25; i > 0; i--)
        {
            for(int j = 0; j < 26; j++)
            {
                if (blocks[i][j] && !blocks[i - 1][j])
                {
                    blocks[i][j] = false;
                    blocks[i - 1][j] = true;
                }
            }
        }
    }
    public void checkAndMove()
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
            for(int i = 0; i < numBlocksInLevel; i++)
            {
                for(int j = 0; j < 26; j++)
                {
                    blocks[i][j] = false;
                }
            }
            gravity();
        }
    }
    public void addBlock(int ypos, int xpos)
    {
        int yindex = (ypos / 250)+5;
        int xindex = (xpos / 250)+14;
        blocks[yindex][xindex] = true;
    }        
}
