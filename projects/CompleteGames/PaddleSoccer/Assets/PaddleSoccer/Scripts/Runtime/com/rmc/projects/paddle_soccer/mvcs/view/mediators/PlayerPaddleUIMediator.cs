/**
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
using UnityEngine;
using strange.extensions.mediation.impl;
using com.rmc.projects.paddle_soccer.mvcs.view.ui;
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.paddle_soccer.mvcs.model;
using com.rmc.exceptions;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.mediators
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
	public class PlayerPaddleUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public PlayerPaddleUI view 	{ get; set;}
		
		/// <summary>
		/// Gets or sets the turret do move signal.
		/// </summary>
		/// <value>The turret do move signal.</value>
		[Inject]
		public PlayerDoMoveSignal playerDoMoveSignal 		{ get; set;}


		/// <summary>
		/// Gets or sets the sound play signal.
		/// </summary>
		/// <value>The sound play signal.</value>
		[Inject]
		public SoundPlaySignal soundPlaySignal { get; set;}

		
		/// <summary>
		/// Gets or sets the game state changed signal.
		/// </summary>
		/// <value>The game state changed signal.</value>
		[Inject]
		public GameStateChangedSignal gameStateChangedSignal {set; get;}
		


		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			//
			view.init();
			playerDoMoveSignal.AddListener (_onPlayerDoMoveSignal);
			gameStateChangedSignal.AddListener (_onGameStateChangedSignal);
			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			//
			playerDoMoveSignal.RemoveListener (_onPlayerDoMoveSignal);
			gameStateChangedSignal.RemoveListener (_onGameStateChangedSignal);
		}
		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update()
		{

		}
		
		
		//	PUBLIC
		
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		/// <summary>
		/// When the game state changed signal.
		/// </summary>
		/// <param name="aGameState">A game state.</param>
		private void _onGameStateChangedSignal (GameState aGameState)
		{
			//todo:change to
			//if (aGameState == GameState.ROUND_DURING_CORE_GAMEPLAY) {
			if (aGameState == GameState.ROUND_DURING_CORE_GAMEPLAY) {
				view.isRunningUpdate = true;
				view.doTweenToStartingPosition(0);
			} else if (aGameState == GameState.ROUND_START) {
				view.isRunningUpdate = false;
			} else if (aGameState == GameState.GAME_START) {
				view.doTweenToOffscreenPosition(-1f);

			}
			
		}


		/// <summary>
		/// When the turret do move signal.
		/// </summary>
		/// <param name="aTurretMoveVO">A turret move V.</param>
		private void _onPlayerDoMoveSignal (PlayerMoveVO aPlayerMoveVO) 
		{
			switch (aPlayerMoveVO.moveType) {
			case MoveType.UpOneTick:
				view.targetY += aPlayerMoveVO.amount;
				break;
			case MoveType.DownOneTick:
				view.targetY -= aPlayerMoveVO.amount;
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
		}
		
	}
}
