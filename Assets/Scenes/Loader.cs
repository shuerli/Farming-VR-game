﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader { 

    public static void Load(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
