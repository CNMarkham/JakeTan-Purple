using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public SpriteRenderer smallRenderer;
    public SpriteRenderer bigRenderer;
    private Animator smallAnimator;
    public bool big;

    // Start is called before the first frame update

    public void start()
    {
        smallAnimator = smallRenderer.gameObject.GetComponent<Animator>();
        big = false;
    }
     private void Start()
    {
        
    }

    public void Hit()
    {
        if (big)
        {
            Shrink();
        } else
        {
            Death();
        }
    }

    private void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;

        GetComponent<CapsuleCollider2D>().size = Vector2.one;
        GetComponent<CapsuleCollider2D>().offset = Vector2.zero;

        big = false;
        StartCoroutine("ChangeSize");
    }

    public void Grow()
    {
        if (big)
        {
            return;
        }
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;

        GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 2f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.5f);

        big = true;

    }

    private void Death()
    {

    }

    private IEnumerator ChangeSize()
    {
        yield return 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
