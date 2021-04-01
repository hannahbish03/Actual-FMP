using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform player;

    void LateUpdate()
    {
        player = FindObjectOfType<Player>().gameObject.transform;
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        newPosition.z = -10;
        transform.position = newPosition;

        //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }

}
