using UnityEngine;
using System.Collections;

public class Tab : MonoBehaviour
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
    
	private string name;

    void Start()
    {
        if (gameObject.name.Contains("_Double"))
        {
          name =  gameObject.name.Trim("_Double".ToCharArray());
        }
		else
			name = gameObject.name;
        switch (name)
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
				transparent = Resources.Load("Materials/StripesSpec") as Material;
				specular = Resources.Load("Materials/StripesTransp") as Material;
                break;
            default:
                break;
        }
    }
}
