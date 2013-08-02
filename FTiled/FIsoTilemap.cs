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

public class FIsoTilemap : FLayer
{
	FIsoTile[,] mTiles;
	
	int mTileWidth = 32;
	int mTileHeight = 16;
	public float mScale = 1.0f;
	
	int mArrayMaxX = 6;
	int mArrayMaxY = 6;
	
	bool mUpdateZOrder = true;
	
	public FIsoTilemap(FScene _parent) : base(_parent)
	{
		mTiles = new FIsoTile[mArrayMaxX, mArrayMaxY];
	}
	
	public override void OnEnter ()
	{
		SetupMap();
		
		mTiles[0, 0] = new FIsoTile(this, "1");
		mTiles[1, 0] = new FIsoTile(this, "1");
		mTiles[2, 0] = new FIsoTile(this, "1");
		mTiles[3, 0] = new FIsoTile(this, "1");
		mTiles[4, 0] = new FIsoTile(this, "1");
		mTiles[5, 0] = new FIsoTile(this, "1");
		
		mTiles[0, 1] = new FIsoTile(this, "1");
		mTiles[1, 1] = new FIsoTile(this, "2");
		mTiles[2, 1] = new FIsoTile(this, "2");
		mTiles[3, 1] = new FIsoTile(this, "2");
		mTiles[4, 1] = new FIsoTile(this, "2");
		mTiles[5, 1] = new FIsoTile(this, "1");
		
		mTiles[0, 2] = new FIsoTile(this, "1");
		mTiles[1, 2] = new FIsoTile(this, "0");
		mTiles[2, 2] = new FIsoTile(this, "0");
		mTiles[3, 2] = new FIsoTile(this, "0");
		mTiles[4, 2] = new FIsoTile(this, "0");
		mTiles[5, 2] = new FIsoTile(this, "1");
		
		mTiles[0, 3] = new FIsoTile(this, "12");
		mTiles[1, 3] = new FIsoTile(this, "0");
		mTiles[2, 3] = new FIsoTile(this, "0");
		mTiles[3, 3] = new FIsoTile(this, "0");
		mTiles[4, 3] = new FIsoTile(this, "0");
		mTiles[5, 3] = new FIsoTile(this, "1");
		
		mTiles[0, 4] = new FIsoTile(this, "12");
		mTiles[1, 4] = new FIsoTile(this, "2");
		mTiles[2, 4] = new FIsoTile(this, "2");
		mTiles[3, 4] = new FIsoTile(this, "2");
		mTiles[4, 4] = new FIsoTile(this, "2");
		mTiles[5, 4] = new FIsoTile(this, "1");
		
		mTiles[0, 5] = new FIsoTile(this, "10");
		mTiles[1, 5] = new FIsoTile(this, "11");
		mTiles[2, 5] = new FIsoTile(this, "11");
		mTiles[3, 5] = new FIsoTile(this, "1");
		mTiles[4, 5] = new FIsoTile(this, "1");
		mTiles[5, 5] = new FIsoTile(this, "1");
		
		UpdateTilePositions();
	}
	
	override public void OnUpdate()
	{	
		if(mParent.Paused)
			return;
		
		if(mUpdateZOrder)
			UpdateZOrder();
	}

	override public void HandleMultiTouch(FTouch[] touches)
	{
		if(mParent.Paused)
			return;

		foreach(FTouch touch in touches)
		{
			// Where was the screen touched
			//Vector2 touchPos = this.GlobalToLocal(touch.position);

			if(touch.phase == TouchPhase.Began)
			{

			}
			else if(touch.phase == TouchPhase.Moved)
			{

			}
			else if(touch.phase == TouchPhase.Ended)
			{

			}
		}
	}
	
	public void UpdateTilePositions()
	{
		for(int yPos = 0; yPos < mArrayMaxY; yPos++)
		{
			for(int xPos = mArrayMaxX - 1; xPos >= 0; xPos--)
			{
				if(IsArrayInRange(xPos, yPos) && mTiles[xPos, yPos] != null)
				{
					mTiles[xPos, yPos].SetPosition(OrthoToIso(xPos, yPos));
				}
			}
		}
	}
	
	public void UpdateZOrder()
	{
		for(int yPos = 0; yPos < mArrayMaxY; yPos++)
		{
			for(int xPos = mArrayMaxX - 1; xPos >= 0; xPos--)
			{
				if(IsArrayInRange(xPos, yPos) && mTiles[xPos, yPos] != null)
				{
					mTiles[xPos, yPos].MoveToFront();
				}
			}
		}	
	}
	
	private Vector2 OrthoToIso(int _x, int _y)
	{
		float x = ((_x * mTileWidth / 2) - (-_y * mTileWidth / 2)) * mScale;
		float y = ((-_y * mTileHeight / 2) + (_x * mTileHeight / 2)) * mScale;
		
		return new Vector2(x, y);
	}
	
	private Vector2 IsoToOrth(int _x, int _y)
	{
		return Vector2.zero;
	}
	
	public bool IsArrayInRange(int _x, int _y)
	{
		if(_x < 0 || _y < 0)
			return false;
		
		if( _x >= mArrayMaxX || _y >= mArrayMaxY)
			return false;
		
		return true;
	}
	
	public void SetupMap()
	{
		for(int yPos = 0; yPos < mArrayMaxY; yPos++)
		{
			for(int xPos = mArrayMaxX - 1; xPos >= 0; xPos--)
			{
				mTiles[xPos, yPos] = null;
			}
		}
	}
	
	public void SetupArrayPositions()
	{
		for(int yPos = 0; yPos < mArrayMaxY; yPos++)
		{
			for(int xPos = 0; xPos < mArrayMaxX; xPos++)
			{
				if(IsArrayInRange(xPos, yPos) && mTiles[ xPos, yPos] != null)
				{
					mTiles[xPos, yPos].ArrayPosition.Set(xPos, yPos);
					
					//string label = zPos.ToString() + ":" + xPos.ToString() + ":" + yPos.ToString();
					//mTiles[zPos, xPos, yPos].SetLabel(label);
				}
			}
		}
	}
}

/*
using UnityEngine;
using System.Collections;

public class FIsoTilemap : FLayer
{
	FIsoTile[,,] mTiles;
	
	int mTileWidth = 32;
	int mTileHeight = 16;
	float mScale = 1.0f;
	
	int mArrayMaxX = 6;
	int mArrayMaxY = 6;
	int mArrayMaxZ = 3;
	
	public FIsoTilemap(FScene _parent) : base(_parent)
	{
		mTiles = new FIsoTile[mArrayMaxZ, mArrayMaxX, mArrayMaxY];
		
		shouldSortByZ = true;
	}
	
	public void FillMap()
	{
		SetupMap();
		
		mTiles[0, 0] = new FIsoTile(this, "1");
		mTiles[1, 0] = new FIsoTile(this, "1");
		mTiles[2, 0] = new FIsoTile(this, "1");
		mTiles[3, 0] = new FIsoTile(this, "1");
		mTiles[4, 0] = new FIsoTile(this, "1");
		mTiles[5, 0] = new FIsoTile(this, "1");
		
		mTiles[0, 1] = new FIsoTile(this, "1");
		mTiles[1, 1] = new FIsoTile(this, "2");
		mTiles[2, 1] = new FIsoTile(this, "2");
		mTiles[3, 1] = new FIsoTile(this, "2");
		mTiles[4, 1] = new FIsoTile(this, "2");
		mTiles[5, 1] = new FIsoTile(this, "1");
		
		mTiles[0, 2] = new FIsoTile(this, "1");
		mTiles[1, 2] = new FIsoTile(this, "0");
		mTiles[2, 2] = new FIsoTile(this, "0");
		mTiles[3, 2] = new FIsoTile(this, "0");
		mTiles[4, 2] = new FIsoTile(this, "0");
		mTiles[5, 2] = new FIsoTile(this, "1");
		
		mTiles[0, 3] = new FIsoTile(this, "1");
		mTiles[1, 3] = new FIsoTile(this, "0");
		mTiles[2, 3] = new FIsoTile(this, "0");
		mTiles[3, 3] = new FIsoTile(this, "0");
		mTiles[4, 3] = new FIsoTile(this, "0");
		mTiles[5, 3] = new FIsoTile(this, "1");
		
		mTiles[0, 4] = new FIsoTile(this, "1");
		mTiles[1, 4] = new FIsoTile(this, "2");
		mTiles[2, 4] = new FIsoTile(this, "2");
		mTiles[3, 4] = new FIsoTile(this, "2");
		mTiles[4, 4] = new FIsoTile(this, "2");
		mTiles[5, 4] = new FIsoTile(this, "1");
		
		mTiles[0, 5] = new FIsoTile(this, "1");
		mTiles[1, 5] = new FIsoTile(this, "1");
		mTiles[2, 5] = new FIsoTile(this, "1");
		mTiles[3, 5] = new FIsoTile(this, "1");
		mTiles[4, 5] = new FIsoTile(this, "1");
		mTiles[5, 5] = new FIsoTile(this, "1");
		
		//mTiles[1, 0, 0] = new FIsoTile(this, "0");
		
		//mTiles[1, 5, 0] = new FIsoTile(this, "0");
		//mTiles[2, 4, 3] = new FIsoTile(this, "0");
		
		//SetupArrayPositions();
	}
	
	public override void OnEnter ()
	{
		SetupMap();
		
		mTiles[0, 0] = new FIsoTile(this, "1");
		mTiles[1, 0] = new FIsoTile(this, "1");
		mTiles[2, 0] = new FIsoTile(this, "1");
		mTiles[3, 0] = new FIsoTile(this, "1");
		mTiles[4, 0] = new FIsoTile(this, "1");
		mTiles[5, 0] = new FIsoTile(this, "1");
		
		mTiles[0, 1] = new FIsoTile(this, "1");
		mTiles[1, 1] = new FIsoTile(this, "2");
		mTiles[2, 1] = new FIsoTile(this, "2");
		mTiles[3, 1] = new FIsoTile(this, "2");
		mTiles[4, 1] = new FIsoTile(this, "2");
		mTiles[5, 1] = new FIsoTile(this, "1");
		
		mTiles[0, 2] = new FIsoTile(this, "1");
		mTiles[1, 2] = new FIsoTile(this, "0");
		mTiles[2, 2] = new FIsoTile(this, "0");
		mTiles[3, 2] = new FIsoTile(this, "0");
		mTiles[4, 2] = new FIsoTile(this, "0");
		mTiles[5, 2] = new FIsoTile(this, "1");
		
		mTiles[0, 3] = new FIsoTile(this, "1");
		mTiles[1, 3] = new FIsoTile(this, "0");
		mTiles[2, 3] = new FIsoTile(this, "0");
		mTiles[3, 3] = new FIsoTile(this, "0");
		mTiles[4, 3] = new FIsoTile(this, "0");
		mTiles[5, 3] = new FIsoTile(this, "1");
		
		mTiles[0, 4] = new FIsoTile(this, "1");
		mTiles[1, 4] = new FIsoTile(this, "2");
		mTiles[2, 4] = new FIsoTile(this, "2");
		mTiles[3, 4] = new FIsoTile(this, "2");
		mTiles[4, 4] = new FIsoTile(this, "2");
		mTiles[5, 4] = new FIsoTile(this, "1");
		
		mTiles[0, 5] = new FIsoTile(this, "1");
		mTiles[1, 5] = new FIsoTile(this, "1");
		mTiles[2, 5] = new FIsoTile(this, "1");
		mTiles[3, 5] = new FIsoTile(this, "1");
		mTiles[4, 5] = new FIsoTile(this, "1");
		mTiles[5, 5] = new FIsoTile(this, "1");
	}
	
	override public void OnUpdate()
	{	
		if(mParent.Paused)
			return;
		
		
	}

	override public void HandleMultiTouch(FTouch[] touches)
	{
		if(mParent.Paused)
			return;

		foreach(FTouch touch in touches)
		{
			// Where was the screen touched
			//Vector2 touchPos = this.GlobalToLocal(touch.position);

			if(touch.phase == TouchPhase.Began)
			{

			}
			else if(touch.phase == TouchPhase.Moved)
			{

			}
			else if(touch.phase == TouchPhase.Ended)
			{

			}
		}
	}
	
	public void UpdateTilePositions()
	{
		for(int zPos = 0; zPos < mArrayMaxZ; zPos++)
		{
			for(int yPos = 0; yPos < mArrayMaxY; yPos++)
			{
				for(int xPos = 0; xPos < mArrayMaxX; xPos++)
				{
					if(IsArrayInRange(xPos, yPos, zPos) && mTiles[zPos, xPos, yPos] != null)
					{
						int x = (xPos * mTileWidth / 2) - (-yPos * mTileWidth / 2) - (mTileWidth / 2);
						int y = (-yPos * mTileHeight / 2) + (xPos * mTileHeight / 2);
						
						mTiles[zPos, xPos, yPos].SetPosition(new Vector2(x * mScale, y * mScale));
						
						mTiles[zPos, xPos, yPos].sortZ = -y;
					}
				}
			}
		}
	}
	
	private Vector2 IsoToTwoD(Vector3 _position)
	{
		int x = (int)(_position.x - _position.y);
		int y = (int)((_position.x +	 _position.y) / 2);
		
		return new Vector2(x, y);
	}
	
	public bool IsArrayInRange(int _x, int _y, int _z)
	{
		if(_x < 0 || _y < 0 || _z < 0)
			return false;
		
		if( _x >= mArrayMaxX || _y >= mArrayMaxY || _z >= mArrayMaxZ)
			return false;
		
		return true;
	}
	
	public void SetupMap()
	{
		for(int zPos = 0; zPos < mArrayMaxZ; zPos++)
		{
			for(int yPos = 0; yPos < mArrayMaxY; yPos++)
			{
				for(int xPos = 0; xPos < mArrayMaxX; xPos++)
				{
					mTiles[zPos, xPos, yPos] = null;
				}
			}
		}
	}
	
	public void SetupArrayPositions()
	{
		for(int zPos = 0; zPos < mArrayMaxZ; zPos++)
		{
			for(int yPos = 0; yPos < mArrayMaxY; yPos++)
			{
				for(int xPos = 0; xPos < mArrayMaxX; xPos++)
				{
					if(IsArrayInRange(xPos, yPos, zPos) && mTiles[zPos, xPos, yPos] != null)
					{
						mTiles[zPos, xPos, yPos].ArrayPosition.Set(xPos, yPos, zPos);
						
						string label = zPos.ToString() + ":" + xPos.ToString() + ":" + yPos.ToString();
						mTiles[zPos, xPos, yPos].SetLabel(label);
					}
				}
			}
		}
	}
}
*/