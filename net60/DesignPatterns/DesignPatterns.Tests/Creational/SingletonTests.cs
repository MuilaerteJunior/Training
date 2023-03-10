using DesignPatterns.Creational;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using DesignPatterns.Models;
using System.Threading;
using System;
using System.Reflection;
using System.Collections.Generic;
using DesignPatterns.Creational.Singleton;
using System.ComponentModel;

namespace DesignPatterns.Tests.Creational
{

    public class SingletonTests
    {
        [Fact(DisplayName = "Singleton simple")]
        public void ParallelTest_Singleton()
        {
            int size = 10000;
            var numberExecutions = 0;
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                Singleton.GetInstance().RandomName = "Random number: " + i;
                var acessing = Singleton.GetInstance().RandomName;
                Interlocked.Increment(ref numberExecutions);
            });
            
            Assert.Equal(size, numberExecutions);
        }
        
        [Fact(DisplayName = "Singleton with constructor on declaration")]
        public void ParallelTest_SingletonBuildOnDeclaration()
        {
            int size = 10000;
            var numberExecutions = 0;
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonBuildOnDeclaration.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonBuildOnDeclaration.GetInstance().RandomName;
                Interlocked.Increment(ref numberExecutions);
            });
            
            Assert.Equal(size, numberExecutions);
        }
        
        [Fact(DisplayName = "Singleton with constructor on declaration and using volatile")]
        public void ParallelTest_SingletonBuildOnDeclarationAndVolatile()
        {
            int size = 10000;
            var numberExecutions = 0;
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonBuildOnDeclarationAndVolatile.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonBuildOnDeclarationAndVolatile.GetInstance().RandomName;
                Interlocked.Increment(ref numberExecutions);
            });
            
            Assert.Equal(size, numberExecutions);
        }
        
        [Fact(DisplayName = "Singleton with constructor on declaration and using volatile and lock")]
        public void ParallelTest_SingletonBuildOnDeclarationAndVolatileLock()
        {
            int size = 10000;
            var numberExecutions = 0;
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonBuildOnDeclarationAndVolatileUsingLock.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonBuildOnDeclarationAndVolatileUsingLock.GetInstance().RandomName;
                Interlocked.Increment(ref numberExecutions);
            });
            
            Assert.Equal(size, numberExecutions);
        }
        
        [Fact(DisplayName = "Singleton using lock")]
        public void ParallelTest_SingletonUsingLock()
        {
            int size = 10000;
            var numberExecutions = 0;
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonUsingLock.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonUsingLock.GetInstance().RandomName;
                Interlocked.Increment(ref numberExecutions);
            });
            
            Assert.Equal(size, numberExecutions);
        }
    
        [Fact(DisplayName = "Checking if singleton concept is violated or not")]
        public void SingletonValidateConcept(){            
            var a = Singleton.GetInstance();
            object r = null;
            Assert.Throws<NullReferenceException>(() => {
                r = a.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[]{});
            });
            
            if ( r != null){
                Assert.Equal(a, r);
            }
        }
    
        [Fact(DisplayName = "Checking if SingletonBuildOnDeclaration concept is violated or not")]
        public void SingletonBuildOnDeclaration_ValidateConcept(){            
            var a = SingletonBuildOnDeclaration.GetInstance();
            object r = null;
            Assert.Throws<NullReferenceException>(() => {
                r = a.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[]{});
            });
            
            if ( r != null){
                Assert.Equal(a, r);
            }
        }
        [Fact(DisplayName = "Checking if SingletonBuildOnDeclarationAndVolatile concept is violated or not")]
        public void SingletonBuildOnDeclarationAndVolatile_ValidateConcept(){            
            var a = SingletonBuildOnDeclarationAndVolatile.GetInstance();
            object r = null;
            Assert.Throws<NullReferenceException>(() => {
                r = a.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[]{});
            });
            
            if ( r != null){
                Assert.Equal(a, r);
            }
        }
    
        [Fact(DisplayName = "Checking if SingletonBuildOnDeclarationAndVolatileUsingLock concept is violated or not")]
        public void SingletonBuildOnDeclarationAndVolatileUsingLock_ValidateConcept(){            
            var a = SingletonBuildOnDeclarationAndVolatileUsingLock.GetInstance();
            object r = null;
            Assert.Throws<NullReferenceException>(() => {
                r = a.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[]{});
            });
            
            if ( r != null){
                Assert.Equal(a, r);
            }
        }
        
        [Fact(DisplayName = "Checking if SingletonUsingLock concept is violated or not")]
        public void SingletonUsingLockValidateConcept(){            
            var a = SingletonUsingLock.GetInstance();
            object r = null;
            Assert.Throws<NullReferenceException>(() => {
                r = a.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[]{});
            });
            
            if ( r != null){
                Assert.Equal(a, r);
            }
        }
    

    
        [Fact(DisplayName = "Singleton -  Check if is the same object is used all the times")]
        public void CheckIfFromAllUsageIsTheSameObjectReference_Singleton()
        {
            int size = 300;
            var r = new List<Singleton>();
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                Singleton.GetInstance().RandomName = "Random number: " + i;
                var acessing = Singleton.GetInstance().RandomName;
                r.Add(Singleton.GetInstance());
            });
            var firstItem = r.FirstOrDefault();
            Assert.All(r, (item) => item.Equals(firstItem));
        }

        //This test method frequently fails
        [Fact(DisplayName = "SingletonBuildOnDeclaration -  Check if is the same object is used all the times")]
        public void CheckIfFromAllUsageIsTheSameObjectReference_SingletonBuildOnDeclaration()
        {
            int size = 300;
            var r = new List<SingletonBuildOnDeclaration>();
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonBuildOnDeclaration.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonBuildOnDeclaration.GetInstance().RandomName;
                r.Add(SingletonBuildOnDeclaration.GetInstance());
            });
            var firstItem = r.FirstOrDefault();
            Assert.All(r, (item) => item.Equals(firstItem));
        }

        [Fact(DisplayName = "SingletonBuildOnDeclarationAndVolatile -  Check if is the same object is used all the times")]
        public void CheckIfFromAllUsageIsTheSameObjectReference_SingletonBuildOnDeclarationAndVolatile()
        {
            int size = 300;
            var r = new List<SingletonBuildOnDeclarationAndVolatile>();
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonBuildOnDeclarationAndVolatile.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonBuildOnDeclarationAndVolatile.GetInstance().RandomName;
                r.Add(SingletonBuildOnDeclarationAndVolatile.GetInstance());
            });
            var firstItem = r.FirstOrDefault();
            Assert.All(r, (item) => item.Equals(firstItem));
        }

        [Category("DEBUG")]
        [Fact(DisplayName = "SingletonBuildOnDeclarationAndVolatileUsingLock -  Check if is the same object is used all the times")]        
        public void CheckIfFromAllUsageIsTheSameObjectReference_SingletonBuildOnDeclarationAndVolatileUsingLock()
        {
            int size = 300;
            var r = new List<SingletonBuildOnDeclarationAndVolatileUsingLock>();
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonBuildOnDeclarationAndVolatileUsingLock.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonBuildOnDeclarationAndVolatileUsingLock.GetInstance().RandomName;
                r.Add(SingletonBuildOnDeclarationAndVolatileUsingLock.GetInstance());
            });
            var firstItem = r.FirstOrDefault();
            Assert.All(r, (item) => item.Equals(firstItem));
        }
                
        //This test method sometimes fails
        [Fact(DisplayName = "SingletonUsingLock - Check if is the same object is used all the times")]
        public void CheckIfFromAllUsageIsTheSameObjectReference_SingletonUsingLock()
        {
            int size = 300;
            var r = new List<SingletonUsingLock>();
            Parallel.ForEach(Enumerable.Range(1, size), (i) =>
            {
                SingletonUsingLock.GetInstance().RandomName = "Random number: " + i;
                var acessing = SingletonUsingLock.GetInstance().RandomName;
                r.Add(SingletonUsingLock.GetInstance());
            });
            var firstItem = r.FirstOrDefault();
            Assert.All(r, (item) => item.Equals(firstItem));
        }
    }
}
