using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;

    public float limitRight;
    public float limitLeft;

    Vector3 v;
    Transform camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float nowX = player.position.x;
        if(player.position.x < limitLeft ) {
            nowX = limitLeft;
        }
        if(player.position.x > limitRight ) {
            nowX = limitRight;
        }

        camera = transform;
        v = new Vector3(nowX, camera.position.y, camera.position.z);
        transform.position = v;
    }
}
