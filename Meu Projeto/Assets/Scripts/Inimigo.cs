using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private float timeToDeath = 10f;

    private Animator animator;

    private void Start()
    {
        if (TryGetComponent(out Animator component))
        {
            animator = component;
            StartCoroutine(DieIn(timeToDeath));
        }
    }

    IEnumerator DieIn(float time)
    {
        yield return new WaitForSeconds(timeToDeath);
        animator.SetBool("Dying", true);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (animator.GetBool("Dying"))
            return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}













// using UnityEngine.SceneManagement;
// SceneManager.LoadScene(SceneManager.GetActiveScene().name);