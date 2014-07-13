using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{
	private Bounds bounds;
	public Bounds RendererBounds { get { return bounds; } }

	void Start () 
	{
		bounds = new Bounds(renderer.bounds.center, renderer.bounds.size);
	}

	void Update() //TODO Change to Target Handle Message
	{
		if(bounds != gameObject.transform.renderer.bounds)
		{
			bounds = new Bounds(renderer.bounds.center, renderer.bounds.size);
		}

		//TODO Implement Targets Send Message
	}
}
