using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag == "Bala")
		{

			Destroy(collider.gameObject);

		}else if (collider.tag == "Granada")
		{

			Destroy(collider.gameObject);

		}
	}
}
