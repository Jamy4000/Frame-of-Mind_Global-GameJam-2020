using System.Collections;
using UnityEngine;

public class CubeAnimationStarter : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(StartAnimationAfterRandomTime());
    }

    private IEnumerator StartAnimationAfterRandomTime()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 5.0f));
        _animator.enabled = true;
    }
}
