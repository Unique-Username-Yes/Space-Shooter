using System.Collections;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private float dmg = 10;
    public float fadeSpeed = 10f;

    IEnumerator fade;

    void Start()
    {
        fade = Fade();
        StartCoroutine(fade);
    }

    private IEnumerator Fade()
    {
        Renderer rend = transform.GetComponent<Renderer>();
        
        float alpha = rend.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * fadeSpeed)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0.0f, t));
            rend.material.color = newColor;
            Debug.Log(rend.material.color);
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(dmg);
        }
    }

    public void SetDmg(float dmg)
    {
        this.dmg = dmg;
    }
}
