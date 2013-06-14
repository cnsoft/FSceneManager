using UnityEngine;
using System.Collections;

public class FCameraLayer : FLayer
{
	FNode mFollowObject;
	
	public FCameraLayer(FScene _parent) : base(_parent)
	{
		mFollowObject = null;
	}
	
	override public void OnUpdate()
	{
		if(mFollowObject != null)
		{
			x = mFollowObject.x;
			y = mFollowObject.y;
		}
	}
}
