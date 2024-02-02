using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake(){
        int MusicAmount = FindObjectsOfType<MusicPlayer>().Length;
        if(MusicAmount > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
