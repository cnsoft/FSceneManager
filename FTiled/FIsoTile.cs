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

public class FIsoTile : FContainer
{
	FContainer mParent;
	
	FSprite mSprite;
	
	FLabel mLabel;
	
	string mKey;
	
	protected Vector2 mArrayPosition;
	public Vector2 ArrayPosition
	{
		get { return mArrayPosition; }
		set { mArrayPosition = value; }
	}
	
	public FIsoTile(FContainer _parent, string _key, int _x, int _y) : base()
	{	
		mParent = _parent;
		mParent.AddChild(this);
		
		mKey = _key;
		mSprite = new FSprite(mKey);
		AddChild(mSprite);
		
		mLabel = new FLabel("Font", "");
		AddChild(mLabel);
		
		mArrayPosition = new Vector2(_x, _y);
	}
	
	public FIsoTile(FContainer _parent, string _key) : this(_parent, _key, 0, 0) { }
	
	public void SetLabel(string _key)
	{
		mLabel.text = _key;
	}
}
