﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		#if UNITY_ANDROID || UNITY_IOS
		Destroy(gameObject);
		#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
