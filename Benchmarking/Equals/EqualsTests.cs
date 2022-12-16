using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;

namespace Benchmarking.Equals
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Roman)]
    public class EqualsTests
    {

        private static readonly List<TestModel> Data1 = new List<TestModel>
        {
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
        };

        private static readonly List<TestModel> Data2 = new List<TestModel>
        {
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" }
        };

        private static readonly List<TestModel> Data3 = new List<TestModel>
        {
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value6" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" } ,
            new () { Prop1 = "Value1", Prop2 = "Value2", Prop3 = "Value3", Prop4 = "Value4", Prop5 = "Value5" }
        };

        [Benchmark]
        public void Enumerable_SequenceEqual_EqualTest()
        {
            bool equal = Data1.SequenceEqual(Data2);
        }

        [Benchmark]
        public void Enumerable_SequenceEqual_NotEqualTest()
        {
            bool equal = Data1.SequenceEqual(Data3);
        }


        [Benchmark]
        public void HashSet_SetEquals_EqualTest()
        {
            bool equal = (new HashSet<TestModel>(Data1 ?? new List<TestModel>())).SetEquals(Data2 ?? new List<TestModel>());
        }

        [Benchmark]
        public void HashSet_SetEquals_NotEqualTest()
        {
            bool equal = (new HashSet<TestModel>(Data1 ?? new List<TestModel>())).SetEquals(Data3 ?? new List<TestModel>());
        }
    }
}
