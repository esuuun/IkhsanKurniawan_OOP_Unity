using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{   
    

  [SerializeField] private int blinkingCount = 7;
  [SerializeField] private float blinkInterval = 0.1f;
  [SerializeField] private Material blinkMaterial;
  private SpriteRenderer spriteRenderer;
  private HitboxComponent hitboxComponent;
  private Material originalMaterial;
  public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitboxComponent = GetComponent<HitboxComponent>();
        originalMaterial = spriteRenderer.material;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInvincibility(){
      if (!isInvincible){
        StartCoroutine(InvincibilityRoutine());
      }
    }

    private IEnumerator InvincibilityRoutine(){

      isInvincible = true;
      for (int i = 0; i < blinkingCount; i++){
        spriteRenderer.material = blinkMaterial;
        yield return new WaitForSeconds(blinkInterval);
        spriteRenderer.material = originalMaterial;
        yield return new WaitForSeconds(blinkInterval);
      }

      isInvincible = false;
    }
}
