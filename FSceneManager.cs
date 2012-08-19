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

public sealed class FSceneManager : FContainer
{
	private static readonly FSceneManager mInstance = new FSceneManager();
	
	private List<FScene> mScenes;
	public static FStage mStage;
	
	public static FSceneManager Instance
	{
		get
		{
			return mInstance;
		}
	}
	
	private FSceneManager()
	{
		mScenes = new List<FScene>();
		mStage = Futile.stage;
		
		mStage.AddChild(this);
	}
	
	public void PushScene(FScene _scene)
	{
		mScenes.Add(_scene);
		this.AddChild(_scene);
	}
	
	public void PopScene()
	{
		if(mScenes.Count > 0)
		{
			FScene scene = mScenes[mScenes.Count - 1];
			scene.RemoveFromContainer();
			
			mScenes.Remove(scene);
		}
	}
	
	public void SetScene(FScene _scene)
	{
		while(mScenes.Count > 0)
			PopScene();
		
		PushScene(_scene);
	}
}
