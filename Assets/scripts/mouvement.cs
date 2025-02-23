using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
public class mouvement : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;
    [SerializeField] private float _modifierAnimTranslation;
    private Animator _animator;

    public float speed = 0.25f;

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

        Vector3 vitesseSurPlane = new Vector3(0f, _rb.velocity.x, _rb.velocity.z);
        _animator.SetFloat("AvanceRecule", vitesseSurPlane.magnitude *speed);

        Vector3 vitesseSurPlaneY = new Vector3(0f, _rb.velocity.x, _rb.velocity.y);
        _animator.SetFloat("hautBas", vitesseSurPlaneY.magnitude *speed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _vitessePromenade = speed * 2;  
        }
        else
        {
            _vitessePromenade = speed;  
        }
        Vector3 movement = new Vector3(0, _rb.velocity.y, _rb.velocity.z) * speed * Time.deltaTime;
        _rb.MovePosition(transform.position + movement);
    }
}
