using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImageTarget : MonoBehaviour {
    [SerializeField] Image image;
    [SerializeField] Camera cam;
    [SerializeField] float distance = 5;

    void LateUpdate() {
        Vector3 screen = image.transform.position;
        screen.z = distance;

        Vector3 world = cam.ScreenToWorldPoint(screen);
        transform.position = world;
    }
}