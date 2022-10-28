using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator characteranimator;
    // Start is called before the first frame update
    void Start()
    {
        characteranimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(characteranimator != null)
        {
            if(Input.GetKey(KeyCode.W))
            {
                characteranimator.SetTrigger("TrForward");
            }
            // else if(Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
            // {
            //     characteranimator.SetTrigger("TrIdle");
            // }
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                characteranimator.ResetTrigger("TrIdle");
            }
            else
           {
                characteranimator.SetTrigger("TrIdle");
                characteranimator.ResetTrigger("TrForward");
           }
        //     if(characteranimator.GetBool("TrIdle") == false)
        //     {
        //         characteranimator.SetTrigger("TrIdle");
        //     }
        //    print(characteranimator.GetBool("TrIdle"));

        }
    }
}
