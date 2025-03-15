using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    // DataType VariableName = Value

    // int and float 

    public int numOne = 1; 
    private int numTwo = 9;
    float numThree = 10.25f; 
    [SerializeField] int numFour = 10;


    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Debug.Log(transform.position);

        if (numOne == 1)
        {
            Debug.Log("numOne is 1");
        }

        if (numOne == 5)
        {
            Debug.Log("numOne is 5");
        }
        else if (numOne >= numTwo)
        {
            Debug.Log("numOne is 9");
        }
        else
        {
            Debug.Log("numOne is not 5 and not equal to numTwo");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // numOne = numOne + 1;
        numOne++;
        //position += new Vector3(0, 0.01f, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1f, 0);
        }
    }
}
