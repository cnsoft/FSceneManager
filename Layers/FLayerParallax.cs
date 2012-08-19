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
	
	public FLayerParallax(FScene _parent, string _backgroundPath, string _background2Path) : base(_parent)
	{	
		mBackground = new FSprite(_backgroundPath);
		this.AddChild(mBackground);
		mBackground2 = new FSprite(_background2Path);
		this.AddChild(mBackground2);
		mBackground2.x = mBackground.width;
		
		mSpeed = 1;
	}
	
	override protected void HandleUpdate()
	{
		if(mParent.Paused)
			return;
		
		base.HandleUpdate();
		
		mBackground.x -= mSpeed;
		mBackground2.x -= mSpeed;
		
		if(mBackground.x < 0 - mBackground.width)
			mBackground.x = mBackground2.x + mBackground2.width;
		if(mBackground2.x < 0 - mBackground2.width)
			mBackground2.x = mBackground.x + mBackground.width;
	}
}