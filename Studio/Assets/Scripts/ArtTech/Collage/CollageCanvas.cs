using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollageCanvas : MonoBehaviour
{
    public static CollageCanvas Instance;

    public GameObject stickerPrefab;
    GameObject sticker;
    public int Count = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InstanceNewSticker();
    }
    void InstanceNewSticker()
    {
        //if (sticker != null)
        //    sticker.GetComponent<Collider>().enabled = false;

        sticker = Instantiate(stickerPrefab, transform);
    }
    public void SetStickerPosition(Vector3 position)
    {
        sticker.transform.position = position;
    }
    public void SetStickZRotation(float z)
    {
        sticker.transform.localEulerAngles = Vector3.forward * z;
    }
    public void OnStick(Transform transform)
    {
        transform.position = sticker.transform.position;

        transform.parent = sticker.transform;
        transform.localEulerAngles = Vector3.zero;

        InstanceNewSticker();
    }
}
