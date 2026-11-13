using System;
using System.Collections.Generic;

public enum PlayerMove
{
    Gain, // Draw a card from the deck
    Swap, // Exchange a card with the Discard pile
    Stand, // No action, like a check in poker
    Junk // Forfeit, like a fold in poker
}

public enum SabaccState
{
    Setup, // Initial phase: Cards are dealt and top card is moved to discard pile
    PlayerTurn, // Phase where players take their turns
    EndRound, // Phase where the round ends and scores are calculated
    FinalRound, // Phase where the final round takes place and scores are calculated
    Showdown // Phase where the game ends and the winner is determined
}

public enum SabaccCommand
{
    StartGame, // Command to start the game
    PlayerAction, // Command for a player to perform an action
    EndRound, // Command to end the current round
    FinalRound, // Command to start the final round
    Replay, // Command to reset the game state for the next play
    EndGame // Command to end the game
}

public class SabaccStateMachine
    {
        class StateTransition
        {
            readonly SabaccState CurrentState;
            readonly SabaccCommand Command;

            public StateTransition(SabaccState currentState, SabaccCommand command)
            {
                CurrentState = currentState;
                Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }
        }

        Dictionary<StateTransition, SabaccState> transitions;
        public SabaccState CurrentState { get; private set; }

        public SabaccStateMachine()
        {
            CurrentState = SabaccState.Setup;
            // TODO: Fix This to be correct
            transitions = new Dictionary<StateTransition, SabaccState>
            {
                { new StateTransition(SabaccState.Setup, SabaccCommand.StartGame), SabaccState.PlayerTurn },
                { new StateTransition(SabaccState.PlayerTurn, SabaccCommand.PlayerAction), SabaccState.PlayerTurn },
                { new StateTransition(SabaccState.PlayerTurn, SabaccCommand.EndRound), SabaccState.EndRound },
                { new StateTransition(SabaccState.EndRound, SabaccCommand.FinalRound), SabaccState.FinalRound },
                { new StateTransition(SabaccState.FinalRound, SabaccCommand.EndGame), SabaccState.Showdown },
                { new StateTransition(SabaccState.Showdown, SabaccCommand.Replay), SabaccState.Setup }
            };
        }

        public SabaccState GetNext(SabaccCommand command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            SabaccState nextState;
            if (!transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            return nextState;
        }

        public SabaccState MoveNext(SabaccCommand command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }