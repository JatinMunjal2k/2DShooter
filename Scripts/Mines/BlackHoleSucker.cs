using System.Collections;
using UnityEngine;

public class BlackHoleSucker : MonoBehaviour
{
    public float myRadius = 1.0f;
    public float myStrength = 0.1f;

    void Update()
    {
        GameObject player = GameManager.instance.player;
        if(player == null || Vector3.Distance(player.transform.position, transform.position) > myRadius) {
            return;
        }

        player.transform.position += myStrength * (transform.position - player.transform.position) / Vector3.Distance(player.transform.position, transform.position);
    }
}
