using UnityEngine;
using System.Collections;

public enum World { LEFT = 8, RIGHT = 9}
public class DimensionWall : PuzzleObject 
{
	private Material transparent, specular;
	private Shader sTransparent, sSpecular;

    public World CameraSpace { get; private set; }

    private GameObject tabGameObject;
    private Tab tab;

	// Use this for initialization
	protected override void Awake () 
    {
		base.Awake();

		setUpShaders();

        if (gameObject.GetComponentInChildren<Tab>() != null)
        {
            tabGameObject = gameObject.GetComponentInChildren<Tab>().gameObject;
            tab = gameObject.GetComponentInChildren<Tab>();
        }
	}

	private void setUpShaders()
	{
		specular = Resources.Load("Materials/GateMatSpec") as Material;
		transparent = Resources.Load("Materials/GateMatTransp") as Material;

		sTransparent = Shader.Find("Transparent/Specular");
		sSpecular = Shader.Find("Specular");
	}

	protected override void Start()
	{
		base.Start();

		CameraSpace = (World)gameObject.layer;
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

	public override void SaveState()
	{
		base.SaveState();

		tab.SaveState();
	}
}
