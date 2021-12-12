using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] public Material material1;
    [SerializeField] public Material material2;
    [SerializeField] public Renderer charModel;

    [SerializeField] GameObject shoe1;
    [SerializeField] GameObject shoe2;

    [SerializeField] public float speed;
    [SerializeField] public bool isShirted;
    [SerializeField] public bool isTurned;
    [SerializeField] public bool isSpeedUp;

    public Animator animator;
    private float t;


    protected void Start()
    {
        animator = GetComponent<Animator>();
        charModel.material = material1;
    }

    protected void Update()
    {
        t += Time.deltaTime;
        if (t >= 1f)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            var rotationVector = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rotationVector + new Vector3(0, 180, 0));
        }

    }
    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out ICollectable collectable))
        {
            collectable.GetBoost(gameObject);
        }
    }
    public void ChangeSide()
    {
        charModel.material = material2;
    }
    public void GetShoes()
    {
        shoe1.SetActive(true);
        shoe2.SetActive(true);
    }

}
