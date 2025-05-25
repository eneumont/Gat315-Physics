using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISingleton : MonoBehaviour {
    private static UISingleton instance;

    private GameObject titleS, optionS, mainS;

    private UISingleton() {

    }

    public static UISingleton getInstance() {
        if (instance == null) { 
            instance = new UISingleton();
        }
        
        return instance;
    }

	public void startTitle() {
        mainS = null;
        optionS = null;
        titleS = new GameObject();
	}

	public void startOptions() {
		mainS = null;
		optionS = new GameObject();
		titleS = null;
	}

	public void startMain() {
		mainS = new GameObject();
		optionS = null;
		titleS = null;
	}
}