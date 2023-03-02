using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public GameObject well;

    private Vector3 moveBy = Vector3.zero;
    private int numBlocksInLevel = 1;
    private int blockSize = 250;
    private int numBlocksInRow = 13;
    private int numBlocksInColumn = 16;//Remember block array does not have this var attached
    private int level = 1;

    private bool[][] blocks = new bool[16][];//y comes first for efficiency

    void Start()
    {
        for (int i = 0; i < numBlocksInColumn; i++)    //Iterate through ys
        {
            blocks[i] = new bool[numBlocksInRow]; 
            for (int j = 0; j < numBlocksInRow; j++)    //Iterate through xs
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
        for(int i = numBlocksInColumn-1; i > 0; i--)
        {
            for(int j = 0; j < numBlocksInRow; j++)
            {
                if (blocks[i][j] && !blocks[i - 1][j])
                {
                    blocks[i][j] = false;
                    blocks[i - 1][j] = true;
                    //Debug.Log("Moved " + i + "," + j + "Down by 1.");
                }
            }
        }
    }
    public void checkAndMove()
    {
        int levels = 0;
        for (int i = 0; i < numBlocksInColumn; i++)//Iterate through y values
        {
            levels++;
            for (int j = 0; j < numBlocksInRow; j++)    //Iterate through x values
            {
                if (blocks[i][j] != true)
                {
                    levels--;
                    //Debug.Log("Num Blocks in Last Level:" + j);
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
            GetComponent<Transform>().position += moveBy * (levels - numBlocksInLevel + 1);     //Move up objects
            well.transform.position += moveBy * (levels - numBlocksInLevel + 1);
            well.GetComponent<large_slime_spawning>().increaseYSpawn();
            level++;

            if(level%numBlocksInColumn== 0)                                                     //Clone background and torches every 15 blocks
            {

            }
            

            for (int i = 0; i < numBlocksInLevel * (levels - numBlocksInLevel + 1); i++)         //Remove Row from Abstraction
            {
                for(int j = 0; j < numBlocksInRow; j++)
                {
                    blocks[i][j] = false;
                }
            }
            gravity();
        }
    }
    public void addBlock(int ypos, int xpos)
    {
        int yindex = (ypos / 250)+4;
        int xindex = (xpos / 500)+7;
        while(blocks[yindex][xindex]){
            yindex++;
        }
        blocks[yindex][xindex] = true;
        //Debug.Log("Added at " + yindex + "," + xindex);
    }        
}
