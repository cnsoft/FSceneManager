/*
- THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
- IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
- FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
- AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
- LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
- OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
- THE SOFTWARE.
*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FTileLayer : FContainer
{
	protected FTileMap mMap;
	public FTileMap Map
	{
		get { return mMap; }
	}
	
	protected FTile[,] mTiles;
	
	protected string mName;
	public string Name
	{
		get { return mName; }
	}
	
	protected int mWidth;
	public int Width
	{
		get { return mWidth; }
	}
	protected int mHeight;
	public int Height
	{
		get { return mHeight; }
	}
	
	public FTileLayer(FTileMap _map, string _name, int _width, int _height, float _opacity, List<int> _tiles) : base()
	{
		mMap = _map;
		
		mName = _name;
		
		mWidth = _width;
		mHeight = _height;
		
		alpha = _opacity;
		
		mTiles = new FTile[mWidth, mHeight];
		
		ParseTiles(_tiles);
	}
	
	protected void ParseTiles(List<int> _tiles)
	{
		int xPos = 0;
		int yPos = 0;
		
		foreach(int tile in _tiles)
		{
			FTile newTile = new FTile(tile);
			mTiles[xPos, yPos] = newTile;
			
			xPos++;
			
			if(xPos % mWidth == 0)
			{
				xPos = 0;
				yPos++;
			}
		}
	}
	
	/* Unused Iso functions
	
	public void UpdateTilePositionsIso()
	{
		for(int yPos = 0; yPos < mHeight; yPos++)
		{
			for(int xPos = mWidth - 1; xPos >= 0; xPos--)
			{
				mTiles[xPos, yPos].SetPosition(OrthoToIso(xPos, yPos));
			}
		}
	}
	
	private Vector2 OrthoToIso(int _x, int _y)
	{
		float x = (_x * mMap.TileWidth / 2) - (-_y * mMap.TileWidth / 2);
		float y = (-_y * mMap.TileHeight / 2) + (_x * mMap.TileHeight / 2);
		
		return new Vector2(x, y);
	}
	
	public void UpdateZOrder()
	{
		for(int yPos = 0; yPos < mHeight; yPos++)
		{
			for(int xPos = mWidth - 1; xPos >= 0; xPos--)
			{
				if(IsArrayInRange(xPos, yPos) && mTiles[xPos, yPos] != null)
				{
					mTiles[xPos, yPos].MoveToFront();
				}
			}
		}	
	}
	
	public bool IsArrayInRange(int _x, int _y)
	{
		if(_x < 0 || _y < 0)
			return false;
		
		if( _x >= mWidth || _y >= mHeight)
			return false;
		
		return true;
	}
	
	*/
	
	protected void DebugTiles()
	{
		string debuginfo = "";
		for(int y = 0; y < mHeight; y++)
		{
			for(int x = 0; x < mWidth; x++)
			{
				debuginfo += mTiles[x, y].GID.ToString() + " ";
			}
			
			Debug.Log(debuginfo);
			debuginfo = "";
		}
	}
}
