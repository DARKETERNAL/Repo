using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Enemy : MonoBehaviour
{
    protected enum EnemyType
    {
        None,
        Soldier,
        Ghost
    };

    public delegate void OnDamageTaken();

    [SerializeField]
    private EnemyType enemyType;

    [SerializeField]
    protected float maxHP = 1;

    [SerializeField]
    private float movementSpeed = 1F;

    private float currentHP = 0;

    private Collider myCollider;
    private Rigidbody myRigidbody;

    protected OnDamageTaken onDamageTaken;

    public OnDamageTaken OnDamageTakenDelegate
    {
        get
        {
            return onDamageTaken;
        }
    }

    protected Collider MyCollider
    {
        get
        {
            return myCollider;
        }

        private set
        {
            myCollider = value;
        }
    }

    protected Rigidbody MyRigidbody
    {
        get
        {
            return myRigidbody;
        }

        private set
        {
            myRigidbody = value;
        }
    }

    protected float CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
        }
    }

    protected float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        CurrentHP = maxHP;
        MyCollider = GetComponent<Collider>();
        MyRigidbody = GetComponent<Rigidbody>();

        onDamageTaken += Damage;

        //switch (enemyType)
        //{
        //    case EnemyType.Ghost:
        //        MyCollider.isTrigger = true;
        //        break;

        //    default:
        //        MyCollider.isTrigger = false;
        //        break;
        //}
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    protected virtual void Damage()
    {
        CurrentHP -= 1;

        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnDestroy()
    {
        onDamageTaken -= Damage;
    }

    protected abstract void Move();

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal") || collision.gameObject.CompareTag("Player"))
        {
            print("GameOver");
            Destroy(gameObject);
        }
    }
}