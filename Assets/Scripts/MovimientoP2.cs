using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP2 : MonoBehaviour
{
	public float life = 5;
	public float speed = 2f;
	public Transform target;
	public Transform m_transform;
	public GameObject sombraHabilidadEnemigo;
    public Transform targetHabilidadK;
	GameManager gm;
	 float cooldownHabilidades ;
	public float cooldownHabilidadesMax = 5;
	Bala bl;
	bool slow;
	public float slowCd;

	// Start is called before the first frame update
	void Start()
    {
		slow = false;
		cooldownHabilidades = cooldownHabilidadesMax;
		gm = FindObjectOfType<GameManager>();
		bl = FindObjectOfType<Bala>();
		slowCd = -1;
	}

    // Update is called once per frame
    void Update()
    {
		Movement();
		Habilidades();

		if (life <= 0)
		{
			KillEnemy();
			gm.puntuacion1 += 20;
		}
		
		if(slow)
        {
			speed = 0.25f;

        }
        else
        {
			speed = 0.5f;
        }

		if(slowCd>0)
        {
			slowCd -= Time.deltaTime;
        }
        if(slowCd<=0)
        {
			speed = 0.5f;
        }
	}

	public void Movement()
	{
		if (Input.GetKey(KeyCode.Y))
		{
			m_transform.position = new Vector2(m_transform.position.x, m_transform.position.y + speed * Time.deltaTime);



			transform.right = Vector2.up;
		}


		if (Input.GetKey(KeyCode.H))
		{
			m_transform.position = new Vector2(m_transform.position.x, m_transform.position.y - speed * Time.deltaTime);



			transform.right = Vector2.down;
		}


		if (Input.GetKey(KeyCode.J))
		{
			m_transform.position = new Vector2(m_transform.position.x + speed * Time.deltaTime, m_transform.position.y);


			transform.right = Vector2.right;
		}

		if (Input.GetKey(KeyCode.G))
		{
			m_transform.position = new Vector2(m_transform.position.x - speed * Time.deltaTime, m_transform.position.y);

			transform.right = Vector2.left;
		}

		if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.J))
		{
			transform.right = Vector2.up + Vector2.right* speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.G))
		{
			transform.right = Vector2.up + Vector2.left*speed* Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.H))
		{
			transform.right = Vector2.down + Vector2.left *speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.J))
		{
			transform.right = Vector2.down + Vector2.right * speed * Time.deltaTime;
		}
	}


	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag == "Bala")
		{
			life = life - collider.GetComponent<Bala>().damageBullet;
			Destroy(collider.gameObject);

		}
		if (collider.tag =="Granada")
        {
			Destroy(collider.gameObject);

		}


		if (collider.tag == "Slow")
		{
			slow = true;
			slowCd = 4;

        }
        

	}
	private void OnTriggerExit2D(Collider2D collider)
	{

		

		if (collider.tag == "Slow")
		{
			slow = false;


		}
		

	}
	void Habilidades ()

		
    {
		
		if (cooldownHabilidades>0)
		{
			cooldownHabilidades -= Time.deltaTime;

		}
		 
		if (Input.GetKey(KeyCode.K) && cooldownHabilidades <= 0 )
		{
			Instantiate(sombraHabilidadEnemigo, targetHabilidadK.position, targetHabilidadK.rotation);

			m_transform.position = targetHabilidadK.position;
			



			cooldownHabilidades = cooldownHabilidadesMax;	

		}
			
		
		




	}
	void KillEnemy()
	{
		Destroy(gameObject);
		
	}
}
