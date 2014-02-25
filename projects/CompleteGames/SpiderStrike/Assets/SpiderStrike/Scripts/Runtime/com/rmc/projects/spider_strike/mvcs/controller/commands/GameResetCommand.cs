﻿/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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
using strange.extensions.command.impl;
using UnityEngine;
using com.rmc.projects.spider_strike.mvcs.model;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.spider_strike.mvcs.controller.commands
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GameResetCommand : Command
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER

		/// <summary>
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IGameModel iGameModel { get; set; } 

		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Execute
		///</summary>
		public override void Execute()
		{
			//
			//Debug.Log ("GameResetCommand.cs.Execute()" + gameState);


			//IDEALLY 100% OF RAM IS BLANKED. IS SOMETHING NOT BLANKING? WE HAVE A BUG
			//WE ARE TESTING THE 'COMPLETENESS' OF A RESET
			//SHALL WE SET A VALUE AND TEST THE MODEL LATER?
			//iGameModel.blah

			/// NOTE: This works great. 
			/// 
			/// NOTE: In a more mature game, you may need be
			/// 		manually removing and recreating things WITHOUT changin scenes
			/// 		or put this logic in a more central location
			Application.LoadLevel (Application.loadedLevel);

			
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
