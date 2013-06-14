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
		int x = 0;
		int y = 0;
		
		foreach(int tile in _tiles)
		{
			FTile newTile = new FTile(this, tile);
			newTile.SetPosition(x * mMap.TileWidth, y * mMap.TileHeight);
			mTiles[x, y] = newTile;
			
			x++;
			
			if(x % mWidth == 0)
			{
				x = 0;
				y++;
			}
		}
	}
	
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
