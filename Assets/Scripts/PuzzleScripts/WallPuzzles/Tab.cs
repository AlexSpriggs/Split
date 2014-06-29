using UnityEngine;
using System.Collections;

public class Tab : PuzzleObject
{
    private Material transparent;
    public Material Transparent 
    { 
        get { return transparent; } 
    }

    private Material specular;
    public Material Specular 
    { 
        get { return specular; }
    }
    
	private string nameTab;

    protected override void Start()
    {
		removeDouble();

        switch (nameTab)
        {
            case "FilledIn":
                transparent = Resources.Load("Materials/FilledInTransp") as Material;
                specular = Resources.Load("Materials/FilledInSpec") as Material;
                break;
            case "Plaid":
				transparent = Resources.Load("Materials/PlaidTransp") as Material;
				specular = Resources.Load("Materials/PlaidSpec") as Material;
                break;
            case "Stripes":
				transparent = Resources.Load("Materials/StripesTransp") as Material;
				specular = Resources.Load("Materials/StripesSpec") as Material;
                break;
            default:
                break;
        }

		base.Start();
    }

	private void removeDouble()
	{
		if (gameObject.name.Contains("_Double"))
		{
			nameTab = gameObject.name.Trim("_Double".ToCharArray());
		}
		else
			nameTab = gameObject.name;
	}

	public void SaveState()
	{
		saveState();
	}
}
