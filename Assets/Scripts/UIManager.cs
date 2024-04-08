using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class UIManager : Singleton<UIManager> {
	[System.Serializable]
	struct Screen {
		public string name;
		public GameObject go;
	}

	[SerializeField] Screen[] screens;
	[SerializeField] TMP_Text redNumTxt;
	[SerializeField] TMP_Text bluesNumTxt;
	[SerializeField] TMP_Text bombNumTxt;
	[SerializeField] TMP_Text chuckNumTxt;

	Dictionary<string, Screen> registry = new Dictionary<string, Screen>();

	private void Start() {
		// convert array of screens to dictionary registry
		foreach (var screen in screens) {
			registry[screen.name] = screen;
		}
	}

	public void SetActive(string name, bool active, bool exclusive = true) {
		if (!registry.ContainsKey(name)) return;

		Screen screen = registry[name];
		foreach (var _screen in screens) {
			if (_screen.go == screen.go) screen.go.SetActive(active); 
			if (_screen.go != screen.go && exclusive) screen.go.SetActive(false);
		}
	}
}