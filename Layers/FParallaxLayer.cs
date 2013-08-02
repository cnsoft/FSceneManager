/*
- THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
- IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
- FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
- AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
- LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
- OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
- THE SOFTWARE.
*/

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
	
	public FParallaxLayer(FScene parent) : base(parent)
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
