FSceneManager
=============

SceneManager for Futile, a Unity framework.

todo
-------------
[] Complete loading of tilemaps. Data is loaded, but tilesets are not.
[] Add transitions for switching scenes.


Game.cs
```csharp
FSceneManager.Instance.SetScene(new SceneStartup());
```

SceneStartup.cs
```csharp
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneStartup : FScene
{
    FLayer mLayer;
    
    public SceneStartup()
    {
		mPaused = false;
		
		mLayer = new LayerStartup(this);
        this.AddChild(mLayer);
    }
}
```

LayerStartup.cs
```csharp
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LayerStartup : FLayer
{
	public LayerStartup(FScene _parent) : base(_parent)
    {
		
    }
	
	override public void OnEnter ()
	{
		
	}
    
    override public void OnUpdate()
    {
        if(mParent.Paused)
            return;
		
		FSceneManager.Instance.SetScene(new SceneGame());
    }
}
```