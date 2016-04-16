using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform player;
    [Range(1, 20)] public float smoothing = 10f;

    Vector3 offset, normalOffset;

    void Start()
    {
        offset = transform.position - player.position;
        normalOffset = offset;
    }

    void FixedUpdate()
    {
        Vector3 playerCamPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, playerCamPos, smoothing * Time.deltaTime);
    }
}
