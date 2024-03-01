using UnityEngine;

public class DestroyObjectAndChildren : MonoBehaviour
{
    //public DisplayInventory inv;

    private bool canDie;
    public void DestroyObjectWithChildren()
    {
        // Destroy all children of the current GameObject
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Destroy the current GameObject
        Destroy(gameObject);
    }
}
