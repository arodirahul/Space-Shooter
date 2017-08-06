using UnityEngine;
using System.Collections;

public class DestroyerBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}
