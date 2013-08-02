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

public class FTileMap
{
	protected string mName;
	
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
	
	protected string mOrientation;
	public string Orientation
	{
		get { return mOrientation; }
	}
	
	protected Dictionary<string, FTileLayer> mTileLayers;
	protected Dictionary<string, FTileSet> mTileSets;
	
	public FTileMap(string _file)
	{
		mTileLayers = new Dictionary<string, FTileLayer>();
		mTileSets = new Dictionary<string, FTileSet>();
		
		Parse(_file);
	}
	
	protected void Parse(string _file)
	{
		TextAsset mapAsset = (TextAsset) Resources.Load("Maps/" + _file, typeof(TextAsset));
		
		if(!mapAsset)
		{
			Debug.Log("Couldn't load map file: " + _file);
			return;
		}
		
		Dictionary<string, object> hash = mapAsset.text.dictionaryFromJson();
		
		mName = "DEFAULTFORNOW";
		
		mOrientation = hash["orientation"].ToString();
		
		mTileWidth = int.Parse(hash["tilewidth"].ToString());
		mTileHeight = int.Parse(hash["tileheight"].ToString());
		
		mWidth = int.Parse(hash["width"].ToString());
		mHeight = int.Parse(hash["height"].ToString());
		
		List<object> tilesetsList = (List<object>)hash["tilesets"];
		foreach(Dictionary<string,object> tilesetHash in tilesetsList)
		{
			string name = tilesetHash["name"].ToString();
			string file = tilesetHash["image"].ToString();
			
			int firstgid = int.Parse(tilesetHash["firstgid"].ToString());
			
			int imagewidth = int.Parse(tilesetHash["imagewidth"].ToString());
			int imageheight = int.Parse(tilesetHash["imageheight"].ToString());
			
			int tilewidth = int.Parse(tilesetHash["tilewidth"].ToString());
			int tileheight = int.Parse(tilesetHash["tileheight"].ToString());
			
			int spacing = int.Parse(tilesetHash["spacing"].ToString());
			int margin = int.Parse(tilesetHash["margin"].ToString());
			
			FTileSet tileset = new FTileSet(this, name, file, firstgid, imagewidth, imageheight, tilewidth, tileheight, margin, spacing);
			mTileSets.Add(name, tileset);
		}
		
		List<object> layersList = (List<object>)hash["layers"];
		foreach(Dictionary<string,object> layerHash in layersList)
		{
			// Can only load tilelayers right now
			if(layerHash["type"].ToString() != "tilelayer")
				continue;
			
			string name = layerHash["name"].ToString();
			int width = int.Parse(layerHash["width"].ToString());
			int height = int.Parse(layerHash["height"].ToString());
			float opacity = float.Parse(layerHash["opacity"].ToString());
			
			// Crazy way of geting the tile IDs out of the json file
			List<int> tiles = new List<int>();
			List<object> tilesList = (List<object>)layerHash["data"];
			foreach(object tile in tilesList)
				tiles.Add(int.Parse(tile.ToString()));
			
			FTileLayer layer = new FTileLayer(this, name, width, height, opacity, tiles);
			mTileLayers.Add(name, layer);
		}
		
		Resources.UnloadAsset(mapAsset);
	}
	
	public FTileLayer GetTileLayer(string _name)
	{
		if(mTileLayers.ContainsKey(_name))
			return mTileLayers[_name];
		
		return null;
	}
	
	public FTileSet GetTileSet(string _name)
	{
		if(mTileSets.ContainsKey(_name))
			return mTileSets[_name];
		
		return null;
	}
}
