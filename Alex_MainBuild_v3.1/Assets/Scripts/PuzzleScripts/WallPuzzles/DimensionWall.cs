using UnityEngine;
using System.Collections;

public enum World { LEFT = 8, RIGHT = 9}
public class DimensionWall : MonoBehaviour 
{
    //TODO Make private and use Resource.Load
	private Material transparent, specular;
	private Shader sTransparent, sSpecular;

    public World CameraSpace { get; private set; }

    private GameObject tabGameObject;
    private Tab tab;

	// Use this for initialization
	void Awake () 
    {
        CameraSpace = (World)gameObject.layer;

        specular = Resources.Load("Materials/GateMatSpec") as Material;
        transparent = Resources.Load("Materials/GateMatTransp") as Material;
       
        sTransparent = Shader.Find("Transparent/Specular");
        sSpecular = Shader.Find("Specular");

        if (gameObject.GetComponentInChildren<Tab>() != null)
        {
            tabGameObject = gameObject.GetComponentInChildren<Tab>().gameObject;
            tab = gameObject.GetComponentInChildren<Tab>();
        }
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
            tabGameObject.renderer.material = tab.Transparent;
		}
		else if(this.renderer.material.shader == sTransparent)
		{
			this.renderer.material = specular;
            tabGameObject.renderer.material = tab.Specular;
		}
	}
}
