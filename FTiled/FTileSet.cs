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
using System.Text;

public class FTileSet
{
	protected FTileMap mMap;
	
	protected Dictionary<int, FAtlasElement> mTileElements;
	
	protected string mName;
	public string Name
	{
		get { return mName; }
	}
	protected string mFile;
	public string File
	{
		get { return mFile; }
	}
	
	protected int mFirstGID;
	public int FirstGID
	{
		get { return mFirstGID; }
	}
	
	protected int mImageWidth;
	public int ImageWidth
	{
		get { return mImageWidth; }
	}
    protected int mImageHeight;
	public int ImageHeight
	{
		get { return mImageHeight; }
	}
	
    protected int mTileWidth;
	public int TileWidth
	{
		get { return mTileWidth; }
	}
    protected int mTileHeight;
	public int TileHeight
	{
		get { return mTileHeight; }
	}
	
	public int Columns
	{
		get { return mImageWidth / mTileWidth; }
	}
	
	public int Rows
	{
		get { return mImageHeight / mTileHeight; }
	}
	
    protected int mMargin;
	public int Margin
	{
		get { return mMargin; }
	}
    protected int mSpacing;
	public int Spacing
	{
		get { return mSpacing; }
	}
	
	public FTileSet(FTileMap _map, string _name, string _file, int _firstGID, int _imageWidth, int _imageHeight, int _tileWidth, int _tileHeight, int _margin, int _spacing)
	{
		mMap = _map;
		
		mTileElements = new Dictionary<int, FAtlasElement>();
		
		mName = _name;
		mFile = _file;
		
		mFirstGID = _firstGID;
		
		mImageWidth = _imageWidth;
		mImageHeight = _imageHeight;
		
		mTileWidth = _tileWidth;
		mTileHeight = _tileHeight;
		
		mMargin = _margin;
		mSpacing = _spacing;
		
		CreateAtlas();
	}
	
	
	// Using jfleschler implementation of loading a tileset.
	private void CreateAtlas()
	{
		Futile.atlasManager.LoadImage("Maps/" + mName);
		FAtlasElement originalElement = Futile.atlasManager.GetElementWithName("Maps/" + mName);
		
		Vector2 textureSize = originalElement.atlas.textureSize;
		float scaleInverse = Futile.resourceScaleInverse;
		
		int gid = mFirstGID;
		int tileCount = Rows * Columns;
		
		for(int i = 0; i < tileCount; i++)
		{
			FAtlasElement element = new FAtlasElement();
			
			element.name = gid.ToString();
			element.isTrimmed = originalElement.isTrimmed;
			element.atlas = originalElement.atlas;
			element.atlasIndex = i;
			
			float frameX = (originalElement.uvRect.x * textureSize.x) - originalElement.sourceRect.x + ((i % Columns) * mTileWidth);
			float frameY = (-1 * ((originalElement.uvRect.y * textureSize.y) - textureSize.y + originalElement.sourceRect.height)) - originalElement.sourceRect.y + ((i / Rows) * mTileHeight);
			
			float frameW = mTileWidth;
			float frameH = mTileHeight;
			
			Rect uvRect = new Rect
			(
				frameX / textureSize.x,
				((textureSize.y - frameY - frameH) / textureSize.y),
				frameW / textureSize.x,
				frameH / textureSize.y
			);
				
			element.uvRect = uvRect;
		
			element.uvTopLeft.Set(uvRect.xMin,uvRect.yMax);
			element.uvTopRight.Set(uvRect.xMax,uvRect.yMax);
			element.uvBottomRight.Set(uvRect.xMax,uvRect.yMin);
			element.uvBottomLeft.Set(uvRect.xMin,uvRect.yMin);

			//the source size is the untrimmed size
			element.sourcePixelSize.x = mTileWidth;
			element.sourcePixelSize.y = mTileHeight;

			element.sourceSize.x = element.sourcePixelSize.x * scaleInverse;	
			element.sourceSize.y = element.sourcePixelSize.y * scaleInverse;

			//this rect is the trimmed size and position relative to the untrimmed rect
			float rectX = originalElement.sourceRect.x;
			float rectY = originalElement.sourceRect.y;
			float rectW = mTileWidth * scaleInverse;
			float rectH = mTileHeight * scaleInverse;
			
			element.sourceRect = new Rect(rectX, rectY, rectW, rectH);
			
			mTileElements.Add(gid, element);
			gid++;
		}
	}
	
	public FAtlasElement GetTileElement(int _id)
	{
		if(mTileElements.ContainsKey(_id))
			return mTileElements[_id];
		
		throw new FutileException("Tile ID not found [" + _id + "] in " + mName);
	}
	
	public void DebugTileIDs()
	{
		foreach(var element in mTileElements)
			Debug.Log("Tile ID: " + element.Key);
	}
}

/*
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class FTileSet
{
	protected FTileMap mMap;
	
	protected string mName;
	public string Name
	{
		get { return mName; }
	}
	protected string mFile;
	public string File
	{
		get { return mFile; }
	}
	
	protected int mFirstGID;
	public int FirstGID
	{
		get { return mFirstGID; }
	}
	
	protected int mImageWidth;
	public int ImageWidth
	{
		get { return mImageWidth; }
	}
    protected int mImageHeight;
	public int ImageHeight
	{
		get { return mImageHeight; }
	}
	
    protected int mTileWidth;
	public int TileWidth
	{
		get { return mTileWidth; }
	}
    protected int mTileHeight;
	public int TileHeight
	{
		get { return mTileHeight; }
	}
	
    protected int mMargin;
	public int Margin
	{
		get { return mMargin; }
	}
    protected int mSpacing;
	public int Spacing
	{
		get { return mSpacing; }
	}
	
	public FTileSet(FTileMap _map, string _name, string _file, int _firstGID, int _imageWidth, int _imageHeight, int _tileWidth, int _tileHeight, int _margin, int _spacing)
	{
		mMap = _map;
		
		mName = _name;
		mFile = _file;
		
		mFirstGID = _firstGID;
		
		mImageWidth = _imageWidth;
		mImageHeight = _imageHeight;
		
		mTileWidth = _tileWidth;
		mTileHeight = _tileHeight;
		
		mMargin = _margin;
		mSpacing = _spacing;
		
		Debug.Log("TileSet Loaded");
		Futile.atlasManager.LoadAtlas("Maps/" + mName);
		
		//CreateAtlasFile(ParseAtlasText());
	}
	
	private string ParseAtlasText()
	{
		StringBuilder sb = new StringBuilder();
		
		sb.Append("{"); // OPENING START
		sb.Append("\n");
		sb.Append("\"frames\": {"); // FRAMES START
		sb.Append("\n\n");
		
		int i = 1;
		
		int width = mImageWidth / mTileWidth;
		int height = mImageHeight / mTileHeight;
		
		for(int y = 0; y < height; y++)
		for(int x = 0; x < width; x++)
		{
			
			int xPos = x * mTileWidth;
			int yPos = y * mTileHeight;
			
			sb.Append("\"" + i.ToString() + ".png" + "\":"); // NEW FRAME START
			sb.Append("\n");
			sb.Append("{");
			sb.Append("\n");
			sb.Append("\"frame\": {\"x\":" + xPos.ToString() + ",\"y\":" + yPos.ToString() + ",\"w\":" + mTileWidth.ToString() + ",\"h\":" + mTileHeight.ToString() + "},");
			sb.Append("\n");
			sb.Append("\"rotated\": false,");
			sb.Append("\n");
			sb.Append("\"trimmed\": false,");
			sb.Append("\n");
			sb.Append("\"spriteSourceSize\": {\"x\":" + "0" + ",\"y\":" + "0" + ",\"w\":" + mTileWidth.ToString() + ",\"h\":" + mTileHeight.ToString() + "},");
			sb.Append("\n");
			sb.Append("\"sourceSize\": {\"w\":" + mTileWidth.ToString() + ",\"h\":" + mTileHeight.ToString() + "}");
			sb.Append("\n");
			sb.Append("},"); // NEW FRAME END
			sb.Append("\n");
			
			i++;
		}
		
		sb.Append("\n");
		sb.Append("},"); // FRAMES END
		sb.Append("\n");
		sb.Append("\"meta\": {"); // META START
		
		sb.Append("\n");
		sb.Append("\"app\": \"NONE\",");
		sb.Append("\n");
		sb.Append("\"version\": \"1.0\",");
		sb.Append("\n");
		sb.Append("\"image\": \"" + mFile + "\",");
		sb.Append("\n");
		sb.Append("\"format\": \"RGBA8888\",");
		sb.Append("\n");
		sb.Append("\"size\": {\"w\":" + mImageWidth + ",\"h\":" + mImageHeight + "},");
		sb.Append("\n");
		sb.Append("\"scale\": \"1\",");
		sb.Append("\n");
		
		sb.Append("},"); // META END
		sb.Append("\n");
		sb.Append("}"); // OPENING END
		
		return sb.ToString();
	}
	
	private void CreateAtlasFile(string _data)
	{
		System.IO.File.WriteAllText(Application.persistentDataPath + "/" + mName + ".txt", _data);
		//Debug.Log(Application.persistentDataPath);
	}
}
 
*/