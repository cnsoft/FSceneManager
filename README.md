FSceneManager
=============

SceneManager for Futile, a Unity framework.

Game.cs
<pre>
FSceneManager.Instance.SetScene(new SceneStartup());
</pre>

SceneStartup.cs
<pre>
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneStartup : FScene
{
  FLayerParallax mLayerParallax;
	LayerStartup mLayer;
	
	public SceneStartup()
	{
		// Set the scene as the parent, set the scroll direction, and pick the two scrolling images from a loaded atlas.
		mLayerParallax = new FLayerParallax(this, ScrollDirection.Down, "Background.png", "Background.png");
		this.AddChild(mLayerParallax);
		
		mLayer = new LayerStartup(this);
		this.AddChild(mLayer);;
		
		mPaused = false;
	}
}
</pre>

LayerStartup.cs
<pre>
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LayerStartup : FLayer
{
  
	
	public LayerStartup(FScene _parent) : base(_parent)
	{
		
	}
	
	override protected void HandleUpdate()
	{
		if(mParent.Paused)
			return;
		
		base.HandleUpdate();
		
	}
}
</pre>