using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] public Material material1;
    [SerializeField] public Material material2;
    [SerializeField] public Renderer charModel;
    [SerializeField] public Renderer charModelTshirt;
    [SerializeField] public GameObject toyHammer;

    [SerializeField] GameObject shoe1;
    [SerializeField] GameObject shoe2;

    [SerializeField] public float speed;
    [SerializeField] public bool isShirted;
    [SerializeField] public bool isTurned;
    [SerializeField] public bool isSpeedUp;

    public SplashSpawner splashSpawner;
    public Animator animator;
    public float WaitForRun;
    private float t;
    private float tempSpeed;


    protected void Start()
    {
        splashSpawner = FindObjectOfType<SplashSpawner>();
        if (charModel)
        {
            charModel.material = material1;
        }
        if (charModelTshirt)
        {
            charModelTshirt.material = material1;
        }
        //        charModelTshirt.gameObject.SetActive(false);
    }

    protected void Update()
    {
        t += Time.deltaTime;
        if (t >= WaitForRun)
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
        charModelTshirt.material = material2;
    }
    public void GetShoes()
    {
        shoe1.SetActive(true);
        shoe2.SetActive(true);
    }
    public void StopFight()
    {
        animator.SetBool("isHitting", false);
    }
    public void Stop()
    {
        tempSpeed = speed;
        speed = 0;
    }
    public void GoOn()
    {
        speed = tempSpeed;
    }

}
