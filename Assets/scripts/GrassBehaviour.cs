using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{
    private Animator animController;

    private void Start()
    {
        animController = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animController.SetTrigger("player_inside");
    }
}