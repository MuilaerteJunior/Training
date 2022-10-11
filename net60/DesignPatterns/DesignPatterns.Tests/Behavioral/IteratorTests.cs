using DesignPatterns.Behavioral.Iterator;
using Xunit;
using System;
using DesignPatterns.Behavioral.Iterator.IEnumerableAndIEnumeratorUsage;

namespace DesignPatterns.Tests.Behavioral
{
    public class IteratorTests{
        [Fact]        
        public void ValidateIteratorConcepts(){
            //Arrange
            var a = new MyLotOfDifferentAggregates();
            a.AddMyGuys(new MyRandomMatrix());
            a.AddMyGuys(new MyRandomCollection());

            //Act
            var f = a.RunOverMyAggregates();

            Console.WriteLine(string.Join(Environment.NewLine,f));

            //Assert
            Assert.Contains(3.ToString(), f);//This exists in MyRandomCollection;
            Assert.Contains(20.ToString(), f);//This exists in MyRandomMatrix;            
        }

        
        [Fact]        
        public void ValidateIteratorConceptsWithIEnumerableUsage(){
            //Arrange
           var a = new MyOtherAggregates(new MyArrayCollection(), new MyCustomCollection());

            //Act
            var f = a.LetsRunOverAggregates();
            
            Console.WriteLine(string.Join(Environment.NewLine,f));

            //Assert    
            Assert.Contains(2.ToString(), f);
            Assert.Contains(13.ToString(), f);
        }
    }
}

