using UnityEngine;

public class FollowPlayerCamera2D : MonoBehaviour
{
    public Transform targetPlayer;  // Reference to the player's Transform component
    public Vector3 offset;

    void Start(){

    }


    void Update()
    {
        transform.position = targetPlayer.position + offset;
    }
}
