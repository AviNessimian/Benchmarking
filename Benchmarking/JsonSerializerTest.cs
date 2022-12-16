using BenchmarkDotNet.Attributes;


namespace Benchmarking
{
    [MemoryDiagnoser]
    //[SimpleJob(RuntimeMoniker.CoreRt60)]
    public class JsonSerializerTest
    {
        private readonly object data;

        public JsonSerializerTest()
        {
            data = new
            {
                A = "asdgasga",
                B = "asdgasga",
                C = "asdgasga",
                D = "asdgasga",
                E = 123,
                F = "asdgasga",
                G = "",
                H = "",
                I = "",
                J = "",
                K = "",
                L = "",
                M = "",
                N = "",
                O = "",
                P = "",
                Q = "",
                R = "",
                S = "",
                T = "",
                U = "",
                V = "",
                W = "",
                X = "",
                Y = "",
                Z = ""
            };
        }

        [Benchmark]
        public string JsonSerializer() => System.Text.Json.JsonSerializer.Serialize(data);

        [Benchmark]
        public string MJsonConvert5() => Newtonsoft.Json.JsonConvert.SerializeObject(data);
    }
}
