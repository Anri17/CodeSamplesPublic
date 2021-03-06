/**
* Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
* code [at] RivelloMultimediaConsulting [dot] com                                                  
*                                                                      
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the      
* "Software"), to deal in the Software without restriction, including  
* without limitation the rights to use, copy, modify, merge, publish,  
* distribute, sublicense, and#or sell copies of the Software, and to   
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:                                            
*                                                                      
* The above copyright notice and this permission notice shall be       
* included in all copies or substantial portions of the Software.      
*                                                                      
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
* OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
* ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.                                      
*/
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using com.rmc.projects.coins_and_platforms.components.core;
using UnityEngine;
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.managers;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components.tiles
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum WaypointType 
	{
		START,
		MID,
		END

	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class WaypointComponent : SuperTriggerComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The type of the waypoint.
		/// </summary>
		public WaypointType waypointType;


		
		/// <summary>
		/// The animator.
		/// </summary>
		private Animator _animator;


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public WaypointComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~WaypointComponent ( )
		{
			
			
		}
		
		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_wasTriggered = false;
			_animator = GetComponent <Animator>();
		}
		
		
		
		/// <summary>
		/// Called once per frame
		/// </summary>
		void Update()
		{

		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Does trigger waypoing.
		/// </summary>
		private void _doTriggerWaypoint ()
		{
			_wasTriggered = true;
			_animator.SetTrigger ("wasCollectedTrigger");
			SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.WAYPOINT_TRIGGERED);

		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the trigger enter2 d event.
		/// </summary>
		/// <param name="collider2D">Collider2 d.</param>
		public void OnTriggerEnter2D (Collider2D collider2D)
		{
			if (waypointType == WaypointType.END) {
				//
				if (collider2D.gameObject.tag == MainConstants.PLAYER_TAG) {
					if (!_wasTriggered) {
						_doTriggerWaypoint();
						SimpleGameManager.Instance.gameManager.doGameOver (GameOverReason.WIN);
					}
				}

			} else if (waypointType == WaypointType.MID) {

				//
				if (collider2D.gameObject.tag == MainConstants.PLAYER_TAG) {
					if (!_wasTriggered) {
						_doTriggerWaypoint();
						SimpleGameManager.Instance.gameManager.checkPoint = gameObject;
					}
				}

			}

		}
		
	}
}