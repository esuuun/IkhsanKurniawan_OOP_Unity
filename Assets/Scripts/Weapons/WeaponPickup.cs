using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{   
    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder);
        }
    }

    void Start()
    {
        if (weapon != null)
        {
            // Initialize all related methods with false
            TurnVisual(false);
            weapon.transform.SetParent(transform, false);
            weapon.transform.localPosition = transform.position;
            weapon.parentTransform = transform;
        }
    }

    void Update()
    {
        // ...existing code...
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon currentWeapon = other.GetComponentInChildren<Weapon>();
            if (currentWeapon != null)
            {
                currentWeapon.transform.SetParent(null); // Detach the current weapon from the player
                currentWeapon.transform.position = transform.position; // Move it to the pickup position
                TurnVisual(false, currentWeapon); // Hide the current weapon
            }

            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = Vector3.zero; // Reset position relative to player
            TurnVisual(true, weapon);
            
        }
    }

    void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            // Enable or disable all MonoBehaviour components in the Weapon object
            foreach (var component in weapon.GetComponentsInChildren<MonoBehaviour>())
            {
                component.enabled = on;
            }

            // Enable or disable the Animator component
            Animator animator = weapon.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.enabled = on;
            }

            // Enable or disable the renderer components
            foreach (var renderer in weapon.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = on;
            }
        }
    }

    void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon != null)
        {
            // Enable or disable all MonoBehaviour components in the Weapon object
            foreach (var component in weapon.GetComponentsInChildren<MonoBehaviour>())
            {
                component.enabled = on;
            }

            // Enable or disable the Animator component
            Animator animator = weapon.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.enabled = on;
            }

            // Enable or disable the renderer components
            foreach (var renderer in weapon.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = on;
            }
        }
    }
}
