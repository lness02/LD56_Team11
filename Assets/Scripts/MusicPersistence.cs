using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPersistence : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
