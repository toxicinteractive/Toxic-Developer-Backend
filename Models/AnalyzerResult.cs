using System;
namespace PlagiarismAnalyzer.Models
{
    public sealed class AnalyzerResult
    {
        public List<string>? PlagiarismResult { get; set; }
        public string SourceText { get; set; }
        public bool Running { get; set; }
    }

}

