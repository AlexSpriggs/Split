using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour, IReceiver<Target>
{
	private Bounds bounds;
	public Bounds RendererBounds { get { return bounds; } }

	void Start () 
	{
		bounds = new Bounds(renderer.bounds.center, renderer.bounds.size);
		SubScribe();
	}

	public void HandleMessage(Telegram<Target> telegram)
	{
		if(bounds != gameObject.transform.renderer.bounds && telegram.Target == this)
		{
			bounds = new Bounds(renderer.bounds.center, renderer.bounds.size);

			MessageDispatcher.Instance.DispatchMessage(new Telegram<Target>(this, this));
		}
	}

	public void SubScribe()
	{
		MessageDispatcher.Instance.SendMessageTarget +=
			new MessageDispatcher.SendMessageHandler<Telegram<Target>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		throw new System.NotImplementedException();
	}
}
