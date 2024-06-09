using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ifc;
using ifc.symbolic;
using IfcSharpLib;
using IfcSharpLib.Util;
using IfcSharpLibTest;

namespace IfcSharpLibBenchmark
{

    [MemoryDiagnoser]
    public class BenchmarkQuery
    {
        private readonly Reader _reader;

        private readonly ExprIndex _testIndex;

        public BenchmarkQuery()
        {
            _reader = new Reader(TestFileLocator.GetTestFilePath("CharArrayTests.ixx.ifc"));

            var decls = _reader.Partition<VariableDecl>();
            foreach (ref readonly var decl in decls)
            {
                if (_reader.GetString(decl.identity).Contains("UmlautsHex"))
                {
                    _testIndex = decl.initializer;
                    break;
                }
            }
        }

        [Benchmark]
        public void TestQuery()
        {
            _reader.Query(_testIndex).Get<ArrayValueExpr>(out var arrayValueExpr)
                   .Query(arrayValueExpr.elements).Get<TupleExpr>(out var tupleExpr)
                   .Sequence(tupleExpr);
        }

        [Benchmark]
        public void TestQueryRef()
        {
            _reader.Query(_testIndex).GetRef<ArrayValueExpr>(out var arrayValueExpr)
                   .Query(arrayValueExpr.Value.elements).GetRef<TupleExpr>(out var tupleExpr)
                   .Sequence(tupleExpr.Value);
        }

        [Benchmark]
        public void TestNoQuery() => _reader.Sequence(_reader.Get<TupleExpr>(_reader.Get<ArrayValueExpr>(_testIndex).elements));

        [Benchmark]
        public void TestNoQuery2()
        {
            ref readonly var tupleExpr = ref _reader.Get<TupleExpr>(_reader.Get<ArrayValueExpr>(_testIndex).elements);
            _reader.Sequence<TupleExpr, ExprIndex, HeapSort>(in tupleExpr);
        }

        [Benchmark]
        public void TestNoQuery3()
        {
            _reader.Sequence<TupleExpr, ExprIndex, HeapSort>(in _reader.Get<TupleExpr>(_reader.Get<ArrayValueExpr>(_testIndex).elements));
        }
    }

    public class MainBenchmark
    {
        public static void Main(string[] args)
        {
            //new BenchmarkQuery().TestQuery();
            var summary = BenchmarkRunner.Run<BenchmarkQuery>();

            /*
             * 
                BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
                Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
                .NET SDK 8.0.300
                    [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
                    DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


                | Method       | Mean     | Error    | StdDev   | Gen0   | Allocated |
                |------------- |---------:|---------:|---------:|-------:|----------:|
                | TestQuery    | 18.02 ns | 0.284 ns | 0.266 ns | 0.0048 |      40 B |
                | TestQueryRef | 16.70 ns | 0.252 ns | 0.236 ns | 0.0048 |      40 B |
                | TestNoQuery  | 14.54 ns | 0.317 ns | 0.365 ns | 0.0048 |      40 B |
                | TestNoQuery2 | 10.70 ns | 0.111 ns | 0.086 ns |      - |         - |
                | TestNoQuery3 | 12.53 ns | 0.101 ns | 0.094 ns |      - |         - |
             * 
             */
        }
    }
}
