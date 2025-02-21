using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public class mouvement : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;
    [SerializeField] private float _modifierAnimTranslation;
    private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnMouvement(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitessePromenade;
        directionInput = new Vector3(0f, directionAvecVitesse.y, directionAvecVitesse.x);
    }
    void FixedUpdate()
    {

        Vector3 mouvement = directionInput;
        _rb.AddForce(mouvement, ForceMode.VelocityChange);

        Vector3 vitesseSurPlane = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _animator.SetFloat("hautBas", vitesseSurPlane.magnitude * _modifierAnimTranslation);
        _animator.SetFloat("AvanceRecule", vitesseSurPlane.magnitude);
    }
}
