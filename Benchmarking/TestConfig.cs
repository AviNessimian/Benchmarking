using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;

namespace Benchmarking;

public class TestConfig : ManualConfig
{
    public TestConfig()
    {
        Add(RankColumn.Roman);
        Add(CsvMeasurementsExporter.Default);
        Add(RPlotExporter.Default);
        Add(PlainExporter.Default);
        Add(HtmlExporter.Default);
    }
}