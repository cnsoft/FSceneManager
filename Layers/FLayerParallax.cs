/*
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ScrollDirection
{
	Up,
	Down,
	Left,
	Right
};

public class FLayerParallax : FLayer
{
	protected FSprite mBackground;
	public string Background
	{
		set { mBackground = new FSprite(value); }	
	}
	
	protected FSprite mBackground2;
	public string Background2
	{
		set { mBackground2 = new FSprite(value); }	
	}
	
	protected int mSpeed;
	public int Speed
	{
		get { return mSpeed; }
		set { mSpeed = value; }
	}
	
	protected ScrollDirection mScrollDirection;
	public ScrollDirection Direction
	{
		get { return mScrollDirection; }
		set { mScrollDirection = value; }
	}
	
	public FLayerParallax(FScene _parent, ScrollDirection _direction, string _backgroundPath, string _background2Path) : base(_parent)
	{	
		mBackground = new FSprite(_backgroundPath);
		this.AddChild(mBackground);
		mBackground2 = new FSprite(_background2Path);
		this.AddChild(mBackground2);
		
		mScrollDirection = _direction;
		
		if(mScrollDirection == ScrollDirection.Left)
			mBackground2.x = mBackground.width;
		else if(mScrollDirection == ScrollDirection.Right)
			mBackground2.x = mBackground.x - mBackground.width;
		else if(mScrollDirection == ScrollDirection.Up)
			mBackground2.y = mBackground.y - mBackground.height;
		else if(mScrollDirection == ScrollDirection.Down)
			mBackground2.y = mBackground.y + mBackground.height;
		
		mSpeed = 1;
	}
	
	override protected void HandleUpdate()
	{
		if(mParent.Paused)
			return;
		
		base.HandleUpdate();
		
		if(mScrollDirection == ScrollDirection.Left)
			ScrollLeft();
		else if(mScrollDirection == ScrollDirection.Right)
			ScrollRight();
		else if(mScrollDirection == ScrollDirection.Up)
			ScrollUp();
		else if(mScrollDirection == ScrollDirection.Down)
			ScrollDown();
	}
	
	private void ScrollLeft()
	{
		mBackground.x -= mSpeed;
		mBackground2.x -= mSpeed;
		
		if(mBackground.x < 0 - mBackground.width)
			mBackground.x = mBackground2.x + mBackground2.width;
		if(mBackground2.x < 0 - mBackground2.width)
			mBackground2.x = mBackground.x + mBackground.width;
	}
	
	private void ScrollRight()
	{
		mBackground.x += mSpeed;
		mBackground2.x += mSpeed;
		
		if(mBackground.x > mBackground.width)
			mBackground.x = mBackground2.x - mBackground2.width;
		if(mBackground2.x > mBackground2.width)
			mBackground2.x = mBackground.x - mBackground.width;
	}
	
	private void ScrollUp()
	{
		mBackground.y += mSpeed;
		mBackground2.y += mSpeed;
		
		if(mBackground.y > mBackground.height)
			mBackground.y = mBackground2.y - mBackground2.height;
		if(mBackground2.y > mBackground2.height)
			mBackground2.y = mBackground.y - mBackground.height;
	}
	
	private void ScrollDown()
	{
		mBackground.y -= mSpeed;
		mBackground2.y -= mSpeed;
		
		if(mBackground.y < 0 - mBackground.height)
			mBackground.y = mBackground2.y + mBackground2.height;
		if(mBackground2.y < 0 - mBackground2.height)
			mBackground2.y = mBackground.y + mBackground.height;
	}
}