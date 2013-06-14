using UnityEngine;
using System.Collections;

public class FParallaxLayer : FLayer
{
	protected FSprite mBackground;
	protected FSprite mBackground2;
	
	protected float mVelocity = 50.0f;
	public float Velocity
	{
		get { return mVelocity; }
		set { mVelocity = value; }
	}
	
	public FParallaxLayer(FScene _parent) : base(_parent)
	{
		mBackground = new FSprite("Background");
		AddChild(mBackground);
		
		mBackground2 = new FSprite("Background2");
		mBackground2.x = mBackground.x + mBackground2.width;
		AddChild(mBackground2);
	}
	
	public override void OnUpdate ()
	{
		if(mParent.Paused)
			return;
		
		ScrollLeft();
		
		mVelocity *= 1.001f;
	}
	
	private void ScrollLeft()
	{
		mBackground.x -= Time.smoothDeltaTime * mVelocity;
		mBackground2.x -= Time.smoothDeltaTime * mVelocity;
		
		if(mBackground.x < 0 - mBackground.width)
			mBackground.x = mBackground2.x + mBackground.width;
		if(mBackground2.x < 0 - mBackground2.width)
			mBackground2.x = mBackground.x + mBackground2.width;
	}
}
