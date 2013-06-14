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

public class FTileSet
{
	protected FTileMap mParent;
	
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
	
	public FTileSet(string _name, string _file, int _firstGID, int _imageWidth, int _imageHeight, int _tileWidth, int _tileHeight, int _margin, int _spacing)
	{
		mName = _name;
		mFile = _file;
		
		mFirstGID = _firstGID;
		
		mImageWidth = _imageWidth;
		mImageHeight = _imageHeight;
		
		mTileWidth = _tileWidth;
		mTileHeight = _tileHeight;
		
		mMargin = _margin;
		mSpacing = _spacing;
	}
}
