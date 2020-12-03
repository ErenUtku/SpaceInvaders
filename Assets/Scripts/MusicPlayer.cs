using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{ }
    /* "Singleton in audio Source "
     
      
 
      
    static MusicPlayer instance;

    void Awake()
    {
        SetSingleton(); 
    }
    private void SetSingleton()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        
    }
}*/
