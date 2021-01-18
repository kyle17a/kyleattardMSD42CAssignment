using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
        
    }

    private void SetUpSingleton()
    {
        //gettype(): gets the type of Object attached to this script: MusicPlayer
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //if there is more than MusicPlayer, destroy the last one
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
