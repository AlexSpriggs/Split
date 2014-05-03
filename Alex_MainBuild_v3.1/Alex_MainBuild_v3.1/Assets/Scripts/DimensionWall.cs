using UnityEngine;
using System.Collections;

public class DimensionWall : MonoBehaviour {

    public int layer;
	public float alpha;
	public Material transparent, specular;
	public Shader sTransparent, sSpecular;
	public bool SameLayer;
	// Use this for initialization
	void Awake () {
        layer = gameObject.layer;

		alpha = .15f;
	}
	
	// Update is called once per frame
	void Update () {
        layer = gameObject.layer;
	}

	public void Switch()
	{
		if(SameLayer)
			SameLayer = false;
		else
			SameLayer = true;
		
		if(this.renderer.material.shader == sSpecular)
		{
			this.renderer.material = transparent;
		}
		else if(this.renderer.material.shader == sTransparent)
		{
			this.renderer.material = specular;
		}
	}
}
