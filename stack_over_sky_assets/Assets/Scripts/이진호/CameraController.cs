using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    BlockGenerator blockGen;

    public Camera cam;

    void Start()
    {
        blockGen = GameObject.Find("BlockGenerator").GetComponent<BlockGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ī�޶� ������ ���� �̿�
        //if ()
        //{
        //    cam.transform.position = new Vector3(0, , -10);
        //    cam.orthographicSize += 0.3f;
        //}
    }
}
