using UnityEngine;
using System.Collections;

public enum World { LEFT = 8, RIGHT = 9}
public class DimensionWall : MonoBehaviour 
{
    public int layer;
	public float alpha;
    //TODO Make private and use Resource.Load
	public Material transparent, specular;
	public Shader sTransparent, sSpecular;
    public World CameraSpace { get; private set; }

    private GameObject tab;
	// Use this for initialization
	void Awake () 
    {
        CameraSpace = (World)gameObject.layer;
		alpha = .15f;

        if (gameObject.GetComponentInChildren<Tab>() != null)
            tab = gameObject.GetComponentInChildren<Tab>().gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public void SwitchWorld()
    {
        switch (CameraSpace)
        {
            case World.LEFT:
                CameraSpace = World.RIGHT;
                break;
            case World.RIGHT:
                CameraSpace = World.LEFT;
                break;
            default:
                break;
        }
    }

	public void SwitchMaterial()
	{
		if(this.renderer.material.shader == sSpecular)
		{
			this.renderer.material = transparent;
            tab.renderer.material = transparent;
		}
		else if(this.renderer.material.shader == sTransparent)
		{
			this.renderer.material = specular;
            tab.renderer.material = specular;
		}
	}
}
