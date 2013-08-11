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

public class FScene : FContainer
{
	protected string mName;
	public string Name
	{
		get { return mName; }
		set { mName = value; }
	}
	
	protected bool mPaused;
	public bool Paused
	{
		get { return mPaused; }
		set { mPaused = value; }
	}

	public FScene (string _name = "Default") : base()
	{
		mName = _name;
	}
	
	override public void HandleAddedToStage()
	{
		base.HandleAddedToStage();
		Futile.instance.SignalUpdate += OnUpdate;
		
		this.OnEnter();
	}

	override public void HandleRemovedFromStage()
	{
		this.OnExit();
		
		Futile.instance.SignalUpdate -= OnUpdate;
		base.HandleRemovedFromStage();
	}
	
	virtual public void OnUpdate ()
	{
		
	}
	
	virtual public void OnEnter()
	{

	}

	virtual public void OnExit()
	{

	}
	
	public override string ToString()
	{
		return "Name: " + mName + " - Paused: " + mPaused;
	}
}
