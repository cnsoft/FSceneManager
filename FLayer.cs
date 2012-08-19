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

public class FLayer : FContainer, FMultiTouchableInterface
{
	protected int mFrameCount = 0;
	
	protected FScene mParent;
	public FScene Parent
	{
		get { return mParent; }
		set { mParent = value; }
	}
	
	public FLayer (FScene _parent)
	{
		mParent = _parent;
	}
	
	override public void HandleAddedToStage()
	{
		base.HandleAddedToStage();
		Futile.touchManager.AddMultiTouchTarget(this);
		Futile.instance.SignalUpdate += HandleUpdate;
		Futile.instance.SignalResize += HandleResize;	
	}
	
	override public void HandleRemovedFromStage()
	{
		Futile.touchManager.RemoveMultiTouchTarget(this);
		Futile.instance.SignalUpdate -= HandleUpdate;
		Futile.instance.SignalResize -= HandleResize;
		base.HandleRemovedFromStage();	
	}
	
	protected void HandleResize(bool wasOrientationChange)
	{
			
	}
	
	virtual protected void HandleUpdate ()
	{
		mFrameCount++;
	}
	
	public void HandleMultiTouch(FTouch[] touches)
	{
		
	}
}
