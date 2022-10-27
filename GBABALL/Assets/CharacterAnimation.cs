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
            if(Input.GetKeyDown(KeyCode.W))
            {
                characteranimator.SetTrigger("TrForward");
            }

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {

            }
            else
           {
                characteranimator.SetTrigger("TrIdle");
           }
        }
    }
}
