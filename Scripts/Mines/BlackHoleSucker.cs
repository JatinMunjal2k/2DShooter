using System.Collections;
using UnityEngine;

public class BlackHoleSucker : MonoBehaviour
{
    public float myRadius = 1.0f;
    public float myStrength = 0.1f;
    private float myThreshold = 0.1f;

    private void LateUpdate()
    {
        GameObject player = GameManager.instance.player;
        if (player == null || Vector3.Distance(player.transform.position, transform.position) > myRadius) {
            return;
        }

        player.transform.position += myStrength * (transform.position - player.transform.position) / (Mathf.Pow(Vector3.Distance(player.transform.position, transform.position), 3) + 1);
        
        if (Vector3.Distance(player.transform.position, transform.position) <= myThreshold) {

        }
    }
}
