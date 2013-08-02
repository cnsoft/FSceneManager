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

public sealed class FSceneManager : FContainer
{
	private static readonly FSceneManager mInstance = new FSceneManager();
	public static FSceneManager Instance
	{
		get
		{
			return mInstance;
		}
	}
	
	private List<FScene> mScenes;
	public static FStage mStage;
	
	private FTransition mTransition;

	private FSceneManager() : base()
	{
		mScenes = new List<FScene>();
		mStage = Futile.stage;

		mStage.AddChild(this);
		
		mTransition = null;
	}
	
	public void PushScene(FScene _scene, bool _pause = false)
	{
		if(_pause)
		foreach(FScene scene in mScenes)
			scene.Paused = true;
		
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
		
		// Unpause scene
		if(mScenes.Count > 0)
		{
			FScene scene = mScenes[mScenes.Count - 1];
			scene.Paused = false;
		}
	}

	public void SetScene(FScene _scene)
	{
		while(mScenes.Count > 0)
			PopScene();

		PushScene(_scene);
	}
	
	public void SetSceneWithTransition(FScene _scene, FTransition _transition)
	{
		
	}
	
	// Added after looking at Iron Pencil's implementation. Thanks!
	private string GetSceneList()
    {
        string sceneList = "";
		
		int i = 1;
		
		foreach(FScene scene in mScenes)
		{
			sceneList += "[" + i + "]" + scene.Name + "\r\n";
			i++;
		}
		
        return sceneList;
    }
}