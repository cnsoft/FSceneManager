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

public class FTile : FContainer
{
	protected FTileLayer mLayer;
	
	protected FSliceSprite mSprite;
	
	protected int mGID;
	public int GID
	{
		get { return mGID; }
	}
	
	public FTile(FTileLayer _layer, int _gid) : base()
	{
		mLayer = _layer;
		mLayer.AddChild(this);
		
		mGID = _gid;
		
		SetClip();
	}
	
	protected void SetClip()
	{
		
	}
}
