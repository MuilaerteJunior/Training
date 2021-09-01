using System;
using System.Linq;
using DesignPatterns.Behavioral.State;
using Xunit;

namespace DesignPatterns.Tests.Behavioral
{
    public class StateTests
    {
        [Fact(DisplayName = "Validating State concepts")]
        public void ValidateStateConcepts(){
            //Arrange
            var game = new MemoryGame();
            
            //Act / assert
            //Start
            game.Start();
            Assert.Equal(typeof(StartedState), game.MyState.GetType());

            //Stop            
            game.Stop();
            Assert.Equal(typeof(StoppedState), game.MyState.GetType());

            //Paused
            game.Start();
            game.Pause();
            Assert.Equal(typeof(PausedState), game.MyState.GetType());

            //Resume
            game.Resume();
            Assert.Equal(typeof(StartedState), game.MyState.GetType());
        }

        [Fact(DisplayName =  "Check if the memory card board is generating the expected number of cards")]
        public void ValidateMemoryGeneration(){
            //Arrange
            var game = new MemoryGame();
            short numberOfPairs = 5;

            //Act
            var r = game.GenerateCards(numberOfPairs);

            //Assert
            Assert.Equal(numberOfPairs * 2, r.Count());
        }

        [Fact(DisplayName =  "Check if exist a pair for each card for the memory game")]
        public void ValidateMemoryGeneration2(){
            //Arrange
            var game = new MemoryGame();
            short numberOfPairs = short.MaxValue;

            //Act
            var r = game.GenerateCards(numberOfPairs);
            var groupBy = r.GroupBy(a => a).Select(g => g.Count());

            //Assert            
            Assert.All(groupBy, g => Assert.True(g == 2));
        }

        
        [Fact(DisplayName =  "Check if random position is generating different for each call")]
        public void ValidateMemoryGeneration3(){
            //Arrange
            var game = new MemoryGame();
            short numberOfPairs = 3;

            //Act
            var r1 = game.GenerateCards(numberOfPairs).ToArray();
            var r2 = game.GenerateCards(numberOfPairs).ToArray();
            var r3 = game.GenerateCards(numberOfPairs).ToArray();

            //Assert
            Assert.NotEqual(r1, r2);
            Assert.NotEqual(r2, r3);
        }
    }
}